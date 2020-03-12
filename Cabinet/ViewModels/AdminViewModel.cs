using Cabinet.Models;
using Cabinet.Models.Actions;
using Cabinet.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cabinet.ViewModels
{
    class AdminViewModel :BaseVM
    {
        private UtilizatorViewModel selectedUserVM;
        private InterventieViewModel selectedInterventieVM;
        private PretViewModel selectedPretVM;
        private PretViewModel selectedPretVM2;
        public PretViewModel PretVM { get; set; }
  

        public CabinetEntities1 entities;
        private ObservableCollection<UtilizatorViewModel> allUsers;
        private ObservableCollection<PretViewModel> allPret;
        private ObservableCollection<PretViewModel> allPretInterventie;

        private ObservableCollection<InterventieViewModel> allInterventii;
        private AdminWindowActions adminActions;


        public AdminViewModel() : base()
        {
            SelectedUserVM = new UtilizatorViewModel();
            SelectedInterventieVM = new InterventieViewModel();
            SelectedPretVM = new PretViewModel();
            SelectedPretVM2 = new PretViewModel();
            entities = new CabinetEntities1();
            AllUsers = GetAllUsers();
            AllPret = GetAllPret();
            AllInterventii = GetAllInterventii();
            adminActions = new AdminWindowActions(this);
        }
        public UtilizatorViewModel SelectedUserVM
        {
            get
            {
                return selectedUserVM;
            }
            set
            {
                selectedUserVM = value;
                OnPropertyChanged("SelectedUserVM");
            }
        }
        public InterventieViewModel SelectedInterventieVM
        {
            get
            {
                return selectedInterventieVM;
            }
            set
            {
                selectedInterventieVM = value;
                OnPropertyChanged("SelectedInterventieVM");
            }
        }
        public PretViewModel SelectedPretVM
        {
            get
            {
                return selectedPretVM;
            }
            set
            {
                selectedPretVM = value;
                OnPropertyChanged("SelectedPretVM");
            }
        }
        public PretViewModel SelectedPretVM2
        {
            get
            {
                return selectedPretVM2;
            }
            set
            {
                selectedPretVM2 = value;
                OnPropertyChanged("SelectedPretVM2");
            }
        }
        public ObservableCollection<InterventieViewModel> AllInterventii
        {
            get
            {
                return allInterventii;
            }
            set
            {
                allInterventii = value;
                OnPropertyChanged("AllInterventii");
            }
        }
        public ObservableCollection<PretViewModel> AllPret
        {
            get
            {
                return allPret;
            }
            set
            {
                allPret = value;
                OnPropertyChanged("AllPret");
            }
        }
        public ObservableCollection<UtilizatorViewModel> AllUsers
        {
            get
            {
                return allUsers;
            }
            set
            {
                allUsers = value;
                OnPropertyChanged("AllUsers");
            }
        }
        public ObservableCollection<PretViewModel> AllPretInterventie
        {
            get
            {
                return allPretInterventie;
            }
            set
            {
                allPretInterventie = value;
                OnPropertyChanged("AllPretInterventie");
            }
        }
        public ObservableCollection<UtilizatorViewModel> GetAllUsers()
        {
            List<Utilizator> persons = entities.Utilizator.ToList();
            ObservableCollection<UtilizatorViewModel> result = new ObservableCollection<UtilizatorViewModel>();
            foreach (Utilizator person in persons)
            {
                if (!person.isDeleted)
                {
                    result.Add(new UtilizatorViewModel()
                    {

                        IdUtilizator = person.idUtilizator,
                        Nume = person.nume,
                        Parola = person.parola,
                        IsMedic = person.isMedic,
                        IsDeleted = person.isDeleted
                    });
                }
            }

            return result;

        }
        public ObservableCollection<PretViewModel> GetAllPret()
        {
            List<Pret> prets = entities.Pret.ToList();
            ObservableCollection<PretViewModel> result = new ObservableCollection<PretViewModel>();
            foreach (Pret pret in prets)
            {
                if (!pret.isDeleted )
                { 
                    if(pret.dataSfarsit==null)
                    {
                        pret.dataSfarsit = default(DateTime);
                    }
                    foreach (InterventieViewModel interventie in GetAllInterventii())
                    {
                        if(interventie.IdInterventie==pret.idInterventie&& !interventie.IsDeleted)
                        {
                            result.Add(new PretViewModel()
                            {
                                IdPret = pret.idPret,
                                IdInterventie = pret.idInterventie,
                                DataInceput = (DateTime)pret.dataInceput,
                                DataSfarsit = (DateTime)pret.dataSfarsit,
                                Pret = (decimal)pret.pret1,
                                IsDeleted = pret.isDeleted
                            });
                        }
                    }
                
                }
            }

            return result;
        }
      
        public ObservableCollection<PretViewModel> GetAllPretInterventie(int idInterventie, DateTime dataSfarsit)
        {
            List<Pret> prets = entities.Pret.ToList();
            ObservableCollection<PretViewModel> result = new ObservableCollection<PretViewModel>();
            foreach (Pret pret in prets)
            {
                if (!pret.isDeleted)
                {
                        if (idInterventie == pret.idInterventie && DateTime.Compare((DateTime)pret.dataSfarsit, dataSfarsit)<0 && pret.dataSfarsit!=default(DateTime))
                        {
                            result.Add(new PretViewModel()
                            {
                                IdPret = pret.idPret,
                                IdInterventie = pret.idInterventie,
                                DataInceput = (DateTime)pret.dataInceput,
                                DataSfarsit = (DateTime)pret.dataSfarsit,
                                Pret = (decimal)pret.pret1,
                                IsDeleted = pret.isDeleted
                            });
                        }
                    

                }
            }

            return result;
        }
        public ObservableCollection<InterventieViewModel> GetAllInterventii()
        {
            List<Interventie> interventii = entities.Interventie.ToList();
            ObservableCollection<InterventieViewModel> result = new ObservableCollection<InterventieViewModel>();
            foreach (Interventie interventie in interventii)
            {
                if (!interventie.isDeleted)
                {
                    result.Add(new InterventieViewModel()
                    {
                        IdInterventie = interventie.idInterventie,
                        Tip = interventie.tip,
                        IsDeleted = interventie.isDeleted
                    });
                }
            }

            return result;

        }
        private ICommand addUser;
        public ICommand AddUser
        {
            get
            {
                if (addUser == null)
                {
                    addUser = new RelayCommand(adminActions.AddUser);
                }
                return addUser;
            }
        }
        private ICommand modifiyUser;
        public ICommand ModifyUser
        {
            get
            {
                if (modifiyUser == null)
                {
                    modifiyUser = new RelayCommand(adminActions.ModifyUser);
                }
                return modifiyUser;
            }
        }
        private ICommand deleteUser;
        public ICommand DeleteUser
        {
            get
            {
                if (deleteUser == null)
                {
                    deleteUser = new RelayCommand(adminActions.DeleteUser);
                }
                return deleteUser;
            }
        }
        private ICommand addInterventie;
        public ICommand AddInterventie
        {
            get
            {
                if (addInterventie == null)
                {
                    addInterventie = new RelayCommand(adminActions.AddInterventie);
                }
                return addInterventie;
            }
        }
        private ICommand modifyInterventie;
        public ICommand ModifyInterventie
        {
            get
            {
                if (modifyInterventie == null)
                {
                    modifyInterventie = new RelayCommand(adminActions.ModifyInterventie);
                }
                return modifyInterventie;
            }
        }
        private ICommand deleteInterventie;
        public ICommand DeleteInterventie
        {
            get
            {
                if (deleteInterventie == null)
                {
                    deleteInterventie = new RelayCommand(adminActions.DeleteInterventie);
                }
                return deleteInterventie;
            }
        }
        private ICommand addPret;
        public ICommand AddPret
        {
            get
            {
                if (addPret == null)
                {
                    addPret = new RelayCommand(adminActions.AddPret);
                }
                return addPret;
            }
        }
  
        private ICommand showPrices;
        public ICommand ShowPrices
        {
            get
            {
                if (showPrices == null)
                {
                    showPrices = new RelayCommand(adminActions.ShowPrices);
                }
                return showPrices;
            }
        }
    }
}
