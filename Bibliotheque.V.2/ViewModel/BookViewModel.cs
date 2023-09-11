using Bibliotheque.V._2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.V._2.ViewModel
{
    public class BookViewModel: BaseViewModel
    {
        public BookViewModel()
        {
            SelectedItemneedtobeinitialised += BookViewModel_SelectedItemneedtobeinitialised;
            Repository.ItemsAdded += Repository_ItemsAdded;
            Repository.ItemsDeleted += Repository_ItemsDeleted;

        }

        private void Repository_ItemsDeleted(object? sender, DataAccess.RepositoryEventArgs e)
        {
            Imprint.ListBook.Remove(e.Item as Book);

        }

        private void Repository_ItemsAdded(object? sender, DataAccess.RepositoryEventArgs e)
        {
            Imprint.ListBook.Add(e.Item as Book);
        }

        private void BookViewModel_SelectedItemneedtobeinitialised()
        {
            SelectedItem = new Book();
        }
    }
}
