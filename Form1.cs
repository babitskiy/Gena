using ClosedXML.Excel;
using System.Windows.Forms;

namespace Gena
{
    public partial class Gena : Form
    {
        bool f_open; //определяют выбор файла
        bool canStart = false; //определяет можно ли запускать генерацию
        string? systemType = null; //определяет тип системы DS/DSO

        public Gena()
        {
            InitializeComponent();
        }

        private void btnChooseExcelFile_Click(object sender, EventArgs e)
        {
            //Открытие окна и проверка, выбран ли файл
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Получаем инфу о директории в которой находится эксель-файл
                DirectoryInfo directoryInfo = new DirectoryInfo(openFileDialog1.FileName);
                var fileExtension = Path.GetExtension(openFileDialog1.FileName);
                var fileName = Path.GetFileName(openFileDialog1.FileName);

                //Вывести имя файла на форме в компоненте label1
                label1.Text = openFileDialog1.FileName;

                richTextBox_Logs.AppendText("\r\n");
                richTextBox_Logs.AppendText(@"Выбран файл " + fileName);

                //Установить флажок f_open
                f_open = true;

                if (fileExtension == ".xlsx" || fileExtension == ".xls")
                {
                    canStart = true;
                }
                else
                {
                    richTextBox_Logs.AppendText("\r\n");
                    richTextBox_Logs.AppendText(@"Нужно выбрать excel-файл с расширением .xls или .xlsx");
                }
                // 7. Закрыть соединение с файлом
                //sr.Close();
            }
        }

        private void btnStartGeneration_Click(object sender, EventArgs e)
        {
            if(canStart)
            {
                //Получаем инфу о директории в которой находится эксель-файл
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
                        richTextBox_Logs.AppendText(@"Создана папка " + "xmlFiles");

                    }
                    else if (systemType == "DSO")
                    {
                        var pathToFolderWithJSONFiles = parentFolder + "\\jsonFiles\\";
                        Directory.CreateDirectory(pathToFolderWithJSONFiles);
                        richTextBox_Logs.AppendText("\r\n");
                        richTextBox_Logs.AppendText(@"Создана папка " + "jsonFiles");
                        if(LifeCycleGenerator.GenerateLifeCycle(openFileDialog1.FileName, pathToFolderWithJSONFiles))
                        {
                            richTextBox_Logs.AppendText("\r\n");
                            richTextBox_Logs.AppendText(@"Жц сгенерирован успешно");
                        }
                        else
                        {
                            richTextBox_Logs.AppendText("\r\n");
                            richTextBox_Logs.AppendText(@"Что-то пошло не так");
                        }
                    }
                }
                else
                {
                    richTextBox_Logs.AppendText("\r\n");
                    richTextBox_Logs.AppendText(@"Вы не выбрали тип системы (DS/DSO)");
                }
            }
            else
            {
                richTextBox_Logs.AppendText("\r\n");
                richTextBox_Logs.AppendText(@"Не все правила запуска генерации соблюдены!");
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