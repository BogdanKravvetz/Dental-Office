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
    class MedicWindowActions : BaseVM
    {

        CabinetEntities1 entities = new CabinetEntities1();
        private MedicViewModel medicVM { get; set; }

        public MedicWindowActions(MedicViewModel medicVM)
        {
            this.medicVM = medicVM;

        }

        public void AddPacient(object obj)
        {
            if (String.IsNullOrEmpty(medicVM.PacientVM.Nume) || String.IsNullOrEmpty(medicVM.PacientVM.Prenume) || String.IsNullOrEmpty(medicVM.PacientVM.Cnp))
            {
                MessageBox.Show("Completati toate Campurile");
                return;
            }
            entities.InsertPacient(medicVM.MyMedic.idUtilizator, medicVM.PacientVM.Nume, medicVM.PacientVM.Prenume, medicVM.PacientVM.Cnp);
            entities.SaveChanges();
            MessageBox.Show("Salvat!");
        }
        public void ModifyPacient(object obj)
        {
            if (String.IsNullOrEmpty(medicVM.PacientVM.Nume) || String.IsNullOrEmpty(medicVM.PacientVM.Prenume) || String.IsNullOrEmpty(medicVM.PacientVM.Cnp))
            {
                MessageBox.Show("Selectati un utilizator");
                return;
            }
            entities.UpdatePacient(medicVM.PacientVM.IdPacient, medicVM.PacientVM.Nume, medicVM.PacientVM.Prenume, medicVM.PacientVM.Cnp);
            entities.SaveChanges();
            MessageBox.Show("Salvat!");
        }
        public void DeletePacient(object obj)
        {
            if (String.IsNullOrEmpty(medicVM.PacientVM.Nume) || String.IsNullOrEmpty(medicVM.PacientVM.Prenume) || String.IsNullOrEmpty(medicVM.PacientVM.Cnp))
            {
                MessageBox.Show("Selectati un utilizator");
                return;
            }
            entities.DeletePacient(medicVM.PacientVM.IdPacient, true);
            entities.SaveChanges();
            MessageBox.Show("Sters!");
        }
        public void UpdateList(object obj)
        {
            medicVM.AllPacienti = medicVM.GetAllPacienti(medicVM.MyMedic.idUtilizator);
            medicVM.PacientVM = new PacientViewModel();
            medicVM.AllPret = medicVM.GetAllPret2();
        }
        public void AddProgramare(object obj)
        {
            if (medicVM.Ora==0 && medicVM.ProgramareVM.DataProgramare == default(DateTime) )
            {
                MessageBox.Show("Introduceti o data/ora valida");
                return;
            }
            if(String.IsNullOrEmpty(medicVM.PacientVM.Nume))
            {
                MessageBox.Show("Selectati un pacient");
                return;
            }
            medicVM.ProgramareVM.DataProgramare = medicVM.ProgramareVM.DataProgramare.Date.AddHours(medicVM.Ora + (24 - medicVM.Ora));
            medicVM.ProgramareVM.DataProgramare = medicVM.ProgramareVM.DataProgramare.Date.AddHours(medicVM.Ora);
            if(medicVM.ComparaData(medicVM.ProgramareVM.DataProgramare))
            {
                MessageBox.Show("Programarea se suprapune, alegeti alta data!");
                return;
            }
            entities.InsertProgramare(medicVM.PacientVM.IdPacient, (DateTime)medicVM.ProgramareVM.DataProgramare, false);
            entities.SaveChanges();
            MessageBox.Show("Salvat!");
            medicVM.AllProgramari = medicVM.GetAllProgramari(medicVM.PacientVM.IdPacient);
        }
        public void ModifyProgramare(object obj)
        {
            if (medicVM.ProgramareVM.DataProgramare == default(DateTime))
            {
                MessageBox.Show("Selectati o programare");
                return;
            }
            medicVM.ProgramareVM.DataProgramare = medicVM.ProgramareVM.DataProgramare.Date.AddHours(medicVM.Ora + (24 - medicVM.Ora));
            medicVM.ProgramareVM.DataProgramare = medicVM.ProgramareVM.DataProgramare.Date.AddHours(medicVM.Ora);
            if (medicVM.ComparaData(medicVM.ProgramareVM.DataProgramare))
            {
                MessageBox.Show("Programarea se suprapune, alegeti alta data!");
                return;
            }
            entities.UpdateProgramare(medicVM.ProgramareVM.IdProgramare, medicVM.PacientVM.IdPacient, medicVM.ProgramareVM.DataProgramare);
            entities.SaveChanges();
            MessageBox.Show("Modificat!");
            medicVM.AllProgramari = medicVM.GetAllProgramari(medicVM.PacientVM.IdPacient);
        }
        public void DeleteProgramare(object obj)
        {
            if (medicVM.ProgramareVM.DataProgramare == default(DateTime))
            {
                MessageBox.Show("Selectati o programare");
                return;
            }
            entities.DeleteProgramare(medicVM.ProgramareVM.IdProgramare, medicVM.PacientVM.IdPacient, true);
            entities.SaveChanges();
            MessageBox.Show("Sters!");
            medicVM.AllProgramari = medicVM.GetAllProgramari(medicVM.PacientVM.IdPacient);
        }
        public void UpdateProgramari(object obj)
        {
            //MessageBox.Show(medicVM.PacientVM.IdPacient + medicVM.PacientVM.Nume);
            medicVM.AllProgramari = medicVM.GetAllProgramari(medicVM.PacientVM.IdPacient);
        }
        public void CalculeazaGrad(object obj)
        {
            if(medicVM.Sfarsit == default(DateTime) || medicVM.Inceput==default(DateTime))
            {
                MessageBox.Show("Selectati data valida!");
                return;
            }
            double nrOre = ((medicVM.Sfarsit - medicVM.Inceput).TotalDays * 8);
            medicVM.Procent = (medicVM.GetAllProgramariMedic().Count * 100) / nrOre;
 
        }
    }
}
