using Cabinet.Models;
using Cabinet.Models.Actions;
using Cabinet.Utilities;
using Cabinet.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Cabinet.ViewModels
{
    class MedicViewModel :BaseVM
    {

        public MedicWindowActions medicActions { get; set; }
        private PacientViewModel pacientVM;
        private ProgramareViewModel programareVM;
        private MainWindowViewModel mainVM;
        private Utilizator myMedic;
        private CabinetEntities1 entities;
        private DateTime inceput;
        private DateTime sfarsit;

        private double procent;

        private int ora;

        private ObservableCollection<PacientViewModel> allPacienti;
        private ObservableCollection<ProgramareViewModel> allProgramari;
        private ObservableCollection<PretViewModel> allPret;


        public MedicViewModel()
        {
            mainVM = new MainWindowViewModel();
            medicActions = new MedicWindowActions(this);
            entities = new CabinetEntities1();
            PacientVM = new PacientViewModel();
            programareVM = new ProgramareViewModel();;
            AllPret = GetAllPret2();
            //AllProgramari = GetAllProgramari(programareVM.IdPacient);
        }

        public ObservableCollection<PretViewModel> GetAllPret2()
        {
            List<Pret> prets = entities.Pret.ToList();
            ObservableCollection<PretViewModel> result = new ObservableCollection<PretViewModel>();
            foreach (Pret pret in prets)
            {
                if (!pret.isDeleted)
                {
                    if (pret.dataSfarsit == null)
                    {
                        pret.dataSfarsit = default(DateTime);
                    }
                    if (pret.dataSfarsit == default(DateTime))
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
       
        public double Procent
        {
            get
            {
                return procent;
            }
            set
            {
                procent = value;
                OnPropertyChanged("Procent");
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
        public ObservableCollection<PacientViewModel> AllPacienti
        {
            get
            {
                return allPacienti;
            }
            set
            {
                allPacienti = value;              
                OnPropertyChanged("AllPacienti");
            }
        }
        public ObservableCollection<ProgramareViewModel> AllProgramari
        {
            get
            {
                return allProgramari;
            }
            set
            {
                allProgramari = value;
                OnPropertyChanged("AllProgramari");
            }
        }
        public ObservableCollection<ProgramareViewModel> GetAllProgramari(int idPacient)
        {
            List<Programare> programari = entities.Programare.ToList();
            ObservableCollection<ProgramareViewModel> result = new ObservableCollection<ProgramareViewModel>();
            foreach (Programare programare in programari)
            {
                if (!programare.isDeleted)
                {
                    if (programare.idPacient == idPacient)
                    {
                        result.Add(new ProgramareViewModel()
                        {
                            IdPacient = programare.idPacient,
                            IdProgramare = programare.idProgramare,
                            DataProgramare = (DateTime)programare.dataProgramare,
                            IsDeleted = programare.isDeleted
                        });
                    }
                }
            }

            return result;

        }
        public ObservableCollection<ProgramareViewModel> GetAllProgramariMedic()
        {
            List<Programare> programari = entities.Programare.ToList();
            ObservableCollection<ProgramareViewModel> result = new ObservableCollection<ProgramareViewModel>();
            foreach (Programare programare in programari)
            {
                if (!programare.isDeleted)
                {

                        result.Add(new ProgramareViewModel()
                        {
                            IdPacient = programare.idPacient,
                            IdProgramare = programare.idProgramare,
                            DataProgramare = (DateTime)programare.dataProgramare,
                            IsDeleted = programare.isDeleted
                        });
                    
                }
            }

            return result;

        }
        public bool ComparaData( DateTime dataProgramare)
        {
            List<Programare> programari = entities.Programare.ToList();
            foreach (Programare programare in programari)
            {
                if (!programare.isDeleted)
                {
                    if (DateTime.Compare((DateTime)programare.dataProgramare, dataProgramare) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public ObservableCollection<PacientViewModel> GetAllPacienti( int idUtilizator)
        {
            List<Pacient> pacienti = entities.Pacient.ToList();
            ObservableCollection<PacientViewModel> result = new ObservableCollection<PacientViewModel>();
            foreach (Pacient pacient in pacienti)
            {
                if (!pacient.isDeleted)
                {
                    if (pacient.idUtilizator == idUtilizator)
                    {
                        result.Add(new PacientViewModel()
                        {
                            IdPacient = pacient.idPacient,
                            IdUtilizator = pacient.idUtilizator,
                            Nume = pacient.nume,
                            Prenume = pacient.prenume,
                            Cnp = pacient.cnp,
                            IsDeleted = pacient.isDeleted
                        });
                    }
                }
            }
            return result;
        }
        public DateTime Inceput
        {
            get
            {
                return inceput;
            }
            set
            {
                inceput = value;
                OnPropertyChanged("Inceput");
            }
        }
        public DateTime Sfarsit
        {
            get
            {
                return sfarsit;
            }
            set
            {
                sfarsit = value;
                OnPropertyChanged("Sfarsit");
            }
        }
        public int Ora
        {
            get
            {
                return ora;
            }
            set
            {
                ora = value;
                OnPropertyChanged("Ora");
            }
        }
        public Utilizator MyMedic
        {
            get
            {
                return myMedic;
            }
            set
            {
                myMedic = value;
                OnPropertyChanged("MyMedic");
            }
        }


        public MainWindowViewModel MainVM
        {
            get
            {
                return mainVM;
            }
            set
            {
                mainVM = value;
                MessageBox.Show(MainVM.LogInUser.nume);
                OnPropertyChanged("MainVM");
            }
        }
        public ProgramareViewModel ProgramareVM
        {
            get
            {
                return programareVM;
            }
            set
            {
                programareVM = value;
                OnPropertyChanged("ProgramareVM");
            }
        }
        public PacientViewModel PacientVM
        {
            get
            {
                return pacientVM;
            }
            set
            {
                pacientVM = value;
                OnPropertyChanged("PacientVM");
            }
        }

        private ICommand addPacient;
        public ICommand AddPacient
        {
            get
            {
                if (addPacient == null)
                {
                    addPacient = new RelayCommand(medicActions.AddPacient);
                }
                return addPacient;
            }
        }
        private ICommand modifyPacient;
        public ICommand ModifyPacient
        {
            get
            {
                if (modifyPacient == null)
                {
                    modifyPacient = new RelayCommand(medicActions.ModifyPacient);
                }
                return modifyPacient;
            }  
        }
        private ICommand deletePacient;
        public ICommand DeletePacient
        {
            get
            {
                if (deletePacient == null)
                {
                    deletePacient = new RelayCommand(medicActions.DeletePacient);
                }
                return deletePacient;
            }
        }
        private ICommand updateList;
        public ICommand UpdateList
        {
            get
            {
                if (updateList == null)
                {
                    updateList = new RelayCommand(medicActions.UpdateList);
                }
                return updateList;
            }
        }
        private ICommand addProgramare;
        public ICommand AddProgramare
        {
            get
            {
                if (addProgramare == null)
                {
                    addProgramare = new RelayCommand(medicActions.AddProgramare);
                }
                return addProgramare;
            }
        }
        private ICommand modifyProgramare;
        public ICommand ModifyProgramare
        {
            get
            {
                if (modifyProgramare == null)
                {
                    modifyProgramare = new RelayCommand(medicActions.ModifyProgramare);
                }
                return modifyProgramare;
            }
        }
        private ICommand deleteProgramare;
        public ICommand DeleteProgramare
        {
            get
            {
                if (deleteProgramare == null)
                {
                    deleteProgramare = new RelayCommand(medicActions.DeleteProgramare);
                }
                return deleteProgramare;
            }
        }
        private ICommand updateProgramari;
        public ICommand UpdateProgramari
        {
            get
            {
                if (updateProgramari == null)
                {
                    updateProgramari = new RelayCommand(medicActions.UpdateProgramari);
                }
                return updateProgramari;
            }
        }
        private ICommand calculeazaGrad;
        public ICommand CalculeazaGrad
        {
            get
            {
                if (calculeazaGrad == null)
                {
                    calculeazaGrad = new RelayCommand(medicActions.CalculeazaGrad);
                }
                return calculeazaGrad;
            }
        }
    }
}
