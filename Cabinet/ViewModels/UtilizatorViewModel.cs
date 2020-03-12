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
    public class UtilizatorViewModel : BaseVM
    {


        private int idUtilizator;
        private string nume;
        private string parola;
        private bool isMedic;
        private bool isDeleted;
        private List<Utilizator> allUsers;
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
        public string Parola
        {
            get
            {
                return parola;
            }
            set
            {
                parola = value;
                OnPropertyChanged("Parola");
            }
        }
        public bool IsMedic
        {
            get
            {
                return isMedic;
            }
            set
            {
                isMedic = value;
                OnPropertyChanged("IsMedic");
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
        public List<Utilizator> AllUsers
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
    }
}
