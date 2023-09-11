using Bibliotheque.V._2.Model;

namespace Bibliotheque.V._2.DataAccess
{
    public class BookRepo : BaseRepository
    {
        public override bool Contains(BaseModel i_item)
        {
            return (base.Items.Find(e => ((Book)e).Id == ((Book)i_item).Id) != null);
        }
    }
}
