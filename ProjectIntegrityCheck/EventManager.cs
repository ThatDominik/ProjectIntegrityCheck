using System.Xml.Linq;

namespace ProjectIntegrityCheck
{
    public class EventManager
    {
        /// <summary>
        /// Metoda pro nahrání dat z XML souboru a postupné validaci směn pro jednotlivé podniky.
        /// </summary>
        /// <param name="file"> Cesta k XML souboru, kterou poskytl OpenFile dialog. </param>
        /// <returns> Hláška o výsledku validace. </returns>
        public string ValidateXmlIntegrity(string file)
        {          
            XElement xml = XElement.Load(file);
            var ns = xml.GetDefaultNamespace();
            var branches = xml.Elements(ns + "pobocka").ToList();

            if(branches.Count == 0)
            {
                return "Chyba: V dokumentu nemohu najít pobočky.";
            }

            string message = string.Empty;

            foreach( var branch in branches)
            {
                message += ValidateShifts(branch, ns);
            }
            if(message == string.Empty) { return "XML dokument OK!"; }

            return message;
        }

        /// <summary>
        /// Metoda pro kontrolu referenční integrity směn v dané pobočce.
        /// </summary>
        /// <param name="branch"> Informace o pobočce ve formátu XML. </param>
        /// <param name="ns"> Namespace ve kterém se data o pobočce nachází. </param>
        /// <returns> Hláška o stavu validace pro danou pobočku. </returns>
        private string ValidateShifts(XElement branch, XNamespace ns)
        {
            Dictionary<int, List<string>>  shiftLedger = new Dictionary<int, List<string>>();
            string status = string.Empty;
            string branchName = branch.Element(ns + "nazev").Value;
            var shifts = branch.Element(ns + "smeny").Elements(ns + "smena").ToList();

            foreach ( var shift in shifts ) 
            {
                string shiftDate = shift.Element(ns + "datum_smeny").Value;
                int employeeId = (int) shift.Element(ns + "id_zamestnance");

                IEnumerable<XElement> employeeInfo =
                            from el in branch.Element(ns + "zamestnanci").Elements(ns + "zamestnanec")
                            where (int)el.Attribute("id") == employeeId
                            select el;

                if (!employeeInfo.Any()) 
                { 
                    return "Chyba: Nemohu najít jméno zaměstnance podle jeho id!"; 
                }

                XElement employee = employeeInfo.First();
                string employeeName = employee.Element(ns + "jmeno").Value + " " + employee.Element(ns + "prijmeni").Value;
                string onboardingDate = employee.Element(ns + "datum_prijeti").Value;

                // Kontrola, že zaměstnanec má maximálně 1 směnu za den.
                if (!shiftLedger.ContainsKey(employeeId))
                {
                    shiftLedger.Add(employeeId, new List<string> {shiftDate});
                }
                else
                {
                    if (shiftLedger[employeeId].Contains(shiftDate))
                    {
                        status += branchName + ":\nZaměstnanec " + employeeName +  " má dne " + shiftDate + " víc než jednu směnu! \n";
                    }
                    else
                    {
                        shiftLedger[employeeId].Add(shiftDate);
                    }
                }

                // Kontrola, že směna neproběhla před datem nástupu zaměstnance.
                if(DateTime.Parse(onboardingDate) > DateTime.Parse(shiftDate))
                {
                    status += branchName + ":\nZaměstnanec " + employeeName + " má dne " + shiftDate + " směnu před datumem jeho nastoupení! \n";
                }
            }
            return status;
        }
    }
}
