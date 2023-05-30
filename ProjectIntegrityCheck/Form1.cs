namespace ProjectIntegrityCheck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"c:\",
                Title = "Select XML file for validation.",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                OutputText.Text = "File ready for validation.";
            }
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            EventManager manager = new EventManager();
            OutputText.Text = manager.ValidateXmlIntegrity(textBox1.Text);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void OutputText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}