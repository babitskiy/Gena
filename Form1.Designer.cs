﻿namespace Gena
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
            this.btnChooseExcelFile.Location = new System.Drawing.Point(12, 12);
            this.btnChooseExcelFile.Name = "btnChooseExcelFile";
            this.btnChooseExcelFile.Size = new System.Drawing.Size(200, 40);
            this.btnChooseExcelFile.TabIndex = 0;
            this.btnChooseExcelFile.Text = "Выбрать файл...";
            this.btnChooseExcelFile.UseVisualStyleBackColor = true;
            this.btnChooseExcelFile.Click += new System.EventHandler(this.btnChooseExcelFile_Click);
            // 
            // btnStartGeneration
            // 
            this.btnStartGeneration.Location = new System.Drawing.Point(876, 676);
            this.btnStartGeneration.Name = "btnStartGeneration";
            this.btnStartGeneration.Size = new System.Drawing.Size(200, 40);
            this.btnStartGeneration.TabIndex = 1;
            this.btnStartGeneration.Text = "Сгенерировать";
            this.btnStartGeneration.UseVisualStyleBackColor = true;
            this.btnStartGeneration.Click += new System.EventHandler(this.btnStartGeneration_Click);
            // 
            // radioButton_DS
            // 
            this.radioButton_DS.AutoSize = true;
            this.radioButton_DS.Location = new System.Drawing.Point(12, 58);
            this.radioButton_DS.Name = "radioButton_DS";
            this.radioButton_DS.Size = new System.Drawing.Size(64, 34);
            this.radioButton_DS.TabIndex = 2;
            this.radioButton_DS.TabStop = true;
            this.radioButton_DS.Text = "DS";
            this.radioButton_DS.UseVisualStyleBackColor = true;
            this.radioButton_DS.CheckedChanged += new System.EventHandler(this.radioButton_DS_CheckedChanged);
            // 
            // radioButton_DSO
            // 
            this.radioButton_DSO.AutoSize = true;
            this.radioButton_DSO.Location = new System.Drawing.Point(12, 98);
            this.radioButton_DSO.Name = "radioButton_DSO";
            this.radioButton_DSO.Size = new System.Drawing.Size(80, 34);
            this.radioButton_DSO.TabIndex = 3;
            this.radioButton_DSO.TabStop = true;
            this.radioButton_DSO.Text = "DSO";
            this.radioButton_DSO.UseVisualStyleBackColor = true;
            this.radioButton_DSO.CheckedChanged += new System.EventHandler(this.radioButton_DSO_CheckedChanged);
            // 
            // richTextBox_Logs
            // 
            this.richTextBox_Logs.Location = new System.Drawing.Point(25, 173);
            this.richTextBox_Logs.Name = "richTextBox_Logs";
            this.richTextBox_Logs.ReadOnly = true;
            this.richTextBox_Logs.Size = new System.Drawing.Size(1032, 477);
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
            this.label1.Location = new System.Drawing.Point(8, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Gena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 728);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox_Logs);
            this.Controls.Add(this.radioButton_DSO);
            this.Controls.Add(this.radioButton_DS);
            this.Controls.Add(this.btnStartGeneration);
            this.Controls.Add(this.btnChooseExcelFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
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
        private RichTextBox richTextBox_Logs;
        private OpenFileDialog openFileDialog1;
        private Label label1;
    }
}