namespace ProjectIntegrityCheck
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            OutputText = new RichTextBox();
            LoadButton = new Button();
            ValidateButton = new Button();
            OpenFile = new OpenFileDialog();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(149, 32);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 0;
            label1.Text = "Selected XML file";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(149, 50);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(504, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += TextBox1_TextChanged;
            // 
            // OutputText
            // 
            OutputText.Location = new Point(149, 127);
            OutputText.Name = "OutputText";
            OutputText.Size = new Size(504, 247);
            OutputText.TabIndex = 2;
            OutputText.Text = "";
            OutputText.TextChanged += OutputText_TextChanged;
            // 
            // LoadButton
            // 
            LoadButton.Location = new Point(149, 79);
            LoadButton.Name = "LoadButton";
            LoadButton.Size = new Size(94, 40);
            LoadButton.TabIndex = 3;
            LoadButton.Text = "Load XML file";
            LoadButton.UseVisualStyleBackColor = true;
            LoadButton.Click += LoadButton_Click;
            // 
            // ValidateButton
            // 
            ValidateButton.Location = new Point(559, 81);
            ValidateButton.Name = "ValidateButton";
            ValidateButton.Size = new Size(94, 40);
            ValidateButton.TabIndex = 4;
            ValidateButton.Text = "Validate";
            ValidateButton.UseVisualStyleBackColor = true;
            ValidateButton.Click += ValidateButton_Click;
            // 
            // OpenFile
            // 
            OpenFile.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ValidateButton);
            Controls.Add(LoadButton);
            Controls.Add(OutputText);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private RichTextBox OutputText;
        private Button LoadButton;
        private Button ValidateButton;
        private OpenFileDialog OpenFile;
    }
}