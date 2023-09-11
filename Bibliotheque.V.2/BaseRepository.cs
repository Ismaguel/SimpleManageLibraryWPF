using Bibliotheque.V._2.DataAccess;
using Bibliotheque.V._2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.V._2
{
    public class BaseRepository
    {
        #region Fiels
        List<BaseModel> _items;
        private List<Filter> _filters;

        public event EventHandler<RepositoryEventArgs> ItemsAdded;
        public event EventHandler<RepositoryEventArgs> ItemsDeleted;
        public event EventHandler<RepositoryEventArgs> FilterAdded;
        public event EventHandler<RepositoryEventArgs> FilterDeleted;

        #endregion

        #region Properties
        public List<BaseModel> Items
        {
            get
            {
                if (_items == null)
                    _items = new List<BaseModel>();

                return _items;
            }
            protected set
            {
                if (value == _items)
                    return;

                _items = value;
            }
        }

        public List<Filter> Filters
        {
            get
            {
                if (_filters == null)
                    _filters = new List<Filter>();
                return _filters;
            }
            protected set
            {
                if (value == _filters)
                    return;
                _filters = value;
            }
        }


        #endregion

        public BaseRepository()
        {
            //LoadingProgression = new ProcessProgression() { Errors = new ObservableCollection<string>() };

        }
        public BaseRepository(string[] i_DataPath)
        {
            LoadItems(i_DataPath);
        }
        public void Add(BaseModel i_item)
        {
            if (i_item == null)
                throw new ArgumentNullException("i_item");

            if (!Contains(i_item))
            {
                Items.Add(i_item);

                i_item.Id = Items.Count;

                this.ItemsAdded?.Invoke(this, new RepositoryEventArgs(i_item));
            }
        }
        public void AddFilter(Filter i_filter)
        {
            if (i_filter == null)
                throw new ArgumentNullException("i_item");
            if (!Contains(i_filter))
            {
                Filters.Add(i_filter);
                this.FilterAdded?.Invoke(this, new RepositoryEventArgs(i_filter));
            }
        }
        public void Delete(BaseModel i_item)
        {
            if (i_item == null)
                throw new ArgumentNullException("i_item");

            if (Contains(i_item))
            {
                Items.Remove(i_item);

                this.ItemsDeleted?.Invoke(this, new RepositoryEventArgs(i_item));
            }
        }
        public void DeleteFilter(Filter i_filter)
        {
            if (i_filter == null)
                throw new ArgumentNullException("i_filter");
            if (ContainsFilter(i_filter))
            {
                Filters.Remove(i_filter);
                this.FilterDeleted?.Invoke(this, new RepositoryEventArgs(i_filter));
            }
        }
        public virtual bool Contains(BaseModel i_item)
        {
            return (Items.Find(e => e.Id == i_item.Id) != default);
        }
        public virtual bool ContainsFilter(Filter i_filter)
        {
            return (Filters.Find(f => f.DisplayName == i_filter.DisplayName) != default);
        }
        public List<BaseModel> GetItems()
        {
            return GetItems();
        }
        public List<BaseModel> GetItems(Filter i_filter)
        {
            return null;
        }
        public List<BaseModel> GetItems(Filter i_filter, string i_SearchText)
        {
            if (Items == null || Items.Count == 0)
                return null;
            List<BaseModel> MatchingItems = new List<BaseModel>();
            if (i_filter == null || i_filter.CompareValue == null)
                return new List<BaseModel>(MatchingItems);
            foreach (string key in i_filter.CompareValue?.Keys)
            {
                MatchingItems.RemoveAll(it => !it.GetType().GetProperty(key).GetValue(it).Equals(i_filter.CompareValue[key]));
            }
            return MatchingItems;
        }
        public List<Filter> GetFilters()
        {
            return Filters;
        }
        public void SetItems(List<BaseModel> i_item)
        {
            foreach (BaseModel b in i_item)
            {
                this.Add(b);
            }
        }

        public virtual void LoadItems(string[] i_DataPaths)
        {

        }
        public virtual void LoadItems()
        {

        }
        public virtual BaseModel NewItem()
        {
            return null;


        }
    }
}
