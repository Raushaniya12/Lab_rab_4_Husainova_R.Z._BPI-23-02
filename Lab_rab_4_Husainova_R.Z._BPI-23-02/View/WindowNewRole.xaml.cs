using Lab_rab_4_Husainova_R.Z._BPI_23_02.Model;
using Lab_rab_4_Husainova_R.Z._BPI_23_02.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab_rab_4_Husainova_R.Z._BPI_23_02.View
{
    ///
    public partial class WindowNewRole : Window
    {
        public WindowNewRole()
        {
            InitializeComponent();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var role = this.DataContext as Role;
            if (string.IsNullOrWhiteSpace(role?.NameRole))
            {
                MessageBox.Show("Введите наименование должности", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            this.DialogResult = true; 
        }
    }
}
