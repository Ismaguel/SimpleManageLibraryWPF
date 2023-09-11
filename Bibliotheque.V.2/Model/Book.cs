using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.V._2.Model
{
    public class Book : BaseModel
    {

        #region Fiels

        private string? title;
        private string? type;
        private string? author;
        private int exemplaire ;
        #endregion
        #region Properties

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged("Title"); }
        }
        public string Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged("Type"); }
        }
        public string Author
        {
            get { return author; }
            set { author = value; OnPropertyChanged("Author"); }
        }
        private string edition;

        public string Edition
        {
            get { return edition; }
            set { edition = value; OnPropertyChanged("Edition"); }
        }

        private int numpage;

        public int Numpage
        {
            get { return numpage; }
            set { numpage = value; OnPropertyChanged("Numpage"); }
        }

        public int Exemplaire
        {
            get { 
                return exemplaire; }
            set { exemplaire = value; OnPropertyChanged("Exemplaire"); }
        }

        public override string ToString()
        {
            return $"{Title} / {Type}";
        }
      

        #endregion
    }
}
