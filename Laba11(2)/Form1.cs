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
                return $"{FullName}; {PhoneNumber}Руб";
            }
        }
        List<Price> notes = new List<Price>();
        private void button2_Click_1(object sender, EventArgs e)
        {
            Random random = new Random();

            List<string> firstNames = new List<string> { "Молоко", "Сок", "Гречка", "Арубз", "Кофе", "Помидоры", "Сахар", "Картошка", "Курица", "Булочка" };
            List<string> lastNames = new List<string> { "Лента", "Пятерочка", "Магнит", "Ярче", "фикс прайс", "Чижык", "Метро", "Спар", "Икея", " ВкусВилл" };

            // Очистка списка notes перед генерацией новых записей
            notes.Clear();

            // Очистка списка listBox1 перед добавлением новых элементов
            listBox1.Items.Clear();

            for (int i = 0; i < 10; i++)
            {
                Price note = new Price
                {
                    FullName = $"{firstNames[random.Next(firstNames.Count)]} {lastNames[random.Next(lastNames.Count)]}",
                    PhoneNumber = random.Next(100, 300).ToString(),
                };
                notes.Add(note);

                // Добавление новой записи в listBox1
                listBox1.Items.Add(note);
            }

            // Запись сгенерированных записей в файл
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
                // Очистка файла "spisok.txt"
                File.WriteAllText("spisok.txt", string.Empty);

                // Очистка списка listBox1
                listBox1.Items.Clear();

                MessageBox.Show("Список успешно очищен из файла.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при очистке файла: " + ex.Message);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // Проверяем, что listBox1 не пустой
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Список пуст. Пожалуйста, сначала сгенерируйте данные.");
                return;
            }

            var sortedNotes = notes.OrderBy(note => note.FullName.Split(' ')[1]).ToList();

            listBox2.Items.Clear(); // Очищаем listBox2 перед добавлением отсортированных элементов

            foreach (var note in sortedNotes)
            {
                listBox2.Items.Add($"{note.FullName} - {note.PhoneNumber} Руб");
            }
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            string searchLastName = textBox1.Text;
            var results = notes.Where(x => x.FullName.IndexOf(searchLastName, 0, StringComparison.OrdinalIgnoreCase) != -1).ToList();

            if (results.Any())
            {
                // Создаем строку для хранения списка результатов
                StringBuilder resultMessage = new StringBuilder();

                // Добавляем каждый результат в строку
                foreach (var result in results)
                {
                    resultMessage.AppendLine($"Оп, нашелся! {result.FullName} - {result.PhoneNumber}");
                }

                // Выводим список результатов в сообщении MessageBox
                MessageBox.Show(resultMessage.ToString());
            }
            else
            {
                MessageBox.Show("Нет такого магазина.");
            }
        }

    }
}