namespace laba10_2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string numStr = textBox1.Text;
            int n;
            if (int.TryParse(numStr, out n) && n >= 1)
            {
                double sum = 0;
                for (double i = 1; i <= n + 2; i = i + 2)
                {
                    sum += Math.Pow(i, 3);
                }
                textBox2.Text = sum.ToString();
            }
            else
            {
                MessageBox.Show("¬ведите натуральное число.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string numStr = textBox1.Text;
            int n;
            if (int.TryParse(numStr, out n) && n >= 1)
            {
                double result = n * n * (2 * n * n - 1);
                textBox2.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("¬ведите натуральное число.");
            }
        }

    }
}
