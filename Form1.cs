using System.Windows.Forms;

namespace gena
{
    public partial class Gena : Form
    {
        bool f_open; // ���������� ����� �����
        public Gena()
        {
            InitializeComponent();
        }

        private void btnChooseExcelFile_Click(object sender, EventArgs e)
        {
            //�������� ���� � ��������, ������ �� ����
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //������� ��� ����� �� ����� � ���������� label1
                label1.Text = openFileDialog1.FileName;

                richTextBox_Logs.AppendText("\r\n");
                richTextBox_Logs.AppendText(@"������ ���� " + openFileDialog1.FileName);

                //���������� ������ f_open
                f_open = true;


                //��������� ������-����
                using (IXLWorkbook workbook = new XLWorkbook(openFileDialog1.FileName))
                {
                }

                    //������� ������ ������ StreamReader � ��������� ������ �� �����
                    //StreamReader sr = File.OpenText(openFileDialog1.FileName);

                    //// �������������� ���������� ��� ������ ������ �� �����
                    //string line = null;
                    //line = sr.ReadLine(); // ������ ������ ������

                    //// 6. ���� ������ ����� �� �����, ���� ������ ��� ���, �� line=null
                    //while (line != null)
                    //{
                    //    // 6.1. �������� ������ � richTextBox1
                    //    richTextBox_Logs.AppendText(line);

                    //    // 6.2. �������� ������ �������� ������
                    //    richTextBox_Logs.AppendText("\r\n");

                    //    // 6.3. ������� ��������� ������
                    //    line = sr.ReadLine();
                    //}

                    // 7. ������� ���������� � ������
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