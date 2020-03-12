using Cabinet.Models;
using Cabinet.Models.Actions;
using Cabinet.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet.ViewModels
{
    class PretViewModel :BaseVM
    {

        private int idPret;
        private int idInterventie;
        private DateTime dataInceput;
        private DateTime dataSfarsit;
        private decimal pret;
        private bool isDeleted;

        private List<Pret> allPret;

        public int IdPret
        {
            get
            {
                return idPret;
            }
            set
            {
                idPret = value;
                OnPropertyChanged("IdPret");
            }
        }
        public int IdInterventie
        {
            get
            {
                return idInterventie;
            }
            set
            {
                idInterventie = value;
                OnPropertyChanged("IdInterventie");
            }
        }
        public DateTime DataInceput
        {
            get
            {
                return dataInceput;
            }
            set
            {
                dataInceput = value;
                OnPropertyChanged("DataInceput");
            }
        }
        public DateTime DataSfarsit
        {
            get
            {
                return dataSfarsit;
            }
            set
            {
                dataSfarsit = value;
                OnPropertyChanged("DataSfarsit");
            }
        }
        public decimal Pret
        {
            get
            {
                return pret;
            }
            set
            {
                pret = value;
                OnPropertyChanged("Pret");
            }
        }
        public bool IsDeleted
        {
            get
            {
                return isDeleted;
            }
            set
            {
                isDeleted = value;
                OnPropertyChanged("IsDeleted");
            }
        }
        public List<Pret> AllPret
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
    }
}
