using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.V._2.Model
{
    public class BaseModel : BaseINotifyPropertyChange
    {
        #region Fiels
        private int id;
        private string name;
        private string displayName;
        private int phoneNumber;
        bool _isSelected;
        BaseRepository _repository;
        #endregion

        #region Properties


        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; OnPropertyChanged("DisplayName"); }
        }
        public int PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; OnPropertyChanged("PhoneNumber"); }
        }
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value == _isSelected)
                    return;

                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
        public virtual BaseRepository Repository
        {
            get { return _repository; }
            protected set
            {
                _repository = value;
            }
        }

        public virtual bool IsNew
        {
            get { return !Repository.Contains(this); }
        }

        #endregion

        #region Validation

        public virtual List<string> ValidatedProperties { get; protected set; }

        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }

        protected virtual string GetValidationError(string propertyName)
        {
            if (ValidatedProperties.Contains(propertyName))
                return null;

            string error = null;

            return error;
        }


        #endregion

        #region Constructor
        public BaseModel()
        {

        }
        public BaseModel(BaseRepository i_Repository)
        {
            _repository = i_Repository;
        }
        #endregion
        #region Public Methodes

        /// <summary>
        /// Saves the Model to the repository.  This method is invoked by the SaveCommand.
        /// </summary>
        //public void Save()
        //{
        //    if (!this.IsValid)
        //        throw new InvalidOperationException(LangString.CanNotSave);

        //    if (this.IsNew)
        //        _repository.Add(this);

        //    OnPropertyChanged("DisplayName");
        //}

        /// <summary>
        /// Saves the Model to the repository.  This method is invoked by the SaveCommand.
        /// </summary>
        public void Delete()
        {
            if (_repository.Contains(this))
                _repository.Delete(this);

            OnPropertyChanged("DisplayName");
        }

        /// <summary>
        /// Return true if a searching String is including in the DisplayName
        /// Child classes can set this property to a new value,
        /// or override it to determine the value on-demand.
        /// </summary>
        public virtual bool MatchSearchString(string i_SearchString)
        {
            if (i_SearchString == null)
                return true;

            return (DisplayName.ToLower().Contains(i_SearchString.ToLower()));
        }
        #endregion 
    }
}
