using Bibliotheque.V._2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.V._2.DataAccess
{
    public class RepositoryEventArgs : EventArgs
    {
        public Object Item { get; private set; }

        public RepositoryEventArgs(BaseModel i_item)
        {
            this.Item = i_item;
        }

    }
}
