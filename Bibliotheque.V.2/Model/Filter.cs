using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.V._2.Model
{
    public class Filter : BaseModel
    {
        public Dictionary<string, object> CompareValue { get; private set; }

        public Filter()
        {

        }
        public Filter(string i_DisplayName, Dictionary<string, object> i_CompareValue)
        {
            this.CompareValue = i_CompareValue;
            base.DisplayName = i_DisplayName;
        }

        public bool HasFilterPropertyOptions(string i_PropertyName)
        {
            return (FilteringPropertyOptions(i_PropertyName) != null);
        }
        public List<object> FilteringPropertyOptions(string i_PropertyName)
        {
            return null;
        }
    }
}
