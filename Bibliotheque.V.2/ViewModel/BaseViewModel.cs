using Bibliotheque.V._2.Command;
using Bibliotheque.V._2.LookUp;
using Bibliotheque.V._2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bibliotheque.V._2.Model.Constantes;
using System.Windows;
using System.Windows.Input;

namespace Bibliotheque.V._2.ViewModel
{
    public class BaseViewModel: BaseINotifyPropertyChange
    {
  #region Fiels
        private Visibility _configuratorState = Visibility.Collapsed;
        private ICommand _closeConfiguratorState;
        private CommandViewModel _createCommand;
        private CommandViewModel _editCommand;
        private CommandViewModel _deleteCommand;
        private CommandViewModel _saveCommand;
        protected delegate void delegateofReset();
        protected event delegateofReset eventReset;
        protected delegate void Delegateofselectediteminitialisation();
        protected event Delegateofselectediteminitialisation SelectedItemneedtobeinitialised;
        private BaseRepository _repository;
  #endregion

        public BaseViewModel()
        {
            Repository.ItemsAdded += Repository_ItemsAdded;
            Repository.ItemsDeleted += Repository_ItemsDeleted;
        }

        private void Repository_ItemsDeleted(object? sender, DataAccess.RepositoryEventArgs e)
        {
            Items.Remove(e.Item as BaseModel);
        }

        private void Repository_ItemsAdded(object sender, DataAccess.RepositoryEventArgs e)
        {
            Items.Add(e.Item as BaseModel);
        }


        public Visibility ConfiguratorState
        {
            get { return _configuratorState; }
            set
            {
                _configuratorState = value;
                OnPropertyChanged("ConfiguratorState");
            }
        }
        private ObservableCollection<Options> type = new ObservableCollection<Options>()
        {    Options.ANGLAIS
            , Options.ARABE
            ,Options.CHIMIE
            , Options.EF
            , Options.FRANCAIS
            , Options.GEOGRAPHIE
            , Options.HISTOIRE
            , Options.INFORMATIQUE
            , Options.MATHS
            , Options.PHYSIQUE
            , Options.SVT
        };


        public ObservableCollection<Options> Type
        {
            get { return type; }
            set { type = value; }
        }
        private ObservableCollection<Options> profil = new ObservableCollection<Options>() {
        Options.Eleve
        ,Options.Enseignant
        ,Options.Etudiant
        ,Options.Personnel
        };

        public ObservableCollection<Options> Profil
        {
            get { return profil; }
            set { profil = value; }
        }

        #region Listes

        private ObservableCollection<BaseModel> items = new ObservableCollection<BaseModel>();

        public ObservableCollection<BaseModel> Items
        {
            get { return items; }
            set { items = value; }
        }

        //private ObservableCollection<Book> listBook = new ObservableCollection<Book>();

        //public ObservableCollection<Book> ListBook
        //{
        //    get { return listBook; }
        //    set { listBook = value; }
        //}
        //private ObservableCollection<Imprint> listImprint = new ObservableCollection<Imprint>();

        //public ObservableCollection<Imprint> ListImprint
        //{
        //    get { return listImprint; }
        //    set { listImprint = value; }
        ///}

        #endregion

        private BaseModel _selectedItem;
        public BaseModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public BaseRepository Repository
        {
            get
            {
                if (_repository == null)
                    _repository = new BaseRepository();
                return _repository;
            }

            protected set { _repository = value; }
        }

        //private Book _book = new Book();
        //public Book _Book
        //{
        //    get { return _book; }
        //    set { _book = value; OnPropertyChanged("_Book"); }
        //}

        //private Imprint _imprint = new Imprint();
        //public Imprint _Imprint
        //{
        //    get { return _imprint; }
        //    set { _imprint = value; OnPropertyChanged("_Imprint"); }
        //}

        #region MenuItem DataContex
        public CommandViewModel CreateCommand
        {
            get
            {
                if (_createCommand == null)
                {
                    _createCommand = new CommandViewModel(CreateCommandDisplayName
                        , new RelayCommand(p => { InitialiseSelecteditem(); Create(); })
                        , System.Windows.Media.Geometry.Parse(IconData.CreateIcon)
                        );
                }
                return _createCommand;
            }
        }

        public CommandViewModel EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new CommandViewModel(EditCommandDisplayName
                        , new RelayCommand(param => Edit(),
                                         param => SelectedItem != null)
                        , System.Windows.Media.Geometry.Parse(IconData.EditIcon)
                        ) ;
                }
                return _editCommand;
            }
        }

        public  CommandViewModel SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new CommandViewModel(SaveCommandDisplayName
                        , new RelayCommand(p => this.save(), null)
                        , System.Windows.Media.Geometry.Parse(IconData.Save)
                        ) ;
                }
                return _saveCommand;
            }

        }
        public CommandViewModel DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new CommandViewModel(DeleteCommandDisplayName
                        , new RelayCommand(p => this.delete()
                                        , p => (SelectedItem != null))
                        , System.Windows.Media.Geometry.Parse(IconData.DeleteIcon)
                        );
                }
                return _deleteCommand;
            }
        }



        private CommandViewModel _resetCommand;

        public CommandViewModel ResetCommand
        {
            get
            {
                if (_resetCommand == null)
                    _resetCommand = new CommandViewModel(ResetCommandDisplayName,
                        new RelayCommand(p => { this.ItemsReset(); }, CE => (SelectedItem != null)),
                        System.Windows.Media.Geometry.Parse(IconData.Reset));
                return _resetCommand;
            }
            set { _resetCommand = value; }
        }
        private CommandViewModel _browseCommand;

        public CommandViewModel BrowseCommand
        {
            get
            {
                if (_browseCommand == null)
                {
                    _browseCommand = new CommandViewModel(BrowseCommandDisplayName, new RelayCommand(null, null)
                        , System.Windows.Media.Geometry.Parse(IconData.Importer));
                }
                return _browseCommand;
            }
            set { _browseCommand = value; }
        }

        public ICommand CloseConfiguratorState
        {
            get
            {
                if (_closeConfiguratorState == null)
                {
                    _closeConfiguratorState = new RelayCommand(p => { Close(); });
                        //System.Windows.Media.Geometry.Parse(IconData.Close));


                }
                return _closeConfiguratorState;
            }

        }

        #endregion


        protected virtual string DeleteCommandDisplayName
        {
            get { return LangString.DeleteString; }
        }
        protected virtual string CreateCommandDisplayName
        {
            get { return LangString.CreateString; }
        }
        protected virtual string EditCommandDisplayName
        {
            get { return LangString.EditString; }
        }
        public virtual string SaveCommandDisplayName
        {
            get => LangString.SaveString;
        }
        public virtual string ResetCommandDisplayName
        {
            get => LangString.ResetString;
        }
        public virtual string BrowseCommandDisplayName
        {
            get => LangString.ImporterString;
        }
        public virtual string CloseCommandDisplayName
        {
            get => LangString.CloseString;
        }

        #region Methodes
        public virtual bool canSave()
        {
            return (!string.IsNullOrWhiteSpace(SelectedItem.Id.ToString()) && SelectedItem.Id < 0);

        }

        public void ItemsReset()
        {
            if (eventReset != null)
                eventReset();
        }

        private void InitialiseSelecteditem()
        {
            if (SelectedItemneedtobeinitialised != null)
                SelectedItemneedtobeinitialised();
        }

        public virtual bool CandUserAddItem(BaseModel SelectedItem)
        {
            return (SelectedItem != null && !Repository.Contains(SelectedItem));

        }
        void Create()
        { 
            ConfiguratorState = Visibility.Visible;
        }
        void Edit()
        { 
            ConfiguratorState = Visibility.Visible; 
        }
        public void delete() 
        {
            MessageBoxResult result = MessageBox.Show("Do you really want to delete this item ?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                Repository.Delete(SelectedItem);

            // MessageBoxButton.YesNo.HasFlag(MessageBoxButton.YesNo);
           // Repository.Delete(SelectedItem);
           // MessageBox.Show("Supp").HasFlag(MessageBoxButton.YesNo);

        }
        void Close()
        {
            ConfiguratorState = Visibility.Collapsed;
        }
        public void save()
        {
            if (CandUserAddItem(SelectedItem))
            {
                Repository.Add(SelectedItem);
                this.InitialiseSelecteditem();
            }
        }
        #endregion
    }
}
