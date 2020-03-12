using Cabinet.Models;
using Cabinet.Models.Actions;
using Cabinet.Utilities;
using Cabinet.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Cabinet.ViewModels
{
    public class MainWindowViewModel : BaseVM
    {
        private Utilizator logInUser;
        public Utilizator CreateUser { get; set; }
        public UtilizatorViewModel UserVMCreate { get; set; }
        public UtilizatorViewModel UserVMLogIn { get; set; }
        public MainWindowActions mainWindowActions { get; set; }
        CabinetEntities1 entities;

        public MainWindowViewModel()
        {
            LogInUser = new Utilizator();
            CreateUser = new Utilizator();
            entities = new CabinetEntities1();
            UserVMCreate = new UtilizatorViewModel();
            UserVMLogIn = new UtilizatorViewModel();
            mainWindowActions = new MainWindowActions(this);

        }
        public Utilizator LogInUser
        {
            get
            {
                return logInUser;
            }
            set
            {
                logInUser = value;
                OnPropertyChanged("LogInUser");
            }
        }

        private ICommand openWindowCommand;
        public ICommand OpenWindowCommand
        {
            get
            {
                if (openWindowCommand == null)
                {
                    openWindowCommand =new RelayCommand(mainWindowActions.OpenWindow);
                }
                return openWindowCommand;
            }
        }
        private ICommand createAccountCommand;
        public ICommand CreateAccountCommand
        {
            get
            {
                if (createAccountCommand == null)
                {
                    createAccountCommand = new RelayCommand(mainWindowActions.CreateAccount);
                }
                return createAccountCommand;
            }
        }

      
    }
}
