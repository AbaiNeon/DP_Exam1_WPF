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
    public class SaveTxtStrategy : ISaveStrategy
    {
        private string _name;
        private RichTextBox _richTB;

        public SaveTxtStrategy(string name, RichTextBox richTB)
        {
            this._name = name;
            this._richTB = richTB;
        }

        public void Save()
        {
            FileStream fStream = new FileStream(_name, FileMode.Create);
            TextRange range = new TextRange(_richTB.Document.ContentStart, _richTB.Document.ContentEnd);

            range.Save(fStream, DataFormats.Text);

            fStream.Close();
        }
    }
}
