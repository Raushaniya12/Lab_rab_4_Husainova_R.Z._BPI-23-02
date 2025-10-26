using Lab_rab_4_Husainova_R.Z._BPI_23_02.Model;
using Lab_rab_4_Husainova_R.Z._BPI_23_02.ViewModel;
using System;
using System.Linq;
using System.Windows;

namespace Lab_rab_4_Husainova_R.Z._BPI_23_02.View
{
    public partial class WindowNewEmployee : Window
    {
        private PersonDpo _personDpo;
        public WindowNewEmployee()
        {
            InitializeComponent();
            DataContext = PersonViewModel.Instance;
            LoadRoles();
        }

        private void LoadRoles()
        {
            RoleViewModel vmRole = new RoleViewModel();
            CbRole.ItemsSource = vmRole.ListRole;
        }
      
        
    }

}