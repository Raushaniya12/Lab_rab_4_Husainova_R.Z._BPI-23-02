using System;
using System.Windows;
using Lab_rab_4_Husainova_R.Z._BPI_23_02.Model;
using Lab_rab_4_Husainova_R.Z._BPI_23_02.ViewModel;

namespace Lab_rab_4_Husainova_R.Z._BPI_23_02.View
{
    public partial class WindowNewEmployee : Window
    {
        private PersonDpo _personDpo; 

        public WindowNewEmployee()
        {
            InitializeComponent();
            LoadRoles();
        }
        private void LoadRoles()
        {
            RoleViewModel vmRole = new RoleViewModel();
            CbRole.ItemsSource = vmRole.ListRole;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtId.Text) ||
                CbRole.SelectedItem == null ||
                string.IsNullOrWhiteSpace(TxtFirstName.Text) ||
                string.IsNullOrWhiteSpace(TxtLastName.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DialogResult = true;
            Close();
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}