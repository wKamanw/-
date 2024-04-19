using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Laba11_2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
           public class Price
        {
            public string FullName { get; set; }
            public string PhoneNumber { get; set; }

            public override string ToString()
            {
                return $"{FullName}; {PhoneNumber}���";
            }
        }
        List<Price> notes = new List<Price>();
        private void button2_Click_1(object sender, EventArgs e)
        {
            Random random = new Random();

            List<string> firstNames = new List<string> { "������", "���", "������", "�����", "����", "��������", "�����", "��������", "������", "�������" };
            List<string> lastNames = new List<string> { "�����", "���������", "������", "����", "���� �����", "�����", "�����", "����", "����", " ��������" };

            // ������� ������ notes ����� ���������� ����� �������
            notes.Clear();

            // ������� ������ listBox1 ����� ����������� ����� ���������
            listBox1.Items.Clear();

            for (int i = 0; i < 10; i++)
            {
                Price note = new Price
                {
                    FullName = $"{firstNames[random.Next(firstNames.Count)]} {lastNames[random.Next(lastNames.Count)]}",
                    PhoneNumber = random.Next(100, 300).ToString(),
                };
                notes.Add(note);

                // ���������� ����� ������ � listBox1
                listBox1.Items.Add(note);
            }

            // ������ ��������������� ������� � ����
            using (StreamWriter writer = new StreamWriter("spisok.txt"))
            {
                foreach (var note in notes)
                {
                    writer.WriteLine($"{note.FullName},{note.PhoneNumber},");
                }
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                // ������� ����� "spisok.txt"
                File.WriteAllText("spisok.txt", string.Empty);

                // ������� ������ listBox1
                listBox1.Items.Clear();

                MessageBox.Show("������ ������� ������ �� �����.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("������ ��� ������� �����: " + ex.Message);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // ���������, ��� listBox1 �� ������
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("������ ����. ����������, ������� ������������ ������.");
                return;
            }

            var sortedNotes = notes.OrderBy(note => note.FullName.Split(' ')[1]).ToList();

            listBox2.Items.Clear(); // ������� listBox2 ����� ����������� ��������������� ���������

            foreach (var note in sortedNotes)
            {
                listBox2.Items.Add($"{note.FullName} - {note.PhoneNumber} ���");
            }
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            string searchLastName = textBox1.Text;
            var results = notes.Where(x => x.FullName.IndexOf(searchLastName, 0, StringComparison.OrdinalIgnoreCase) != -1).ToList();

            if (results.Any())
            {
                // ������� ������ ��� �������� ������ �����������
                StringBuilder resultMessage = new StringBuilder();

                // ��������� ������ ��������� � ������
                foreach (var result in results)
                {
                    resultMessage.AppendLine($"��, �������! {result.FullName} - {result.PhoneNumber}");
                }

                // ������� ������ ����������� � ��������� MessageBox
                MessageBox.Show(resultMessage.ToString());
            }
            else
            {
                MessageBox.Show("��� ������ ��������.");
            }
        }

    }
}