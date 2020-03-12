using Cabinet.Models;
using Cabinet.Models.Actions;
using Cabinet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cabinet.Views
{
    /// <summary>
    /// Interaction logic for MedicWindow.xaml
    /// </summary>
    public partial class MedicWindow : Window
    {
        public MedicWindow( Utilizator user)
        {
            InitializeComponent();
            MyUser = user;
            //DataContext = new MedicViewModel();
           (this.DataContext as MedicViewModel).MyMedic = user;
            MessageBox.Show((this.DataContext as MedicViewModel).MyMedic.idUtilizator + (this.DataContext as MedicViewModel).MyMedic.nume + "window");
            // (this.DataContext as MedicViewModel).MainVM = mainVM;
        }
        public Utilizator MyUser { get; set; }
    }
}
