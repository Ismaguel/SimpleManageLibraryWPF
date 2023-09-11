using Bibliotheque.V._2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.V._2.ViewModel
{
    public class ImprintViewModel:BaseViewModel
    {
        Book book = new Book();

        public ImprintViewModel()
        {
            SelectedItemneedtobeinitialised += ImprintViewModel_SelectedItemneedtobeinitialised;
        }
      
        private void ImprintViewModel_SelectedItemneedtobeinitialised()
        {
            SelectedItem = new Imprint();
        }
        //public  override bool canSave()
        //{
        //    if (book.Exemplaire < 0)
        //    return false;
        //}
    }
}
