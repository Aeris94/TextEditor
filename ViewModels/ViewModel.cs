using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using TextEditor.Model;

namespace TextEditor.ViewModels
{
    class ViewModel
    {
        private ICommand _New = new RelayCommand(File.NewFile);
        private ICommand _Open = new RelayCommand(File.OpenFile);
        private ICommand _Save = new RelayCommand(File.SaveFile);
        private ICommand _Exit = new RelayCommand(File.Exit);

        public static string FileName
        {
            get { return File.fileName; }
        }


        public ICommand New
        {
            get { return _New; }
        }

        public ICommand Open
        {
            get { return _Open; }
        }

        public ICommand Save
        {
            get { return _Save; }
        }

        public ICommand Exit
        {
            get { return _Exit; }
        }

        public static List<FontFamily> FontNames
        {
            get { return Edit.FontNames; }
        }

        public static List<double> FontSize
        {
            get { return Edit.FontSize; }
        }
    }
}
