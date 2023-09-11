using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.V._2
{
    public class BaseINotifyPropertyChange : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string PropertyName)
        {
            if (PropertyName != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
