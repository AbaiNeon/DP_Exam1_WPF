using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace DP_Exam_WPF
{
    public class OpenTxtStrategy : IOpenStrategy
    {
        public TabControl TabControl { get; private set; }
        public string Filename { get; set; }

        //передаю TabControl для работы с UI в этом классе
        public OpenTxtStrategy(TabControl control, string filename)
        {
            TabControl = control;
            Filename = filename;
        }

        public void Open()
        {
            string contents = File.ReadAllText(Filename);

            RichTextBox richTextBox = new RichTextBox();
            //добавл текста в RichTetxBox
            richTextBox.Document.Blocks.Clear();
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(contents)));
            richTextBox.Width = 500;
            richTextBox.Height = 300;

            // добавление вкладки
            TabControl.Items.Add(new TabItem
            {
                Header = new TextBlock { Text = Filename }, // установка заголовка вкладки
                Content = richTextBox,

            });
        }
    }
}
