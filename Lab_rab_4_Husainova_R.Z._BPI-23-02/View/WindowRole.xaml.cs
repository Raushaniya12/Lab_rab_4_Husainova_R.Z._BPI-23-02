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
    public partial class WindowRole : Window
    {
        public WindowRole()
        {
            InitializeComponent();
            DataContext = RoleViewModel.Instance;
        }
    
    private void SwitchTheme(string themeName)
        {
            var uri = new Uri($"Themes/{themeName}.xaml", UriKind.Relative);
            var theme = new ResourceDictionary { Source = uri };

            var oldTheme = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source?.OriginalString.Contains("Theme") == true);
            if (oldTheme != null)
                Application.Current.Resources.MergedDictionaries.Remove(oldTheme);

            Application.Current.Resources.MergedDictionaries.Add(theme);
        }
        private void BtnLight_Click(object sender, RoutedEventArgs e)
        {
            SwitchTheme("LightTheme");
            BtnLight.Tag = "Active";
            BtnDark.Tag = null;
        }

        private void BtnDark_Click(object sender, RoutedEventArgs e)
        {
            SwitchTheme("DarkTheme");
            BtnDark.Tag = "Active";
            BtnLight.Tag = null;
        }
    }
}
