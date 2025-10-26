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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _personDpo = this.DataContext as PersonDpo;
            if (_personDpo == null)
            {
                MessageBox.Show("Ошибка: данные сотрудника не загружены.", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (CbRole.SelectedItem == null)
            {
                MessageBox.Show("Выберите должность", "Внимание",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var selectedRole = CbRole.SelectedItem as Role;
            _personDpo.RoleName = selectedRole?.NameRole ?? string.Empty;

            if (string.IsNullOrWhiteSpace(_personDpo.LastName))
            {
                MessageBox.Show("Введите фамилию", "Внимание",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(_personDpo.FirstName))
            {
                MessageBox.Show("Введите имя", "Внимание",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_personDpo.Birthday == default(DateTime))
            {
                MessageBox.Show("Укажите дату рождения", "Внимание",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            this.DialogResult = true;
        }
        
    }

}