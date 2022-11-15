using ClosedXML.Excel;
using System.Windows.Forms;

namespace Gena
{
    public partial class Gena : Form
    {
        bool f_open; //���������� ����� �����
        bool canStart = false; //���������� ����� �� ��������� ���������
        string? systemType = null; //���������� ��� ������� DS/DSO

        public Gena()
        {
            InitializeComponent();
        }

        private void btnChooseExcelFile_Click(object sender, EventArgs e)
        {
            //�������� ���� � ��������, ������ �� ����
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //�������� ���� � ���������� � ������� ��������� ������-����
                DirectoryInfo directoryInfo = new DirectoryInfo(openFileDialog1.FileName);
                var fileExtension = Path.GetExtension(openFileDialog1.FileName);
                var fileName = Path.GetFileName(openFileDialog1.FileName);

                //������� ��� ����� �� ����� � ���������� label1
                label1.Text = openFileDialog1.FileName;

                richTextBox_Logs.AppendText("\r\n");
                richTextBox_Logs.AppendText(@"������ ���� " + fileName);

                //���������� ������ f_open
                f_open = true;

                if (fileExtension == ".xlsx" || fileExtension == ".xls")
                {
                    canStart = true;
                }
                else
                {
                    richTextBox_Logs.AppendText("\r\n");
                    richTextBox_Logs.AppendText(@"����� ������� excel-���� � ����������� .xls ��� .xlsx");
                }
                // 7. ������� ���������� � ������
                //sr.Close();
            }
        }

        private void btnStartGeneration_Click(object sender, EventArgs e)
        {
            if(canStart)
            {
                //�������� ���� � ���������� � ������� ��������� ������-����
                DirectoryInfo directoryInfo = new DirectoryInfo(openFileDialog1.FileName);
                var fileExtension = Path.GetExtension(openFileDialog1.FileName);
                var fileName = Path.GetFileName(openFileDialog1.FileName);
                var parentFolder = directoryInfo.Parent;

                if(systemType != null)
                {
                    if (systemType == "DS")
                    {
                        Directory.CreateDirectory(parentFolder + "\\xmlFiles\\");
                        richTextBox_Logs.AppendText("\r\n");
                        richTextBox_Logs.AppendText(@"������� ����� " + "xmlFiles");

                    }
                    else if (systemType == "DSO")
                    {
                        var pathToFolderWithJSONFiles = parentFolder + "\\jsonFiles\\";
                        Directory.CreateDirectory(pathToFolderWithJSONFiles);
                        richTextBox_Logs.AppendText("\r\n");
                        richTextBox_Logs.AppendText(@"������� ����� " + "jsonFiles");
                        if(LifeCycleGenerator.GenerateLifeCycle(openFileDialog1.FileName, pathToFolderWithJSONFiles))
                        {
                            richTextBox_Logs.AppendText("\r\n");
                            richTextBox_Logs.AppendText(@"�� ������������ �������");
                        }
                        else
                        {
                            richTextBox_Logs.AppendText("\r\n");
                            richTextBox_Logs.AppendText(@"���-�� ����� �� ���");
                        }
                    }
                }
                else
                {
                    richTextBox_Logs.AppendText("\r\n");
                    richTextBox_Logs.AppendText(@"�� �� ������� ��� ������� (DS/DSO)");
                }
            }
            else
            {
                richTextBox_Logs.AppendText("\r\n");
                richTextBox_Logs.AppendText(@"�� ��� ������� ������� ��������� ���������!");
            }
        }

        private void radioButton_DS_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_DS.Checked)
            {
                systemType = "DS";
            }
            else
            {
                systemType = null;
            }
        }

        private void radioButton_DSO_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_DSO.Checked)
            {
                systemType = "DSO";
            }
            else
            {
                systemType = null;
            }
        }

        private void richTextBox_Logs_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}