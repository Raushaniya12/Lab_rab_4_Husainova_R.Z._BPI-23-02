using Lab_rab_4_Husainova_R.Z._BPI_23_02;
using Lab_rab_4_Husainova_R.Z._BPI_23_02.Helper;
using System.Windows;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        ThemeManager.ApplyTheme("LightTheme");
        var resources = Application.Current.Resources;

        MainWindow = new MainWindow();
        MainWindow.Show();
    }
}