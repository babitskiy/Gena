using System.Windows.Forms;

namespace gena
{
    public partial class Gena : Form
    {
        bool f_open; // определяют выбор файла
        public Gena()
        {
            InitializeComponent();
        }

        private void btnChooseExcelFile_Click(object sender, EventArgs e)
        {
            //Открытие окна и проверка, выбран ли файл
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Вывести имя файла на форме в компоненте label1
                label1.Text = openFileDialog1.FileName;

                richTextBox_Logs.AppendText("\r\n");
                richTextBox_Logs.AppendText(@"Выбран файл " + openFileDialog1.FileName);

                //Установить флажок f_open
                f_open = true;


                //открываем эксель-файл
                using (IXLWorkbook workbook = new XLWorkbook(openFileDialog1.FileName))
                {
                }

                    //Создать объект класса StreamReader и прочитать данные из файла
                    //StreamReader sr = File.OpenText(openFileDialog1.FileName);

                    //// дополнительная переменная для чтения строки из файла
                    //string line = null;
                    //line = sr.ReadLine(); // чтение первой строки

                    //// 6. Цикл чтения строк из файла, если строки уже нет, то line=null
                    //while (line != null)
                    //{
                    //    // 6.1. Добавить строку в richTextBox1
                    //    richTextBox_Logs.AppendText(line);

                    //    // 6.2. Добавить символ перевода строки
                    //    richTextBox_Logs.AppendText("\r\n");

                    //    // 6.3. Считать следующую строку
                    //    line = sr.ReadLine();
                    //}

                    // 7. Закрыть соединение с файлом
                    //sr.Close();
                }
        }

        private void btnStartGeneration_Click(object sender, EventArgs e)
        {

        }

        private void DS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DSO_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox_Logs_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}