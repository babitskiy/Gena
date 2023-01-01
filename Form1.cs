using Gena.Exceptions;
using Gena.Extensions;

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
        private void addFromNewLine(string msg, Color color)
        {
            richTextBox_Logs.AppendText("\r\n");
            richTextBox_Logs.AppendText(msg, color);
        }

        private void addFromNewLine(string msg)
        {
            richTextBox_Logs.AppendText("\r\n");
            richTextBox_Logs.AppendText(msg);
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

                addFromNewLine(@"������ ���� " + fileName);

                //���������� ������ f_open
                f_open = true;

                if (fileExtension == ".xlsx" || fileExtension == ".xls")
                    canStart = true;
                else
                    addFromNewLine(@"����� ������� excel-���� � ����������� .xls ��� .xlsx", Color.Yellow);
                
                //������� ���������� � ������ (�����?)
                //sr.Close();
            }
        }


        private void btnStartGeneration_Click(object sender, EventArgs e)
        {
            if(canStart)
            {
                if(systemType != null)
                {
                    //�������� ���� � ���������� � ������� ��������� ������-����
                    DirectoryInfo directoryInfo = new DirectoryInfo(openFileDialog1.FileName);
                    var fileExtension = Path.GetExtension(openFileDialog1.FileName);
                    var fileName = Path.GetFileName(openFileDialog1.FileName);
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    var parentFolder = directoryInfo.Parent;

                    var pathToFolderWithLCFiles = parentFolder + "\\" + fileNameWithoutExtension;
                    Directory.CreateDirectory(pathToFolderWithLCFiles);
                    addFromNewLine(@"������� ����� " + fileNameWithoutExtension, Color.Green);

                    try
                    {
                        if (LifeCycleGenerator.GenerateLifeCycle(openFileDialog1.FileName, pathToFolderWithLCFiles, systemType))
                        {
                            addFromNewLine(@"�� ������������ �������", Color.Green);
                        }
                        else
                            addFromNewLine(@"���-�� ����� �� ���, ���������� � ������������", Color.Red);
                    }
                    catch (UniversalException ex)
                    {
                        addFromNewLine(ex.Message, Color.Red);
                        return;
                    }
                    catch (Exception)
                    {
                        addFromNewLine(@"���-�� ����� �� ���, ���������� � ������������", Color.Red);
                        throw;
                    }
                }
                else
                {
                    addFromNewLine(@"�� �� ������� ��� ������� (DS/DSO)", Color.Yellow);
                }
            }
            else
            {
                addFromNewLine(@"�� ��� ������� ������� ��������� ���������!", Color.Yellow);
            }
        }

        private void radioButton_DS_CheckedChanged(object sender, EventArgs e)
        {
            //��� ������ �����-������ DS, ���������� DS � ����������
            systemType = radioButton_DS.Checked ? "DS" : null;
        }

        private void radioButton_DSO_CheckedChanged(object sender, EventArgs e)
        {
            //��� ������ �����-������ DSO, ���������� DSO � ����������
            systemType = radioButton_DSO.Checked ? "DSO" : null;
        }

        private void richTextBox_Logs_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}