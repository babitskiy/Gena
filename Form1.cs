using Gena.Exceptions;
using Gena.Extensions;

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
            //Открытие окна и проверка, выбран ли файл
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Получаем инфу о директории в которой находится эксель-файл
                DirectoryInfo directoryInfo = new DirectoryInfo(openFileDialog1.FileName);
                var fileExtension = Path.GetExtension(openFileDialog1.FileName);
                var fileName = Path.GetFileName(openFileDialog1.FileName);

                //Вывести имя файла на форме в компоненте label1
                label1.Text = openFileDialog1.FileName;

                addFromNewLine(@"Выбран файл " + fileName);

                //Установить флажок f_open
                f_open = true;

                if (fileExtension == ".xlsx" || fileExtension == ".xls")
                    canStart = true;
                else
                    addFromNewLine(@"Нужно выбрать excel-файл с расширением .xls или .xlsx", Color.Yellow);
                
                //Закрыть соединение с файлом (нужно?)
                //sr.Close();
            }
        }


        private void btnStartGeneration_Click(object sender, EventArgs e)
        {
            if(canStart)
            {
                if(systemType != null)
                {
                    //Получаем инфу о директории в которой находится эксель-файл
                    DirectoryInfo directoryInfo = new DirectoryInfo(openFileDialog1.FileName);
                    var fileExtension = Path.GetExtension(openFileDialog1.FileName);
                    var fileName = Path.GetFileName(openFileDialog1.FileName);
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    var parentFolder = directoryInfo.Parent;

                    var pathToFolderWithLCFiles = parentFolder + "\\" + fileNameWithoutExtension;
                    Directory.CreateDirectory(pathToFolderWithLCFiles);
                    addFromNewLine(@"Создана папка " + fileNameWithoutExtension, Color.Green);

                    try
                    {
                        if (LifeCycleGenerator.GenerateLifeCycle(openFileDialog1.FileName, pathToFolderWithLCFiles, systemType))
                        {
                            addFromNewLine(@"Жц сгенерирован успешно", Color.Green);
                        }
                        else
                            addFromNewLine(@"Что-то пошло не так, обратитесь к разработчику", Color.Red);
                    }
                    catch (UniversalException ex)
                    {
                        addFromNewLine(ex.Message, Color.Red);
                        return;
                    }
                    catch (Exception)
                    {
                        addFromNewLine(@"Что-то пошло не так, обратитесь к разработчику", Color.Red);
                        throw;
                    }
                }
                else
                {
                    addFromNewLine(@"Вы не выбрали тип системы (DS/DSO)", Color.Yellow);
                }
            }
            else
            {
                addFromNewLine(@"Не все правила запуска генерации соблюдены!", Color.Yellow);
            }
        }

        private void radioButton_DS_CheckedChanged(object sender, EventArgs e)
        {
            //при выборе радио-кнопки DS, записываем DS в переменную
            systemType = radioButton_DS.Checked ? "DS" : null;
        }

        private void radioButton_DSO_CheckedChanged(object sender, EventArgs e)
        {
            //при выборе радио-кнопки DSO, записываем DSO в переменную
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