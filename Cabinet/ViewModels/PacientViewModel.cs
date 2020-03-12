using Cabinet.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet.ViewModels
{
    class PacientViewModel:BaseVM
    {
        private int idPacient;
        private int idUtilizator;
        private string nume;
        private string prenume;
        private string cnp;
        private bool isDeleted;

        public int IdPacient
        {
            get
            {
                return idPacient;
            }
            set
            {
                idPacient = value;
                OnPropertyChanged("IdPacient");
            }
        }
        public int IdUtilizator
        {
            get
            {
                return idUtilizator;
            }
            set
            {
                idUtilizator = value;
                OnPropertyChanged("IdUtilizator");
            }
        }
        public string Nume
        {
            get
            {
                return nume;
            }
            set
            {
                nume = value;
                OnPropertyChanged("Nume");
            }
        }
        public string Prenume
        {
            get
            {
                return prenume;
            }
            set
            {
                prenume = value;
                OnPropertyChanged("Prenume");
            }
        }
        public string Cnp
        {
            get
            {
                return cnp;
            }
            set
            {
                cnp = value;
                OnPropertyChanged("Cnp");
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

    }
}
