using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DP_Exam_WPF
{
    public partial class MainWindow : Window
    {
        public int tabsCount = 0;
        public List<RichTextBox> richTextList = new List<RichTextBox>();

        public MainWindow()
        {
            InitializeComponent();
        }

        //Новая вкладка
        private void NewTabItem_Click(object sender, RoutedEventArgs e)
        {
            RichTextBox richTextBox = new RichTextBox();
            //добавл текста в RichTetxBox
            richTextBox.Document.Blocks.Clear();
            richTextBox.Document.Blocks.Add(new Paragraph(new Run("")));
            richTextBox.Width = 500;
            richTextBox.Height = 300;

            // добавление вкладки
            products.Items.Add(new TabItem
            {
                Header = new TextBlock { Text = "New tab" }, // установка заголовка вкладки
                Content = richTextBox,

            });
        }

        //Открыть текстовый файл
        private void OpenItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "*.txt";
            dlg.Filter = "All files (*.*)|*.*|TXT|*.txt|RTF|*.rtf";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                //берем расширение файла
                string ext = filename.Split(".".ToCharArray())[1];

                //выбираем стратегии
                if (ext == "txt")
                {
                    //передаю TabControl и filename
                    OpenContext openContext = new OpenContext(new OpenTxtStrategy(products, filename));
                    openContext.Open();
                }
                else if (ext == "rtf")
                {
                    OpenContext openContext = new OpenContext(new OpenRtfStrategy(products, filename));
                    openContext.Open();
                }
            }
        }

        //Сохранить в файл
        private void SaveItem_Click(object sender, RoutedEventArgs e)
        {
            RichTextBox richTB = (RichTextBox)products.SelectedContent;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.FileName = "myText";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            Nullable<bool> result = saveFileDialog.ShowDialog();

            if (result == true)
            {
                string name = saveFileDialog.SafeFileName;

                //расширение
                string ext = name.Split(".".ToCharArray())[1];

                if (ext == "txt")
                {
                    SaveContext saveContext = new SaveContext(new SaveTxtStrategy(name, richTB));
                    saveContext.Save();
                }
                else if (ext == "rtf")
                {
                    SaveContext saveContext = new SaveContext(new SaveRtfStrategy(name, richTB));
                    saveContext.Save();
                }
                else
                {
                    //другой формат
                }
                
            }
            
        }

        private void CloseItem_Click(object sender, RoutedEventArgs e)
        {
            products.Items.RemoveAt(products.SelectedIndex);
        }
    }
}
