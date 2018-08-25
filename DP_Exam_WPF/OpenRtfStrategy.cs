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
    public class OpenRtfStrategy : IOpenStrategy
    {
        private TabControl tabControl;
        private string filename;

        public OpenRtfStrategy(TabControl products, string filename)
        {
            this.tabControl = products;
            this.filename = filename;
        }

        public void Open()
        {
            RichTextBox richTextBox = new RichTextBox();
            //добавл текста в RichTetxBox
            richTextBox.Selection.Load(new FileStream(filename, FileMode.Open), DataFormats.Rtf);
            richTextBox.Width = 500;
            richTextBox.Height = 300;

            // добавление вкладки
            tabControl.Items.Add(new TabItem
            {
                Header = new TextBlock { Text = filename }, // установка заголовка вкладки
                Content = richTextBox,

            });
        }
    }
}
