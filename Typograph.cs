using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typograph
{
    public partial class Typograph : Form
    {
        public Typograph()
        {
            InitializeComponent();
        }

        private void оттипографитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Вы ничего не ввели!");
                return;
            }
            var regex = new Regex("\\s+");
            richTextBox1.Text = regex.Replace(richTextBox1.Text, " ");

            regex = new Regex("(\\+-)|(-\\+)|(\\(\\+,-\\))");
            richTextBox1.Text = regex.Replace(richTextBox1.Text, "±");

            regex = new Regex("\\s+(?=[.,?!:;])"); 

            richTextBox1.Text = regex.Replace(richTextBox1.Text, "");

            regex = new Regex("(?<=[,.!?;:])(?=\\w)");

            richTextBox1.Text = regex.Replace(richTextBox1.Text, " ");

            regex = new Regex("\\s*—\\s*");
            richTextBox1.Text = regex.Replace(richTextBox1.Text, "\u00a0— ");

            regex = new Regex("\\s*-\\s*");
            richTextBox1.Text = regex.Replace(richTextBox1.Text, "-");

            regex = new Regex("\\.{2,}");
            richTextBox1.Text = regex.Replace(richTextBox1.Text, "...");

            richTextBox1.Text = richTextBox1.Text.Replace("ё", "е");

            richTextBox1.Text = richTextBox1.Text.Trim();




        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Это типограф? Да, это типограф! Версия секретный ЗОВ.\nПравило 1) Не больше 1 пробела подряд.\r\nПравило 2) Все знаки препинания пишутся слева слитно со словом, а справа отбиваются\r\nпробелом.\r\nПравило 3) Дефис пробелами не отбивается.\r\nПравило 4) С обоих сторон от тире ставится пробел.\r\nПравило 5) Многоточие заменяется на символ троеточия.\r\nПравило 6) Символ «плюс-минус» задаётся так: ±\r\nПравило 7) Каждая буква ё меняется на е.\r\nСекретное правило ZOV : При нажатии на секретную кнопку каждая буква меняется на сво.");
        }

        private void zOVSVOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Вы ничего не ввели!");
                return;
            }

            var regex = new Regex("\\w", RegexOptions.IgnoreCase);

            richTextBox1.Text = regex.Replace(richTextBox1.Text, "сво ");
            
        }
    }
}
