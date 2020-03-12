using Cabinet.Utilities;
using Cabinet.ViewModels;
using Cabinet.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cabinet.Models.Actions
{
    public class MainWindowActions : BaseVM
    {
        
        CabinetEntities1 entities = new CabinetEntities1();
        private MainWindowViewModel mainWindowVM;
        public MainWindowActions(MainWindowViewModel mainWindowVM)
        {
            this.mainWindowVM = mainWindowVM;
        }

        public void CreateAccount(object obj)
        {
            if (String.IsNullOrEmpty(mainWindowVM.UserVMCreate.Nume) || String.IsNullOrEmpty(mainWindowVM.UserVMCreate.Parola))
            {
                MessageBox.Show("Completati toate campurile");
                MessageBox.Show("NUme" + mainWindowVM.UserVMCreate.Nume + "parola " + mainWindowVM.UserVMCreate.Parola + "med" + mainWindowVM.UserVMCreate.IsMedic.ToString());
            }
            else
            {
                mainWindowVM.CreateUser.nume = mainWindowVM.UserVMCreate.Nume;
                mainWindowVM.CreateUser.parola = mainWindowVM.UserVMCreate.Parola;
                mainWindowVM.CreateUser.isMedic = mainWindowVM.UserVMCreate.IsMedic;
                entities.InsertUser(mainWindowVM.CreateUser.nume, mainWindowVM.CreateUser.parola, mainWindowVM.CreateUser.isMedic,false);
                entities.SaveChanges();
                MessageBox.Show("Utilizator Salvat!");
                mainWindowVM.UserVMCreate.Nume = "";
                mainWindowVM.UserVMCreate.Parola = "";
            }
        }
        public void OpenWindow(object obj)
        {
            if (mainWindowVM.UserVMLogIn.IsDeleted)
            {
                MessageBox.Show("Utilizator inexistent");
                mainWindowVM.UserVMLogIn.Nume = "";
                mainWindowVM.UserVMLogIn.Parola = "";
                return;
            }
            if (String.IsNullOrEmpty(mainWindowVM.UserVMLogIn.Nume) || String.IsNullOrEmpty(mainWindowVM.UserVMLogIn.Parola))
            {
                MessageBox.Show("Utilizator inexistent");
                mainWindowVM.UserVMLogIn.Nume = "";
                mainWindowVM.UserVMLogIn.Parola = "";
                return;
            }

            foreach (var user in entities.GetAllUsers())
            {
                if (!user.isDeleted)
                {
                    if (user.nume == mainWindowVM.UserVMLogIn.Nume && user.parola == mainWindowVM.UserVMLogIn.Parola)
                    {
                        mainWindowVM.LogInUser.idUtilizator = user.idUtilizator;
                        mainWindowVM.LogInUser.nume = user.nume;
                        mainWindowVM.LogInUser.parola = user.parola;
                        mainWindowVM.LogInUser.isMedic = user.isMedic;
                        mainWindowVM.LogInUser.isDeleted = user.isDeleted;
                        break;
                    }
                }
            }
            //mainWindowVM.LogInUser.nume = "";
            //mainWindowVM.LogInUser.parola = "";
            if (mainWindowVM.LogInUser.isMedic)
            {
                MedicWindow medic = new MedicWindow(mainWindowVM.LogInUser);
                medic.MyUser = mainWindowVM.LogInUser;
                medic.ShowDialog();
            }
            if (!mainWindowVM.LogInUser.isMedic)
            {
                AdminWindow admin = new AdminWindow();
                admin.ShowDialog();
            }


        }
    }
}
