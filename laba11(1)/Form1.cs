namespace laba11_1_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 100;
            trackBar1.LargeChange = 1;
            trackBar1.SmallChange = 1;

            double n = trackBar1.Value;

            double sumFormula = ((n+1) * (2*n+1) * (2*n+3))/3;

            double sum = 0;
            for (int i = 1; i <= n+1; i++)
            {
                int oddNumber = 2 * i - 1; // �������� �����
                int square = oddNumber * oddNumber; // ������� �����
                sum += square; // ��������� ������� ����� � �����
            }

            label1.Text = $"n = {n}";
            label2.Text = $"����� �� �������: {sumFormula}";
            label3.Text = $"����� � �����: {sum}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

