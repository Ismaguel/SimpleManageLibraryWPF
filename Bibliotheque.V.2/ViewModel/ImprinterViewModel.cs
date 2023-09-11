using Bibliotheque.V._2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.V._2.ViewModel
{
    public class ImprinterViewModel: BaseViewModel
    {
        public ImprinterViewModel()
        {
            SelectedItemneedtobeinitialised += ImprinterViewModel_SelectedItemneedtobeinitialised;
            Repository.ItemsAdded += Repository_ItemsAdded;
            Repository.ItemsDeleted += Repository_ItemsDeleted;
        }

        private void Repository_ItemsDeleted(object? sender, DataAccess.RepositoryEventArgs e)
        {
            Imprint.ListImprinter.Remove(e.Item as Imprinter);
        }

        private void Repository_ItemsAdded(object? sender, DataAccess.RepositoryEventArgs e)
        {
            Imprint.ListImprinter.Add(e.Item as Imprinter);
        }

        private void ImprinterViewModel_SelectedItemneedtobeinitialised()
        {
            SelectedItem = new Imprinter();
        }

       
    }
}
