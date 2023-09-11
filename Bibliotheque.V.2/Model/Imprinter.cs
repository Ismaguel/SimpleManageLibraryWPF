using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.V._2.Model
{
    public class Imprinter : BaseModel
    {
        #region Fiels
        private string displayname;
        private string lastName;
        private string firstName;
        private DateTime datedeNaissance;
        private string profil;


        #endregion

        #region Properties

        public string Displayname
        {
            get { return displayname; }
            set { displayname = value; OnPropertyChanged("Displayname"); }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged("LastName"); }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged("FirstName"); }
        }

        public string Profil
        {
            get { return profil; }
            set { profil = value; OnPropertyChanged("Profil"); }
        }
        public DateTime DatedeNaissance
        {
            get { return datedeNaissance; }
            set { datedeNaissance = value; OnPropertyChanged("DatedeNaissance"); }
        }
        private ObservableCollection<Imprint> imprints;

        public ObservableCollection<Imprint> Imprints
        {
            get { return imprints; }
            set { imprints = value; }
        }



        public override string ToString()
        {
            return $"{Id} / {LastName} / {FirstName}";
        }
        #endregion
    }
}
