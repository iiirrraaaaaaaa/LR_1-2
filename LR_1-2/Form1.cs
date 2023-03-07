using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR_1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void selectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {


                string[] words = textBox1.Text.Split(' ');


                string fileExtension = Path.GetExtension(openFileDialog.FileName);
                if (fileExtension == ".txt")
                {
                    string text = File.ReadAllText(openFileDialog.FileName);

                    // Замінити всі слова зі списку на відповідні варіанти із квадратними дужками
                    foreach (string word in words)
                    {
                        string pattern = "\\b" + Regex.Escape(word) + "\\b"; // шаблон для знаходження слова
                        string replacement = $"[{word}]"; // заміна слова на його відповідний варіант із квадратними дужками
                        text = Regex.Replace(text, pattern, replacement);
                    }

                    /*Запис зміненого вмісту у той же файл
                    File.WriteAllText(openFileDialog.FileName, text);*/
                    
                    string outputFileName = Path.ChangeExtension(openFileDialog.FileName, ".tmp");
                    File.WriteAllText(outputFileName, text);

                }
            }

        }
    }
}
