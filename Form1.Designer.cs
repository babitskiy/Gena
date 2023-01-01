namespace Gena
{
    partial class Gena
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
            this.btnChooseExcelFile = new System.Windows.Forms.Button();
            this.btnStartGeneration = new System.Windows.Forms.Button();
            this.radioButton_DS = new System.Windows.Forms.RadioButton();
            this.radioButton_DSO = new System.Windows.Forms.RadioButton();
            this.richTextBox_Logs = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnChooseExcelFile
            // 
            this.btnChooseExcelFile.Location = new System.Drawing.Point(7, 6);
            this.btnChooseExcelFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnChooseExcelFile.Name = "btnChooseExcelFile";
            this.btnChooseExcelFile.Size = new System.Drawing.Size(117, 20);
            this.btnChooseExcelFile.TabIndex = 0;
            this.btnChooseExcelFile.Text = "Выбрать файл...";
            this.btnChooseExcelFile.UseVisualStyleBackColor = true;
            this.btnChooseExcelFile.Click += new System.EventHandler(this.btnChooseExcelFile_Click);
            // 
            // btnStartGeneration
            // 
            this.btnStartGeneration.Location = new System.Drawing.Point(511, 338);
            this.btnStartGeneration.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartGeneration.Name = "btnStartGeneration";
            this.btnStartGeneration.Size = new System.Drawing.Size(117, 20);
            this.btnStartGeneration.TabIndex = 1;
            this.btnStartGeneration.Text = "Сгенерировать";
            this.btnStartGeneration.UseVisualStyleBackColor = true;
            this.btnStartGeneration.Click += new System.EventHandler(this.btnStartGeneration_Click);
            // 
            // radioButton_DS
            // 
            this.radioButton_DS.AutoSize = true;
            this.radioButton_DS.Location = new System.Drawing.Point(7, 29);
            this.radioButton_DS.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_DS.Name = "radioButton_DS";
            this.radioButton_DS.Size = new System.Drawing.Size(39, 19);
            this.radioButton_DS.TabIndex = 2;
            this.radioButton_DS.TabStop = true;
            this.radioButton_DS.Text = "DS";
            this.radioButton_DS.UseVisualStyleBackColor = true;
            this.radioButton_DS.CheckedChanged += new System.EventHandler(this.radioButton_DS_CheckedChanged);
            // 
            // radioButton_DSO
            // 
            this.radioButton_DSO.AutoSize = true;
            this.radioButton_DSO.Location = new System.Drawing.Point(7, 49);
            this.radioButton_DSO.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_DSO.Name = "radioButton_DSO";
            this.radioButton_DSO.Size = new System.Drawing.Size(48, 19);
            this.radioButton_DSO.TabIndex = 3;
            this.radioButton_DSO.TabStop = true;
            this.radioButton_DSO.Text = "DSO";
            this.radioButton_DSO.UseVisualStyleBackColor = true;
            this.radioButton_DSO.CheckedChanged += new System.EventHandler(this.radioButton_DSO_CheckedChanged);
            // 
            // richTextBox_Logs
            // 
            this.richTextBox_Logs.Location = new System.Drawing.Point(15, 86);
            this.richTextBox_Logs.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox_Logs.Name = "richTextBox_Logs";
            this.richTextBox_Logs.ReadOnly = true;
            this.richTextBox_Logs.Size = new System.Drawing.Size(604, 240);
            this.richTextBox_Logs.TabIndex = 4;
            this.richTextBox_Logs.Text = "Выберите excel-файл с описанием жц, отметьте тип системы (DS/DSO), а затем нажмит" +
    "е кнопку \"Сгенерировать\".";
            this.richTextBox_Logs.TextChanged += new System.EventHandler(this.richTextBox_Logs_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Файл не выбран";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Gena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 364);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox_Logs);
            this.Controls.Add(this.radioButton_DSO);
            this.Controls.Add(this.radioButton_DS);
            this.Controls.Add(this.btnStartGeneration);
            this.Controls.Add(this.btnChooseExcelFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Gena";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gena - генератор жц";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnChooseExcelFile;
        private Button btnStartGeneration;
        private RadioButton radioButton_DS;
        private RadioButton radioButton_DSO;
        private OpenFileDialog openFileDialog1;
        private Label label1;
        private RichTextBox richTextBox_Logs;
    }
}