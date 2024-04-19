namespace laba10_1_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string b = textBox2.Text;
            string c = textBox3.Text;

            int a_1, b_1, c_1;

            // �������� �� ���������� �������� ������
            if (!int.TryParse(a, out a_1) || !int.TryParse(b, out b_1) || !int.TryParse(c, out c_1))
            {
                MessageBox.Show("����������, ������� ���������� �������� �������� ��� ���� �����.", "������",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ������ ������� ������������
            double sunshine = a_1 + b_1 + c_1;
            double polushine = ((sunshine / 2) * ((sunshine / 2) - a_1) * ((sunshine / 2) - b_1) * ((sunshine / 2) - c_1));

            // �������� �� ����������� ���������� ������������
            if (polushine <= 0)
            {
                MessageBox.Show("���������� ��������� ����������� � ���������� ���������� ������.", "������",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ���������� ������� ������������
            double wind = Math.Sqrt(polushine);

            // ����� �����������
            textBox5.Text = sunshine.ToString();
            textBox4.Text = wind.ToString();
        }

    }
}
