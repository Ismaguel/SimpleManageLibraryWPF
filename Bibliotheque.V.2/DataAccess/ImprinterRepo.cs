using Bibliotheque.V._2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.V._2.DataAccess
{
    public class ImprinterRepo: BaseRepository
    {

        public override BaseModel NewItem()
        {
            return new Imprinter();
        }
    }
}
