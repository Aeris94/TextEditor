using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace TextEditor.Model
{
    class File
    {
        private static string _fileName = "Edytor Tekstu";

        public static string fileName
        {
            get { return _fileName; }
        }
      
        private static int DoYouWantToSave(object document)
        {
            MessageBoxResult result = MessageBox.Show("Czy chesz zapisać?", "Edytor Tekstu", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    SaveFile(document); return 1;
                case MessageBoxResult.No:
                    ((FlowDocument)document).Blocks.Clear(); return 1;
                case MessageBoxResult.Cancel: return -1;
            }
            return 1;
        }

        public static void NewFile(object document)
        {
            string text = new TextRange(((FlowDocument)document).ContentStart, ((FlowDocument)document).ContentEnd).Text;
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }
            else
            {
                DoYouWantToSave(document);
            }
        }


        public static void OpenFile(object document)
        {
            int i = DoYouWantToSave(document);
            if (i == -1)
                return;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";           
            open.RestoreDirectory = false;
            if (open.ShowDialog() == true)
            {
                try
                {
                    using (FileStream stream = new FileStream(open.FileName, FileMode.Open))
                    {
                        TextRange range = new TextRange(((FlowDocument)document).ContentStart, ((FlowDocument)document).ContentEnd);
                        range.Load(stream, DataFormats.Rtf);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie można otworzyć pliku.");
                }
            }
        }


        public static void SaveFile(object document)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            save.RestoreDirectory = false;
           
            if (save.ShowDialog() == true)
            {
                try
                {
                    using (FileStream stream = new FileStream(save.FileName, FileMode.Create))
                    {
                        TextRange range = new TextRange(((FlowDocument)document).ContentStart, ((FlowDocument)document).ContentEnd);
                        range.Save(stream, DataFormats.Rtf);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie można zpisać pliku.");
                }
            }
        }


        public static void Exit(object document)
        {
            string text = new TextRange(((FlowDocument)document).ContentStart, ((FlowDocument)document).ContentEnd).Text;
            int i = 0;

            if (!string.IsNullOrWhiteSpace(text))
                i = DoYouWantToSave(document);

            ///Mistake - it will shoutdown even if i clicked annuluj!!!!!!
            if(i != -1)
            Application.Current.Shutdown();
        }
    }
}
