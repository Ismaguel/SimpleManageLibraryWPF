using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Bibliotheque.V._2.Model
{
    public class Imprint : BaseModel
    {
        #region Fiels
        private DateTime _imprintDate = DateTime.Now;
        private DateTime remiseDate ;
        private CheckBox remisOuPas;
        private Imprinter _emprinteur = new Imprinter();
        private Book _book;
        #endregion
        #region Properties

        public DateTime ImprintDate
        {
            get { return _imprintDate; }
            set { _imprintDate = value; OnPropertyChanged("ImprintDate"); }
        }
        public DateTime RemiseDate
        {
            get { return remiseDate; }
            set { remiseDate = value; OnPropertyChanged("RemiseDate"); }
        }

        public CheckBox RemisOuPas
        {
            get { return remisOuPas; }
            set { remisOuPas = value; OnPropertyChanged("RemisOuPas"); }
        }

        public Imprinter Emprinteur
        {
            get { return _emprinteur; }
            set { _emprinteur = value;
                
                OnPropertyChanged("Emprinteur"); }
        }
        public Book Book
        {
            get { return _book; }
            set { _book = value;
                if (Book.Exemplaire > 0)               
                    Book.Exemplaire--;
                else
                    if(Book.Exemplaire == 0)
                    MessageBox.Show("Vous n'avez plus ce type de livre disponible");
                OnPropertyChanged("Book");   
            }
        }
        private static ObservableCollection<Book> listBook = new ObservableCollection<Book>();

        public static ObservableCollection<Book> ListBook
        {
            get { return listBook; }
            set { listBook = value;}
        }
        private static ObservableCollection<Imprinter> listImprinter = new ObservableCollection<Imprinter>();

        public static ObservableCollection<Imprinter> ListImprinter
        {
            get { return listImprinter; }
            set { listImprinter = value; }
        }

        #endregion
    }
}
