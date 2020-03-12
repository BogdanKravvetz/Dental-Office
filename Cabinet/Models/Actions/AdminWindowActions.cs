using Cabinet.Utilities;
using Cabinet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cabinet.Models.Actions
{
    class AdminWindowActions:BaseVM
    {
        CabinetEntities1 entities = new CabinetEntities1();
        private AdminViewModel adminVM;
        public AdminWindowActions(AdminViewModel adminVM)
        {
            this.adminVM = adminVM;
        }

        public void AddUser(object obj)
        {

            entities.InsertUser(adminVM.SelectedUserVM.Nume, adminVM.SelectedUserVM.Parola, adminVM.SelectedUserVM.IsMedic,false);
            entities.SaveChanges();
            MessageBox.Show("Adaugat!");
            adminVM.AllUsers = adminVM.GetAllUsers();
        }
        public void ModifyUser(object obj)
        {   
            if(adminVM.SelectedUserVM.Nume == null)
            {
                MessageBox.Show("Selectati un utilizator!");
                return;
            }
            entities.UpdateUser(adminVM.SelectedUserVM.IdUtilizator, adminVM.SelectedUserVM.Nume, adminVM.SelectedUserVM.Parola, adminVM.SelectedUserVM.IsMedic);
            entities.SaveChanges();
        }
        public void DeleteUser(object obj)
        {
            if (adminVM.SelectedUserVM.Nume == null)
            {
                MessageBox.Show("Selectati un utilizator!");
                return;
            }
            entities.DeleteUser(adminVM.SelectedUserVM.IdUtilizator);
            entities.SaveChanges();
            adminVM.AllUsers = adminVM.GetAllUsers();
        }
        public void AddInterventie(object obj)
        {
            entities.InsertInterventie(adminVM.SelectedInterventieVM.Tip);
            entities.SaveChanges();
            MessageBox.Show("Adaugat!");
            adminVM.SelectedInterventieVM.Tip = "";
            adminVM.AllInterventii = adminVM.GetAllInterventii();
        }
        public void ModifyInterventie(object obj)
        {
            if (String.IsNullOrEmpty(adminVM.SelectedInterventieVM.Tip))
            {
                MessageBox.Show("Introduceti un tip.");
                return;
            }
            entities.UpdateInterventie(adminVM.SelectedInterventieVM.IdInterventie, adminVM.SelectedInterventieVM.Tip);
            entities.SaveChanges();
        }
        public void DeleteInterventie(object obj)
        {
            if (String.IsNullOrEmpty(adminVM.SelectedInterventieVM.Tip))
            {
                MessageBox.Show("Selectati un tip.");
                return;
            }
            entities.DeleteInterventie(adminVM.SelectedInterventieVM.IdInterventie,true);
            entities.SaveChanges();
            MessageBox.Show("Sters!");
            adminVM.AllInterventii = adminVM.GetAllInterventii();

        }
        public void AddPret(object obj)
        {
            if (String.IsNullOrEmpty(adminVM.SelectedInterventieVM.Tip))
            {
                MessageBox.Show("Selectati o interventie!");
                return;
            }
            if(adminVM.SelectedPretVM.DataInceput.Year == 0001)
            {
                MessageBox.Show("Selectati o data!");
                return;
            }
            foreach (PretViewModel pret in adminVM.GetAllPret())
            {
                if(pret.IdInterventie == adminVM.SelectedInterventieVM.IdInterventie && pret.DataSfarsit==default(DateTime))
                {
                    pret.DataSfarsit = adminVM.SelectedPretVM.DataInceput;
                    pret.DataSfarsit= pret.DataSfarsit.AddDays(-1);
                    entities.UpdatePret(pret.IdPret,adminVM.SelectedInterventieVM.IdInterventie, pret.DataInceput, pret.DataSfarsit, pret.Pret);
                    entities.SaveChanges();
                }
            }
            entities.InsertPret(adminVM.SelectedInterventieVM.IdInterventie, (DateTime)adminVM.SelectedPretVM.DataInceput, null , adminVM.SelectedPretVM.Pret);
            entities.SaveChanges();
            MessageBox.Show("Salvat!");
            adminVM.AllPret = adminVM.GetAllPret();
        }
        public void ShowPrices(object obj)
        {
            adminVM.AllPretInterventie = adminVM.GetAllPretInterventie (adminVM.SelectedInterventieVM.IdInterventie,adminVM.SelectedPretVM2.DataSfarsit);          
        }
    }
}
