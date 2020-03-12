using Cabinet.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet.ViewModels
{
    class InterventieViewModel : BaseVM
    {

        private int idInterventie;
        private string tip;
        private bool isDeleted;
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
        public string Tip
        {
            get
            {
                return tip;
            }
            set
            {
                tip = value;
                OnPropertyChanged("Tip");
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
