using Cabinet.Utilities;
using System;

namespace Cabinet.ViewModels
{
    class ProgramareViewModel :BaseVM
    {

        private int idProgramare;
        private int idPacient;
        private DateTime dataProgramare;
        private bool isDeleted;


        public int IdProgramare
        {
            get
            {
                return idProgramare;
            }
            set
            {
                idProgramare = value;
                OnPropertyChanged("IdProgramare");
            }
        }
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
        public DateTime DataProgramare
        {
            get
            {
                return dataProgramare;
            }
            set
            {
                dataProgramare = value;
                OnPropertyChanged("DataProgramare");
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
