namespace Ekz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программу создал студент группы ПКсп-120\nФадеев Даниил Сергеевич\nВариант 15");
        }

        bool flag = false;

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        int c = 0;

        private void октрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.AllowWebBrowserDrop = false;
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "TextFiles(*.html)|*.html|AllFiles(*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;

                string[] filename = openFileDialog1.FileName.Split('\\');
                string nameFile = filename[filename.Length - 1];
                if (!flag)
                {
                    this.Height += 100;
                    flag = true;
                }
                if (nameFile == "1.html")
                {
                    c = 1;
                    webBrowser1.Navigate(openFileDialog1.FileName);
                }

                else
                {
                    c = 0;
                    this.Height -= 100;
                    MessageBox.Show($"Решение отсутсвует для файла {nameFile}. Выберите файл 1.html");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c == 1)
            {
                function();
            }
        }

        void function()
        {
            if (!double.TryParse(textBox1.Text, out double x))
            {
                MessageBox.Show("Некорректный ввод данных. Повторите попытку ещё раз.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(textBox2.Text, out double y))
            {
                MessageBox.Show("Некорректный ввод данных. Повторите попытку ещё раз.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (y > 5 || y < 2 || x < -2 || x > 5 || (x > 3 && y > 3))
            {
                MessageBox.Show("Точка находится вне многоугольника");
                toolStripStatusLabel1.Text = "Точка находится вне многоугольника";
            }
            else if (y < 5 && y > 2 && x > -2 && x < 3 || x < 5 && x >= 3  && y > 2 && y < 3)
             {
                 MessageBox.Show("Точка находится внутри многоугольника");
                 toolStripStatusLabel1.Text = "Точка находится внутри многоугольника";
             }
            else
            {
                MessageBox.Show("Точка находится на границе многоугольника");
                toolStripStatusLabel1.Text = "Точка находится на границе многоугольника";
            }
        }
    }
}