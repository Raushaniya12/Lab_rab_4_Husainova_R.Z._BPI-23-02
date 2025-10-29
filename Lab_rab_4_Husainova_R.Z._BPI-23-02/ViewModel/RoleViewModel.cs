using Lab_rab_4_Husainova_R.Z._BPI_23_02.Helper;
using Lab_rab_4_Husainova_R.Z._BPI_23_02.View;
using Lab_rab_4_Husainova_R.Z._BPI_23_02.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_rab_4_Husainova_R.Z._BPI_23_02.ViewModel
{
    public class RoleViewModel : INotifyPropertyChanged
    {

        public static RoleViewModel _instance;
        public static RoleViewModel Instance
        {
        get
        {
            if (_instance == null)
            {
                _instance = new RoleViewModel();
            }
            return _instance;
        }
    }

    
        private Role selectedRole;
        public Role SelectedRole
        {
            get
            {
                return selectedRole;
            }
            set
            {
                selectedRole = value; 
                OnPropertyChanged("SelectedRole");
                AddRole.CanExecute(true);
                EditRole.CanExecute(true);
                DeleteRole.CanExecute(true);
            }
        }
        public ObservableCollection<Role> ListRole { get; set; } = new ObservableCollection<Role>();
        public RoleViewModel()
        {
            this.ListRole.Add(new Role{Id = 1,NameRole = "Директор"});
            this.ListRole.Add(new Role { Id = 2, NameRole = "Бухгалтер" });
            this.ListRole.Add(new Role { Id = 3, NameRole = "Менеджер" });
        }
        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListRole)
            {
                if (max < r.Id)
                {
                    max = r.Id;
                }
                ;
            }
            return max;
        }
        private RelayCommand addRole; 
        public RelayCommand AddRole
        {
            get
            {
                return addRole ??
                (addRole = new RelayCommand(obj =>
                {
                    WindowNewRole wnRole = new WindowNewRole
                    {
                        Title = "Новая должность",
                    };
                    int maxIdRole = MaxId() + 1;
                    Role role = new Role { Id = maxIdRole }; 
                    wnRole.DataContext = role;
                    if (wnRole.ShowDialog() == true)
                    {
                        ListRole.Add(role);
                    }
                    SelectedRole = role;
                }));
            }
        }
        private RelayCommand editRole; 
        public RelayCommand EditRole
        {
            get
            {
                return editRole ??
                (editRole = new RelayCommand(obj =>
                {
                    WindowNewRole wnRole = new WindowNewRole
                    { Title = "Редактирование должности"}; 
                    Role role = SelectedRole;
                    Role tempRole = new Role(); 
                    tempRole = role.ShallowCopy(); 
                    wnRole.DataContext = tempRole; 
                    if (wnRole.ShowDialog() == true)
                    {
                        role.NameRole = tempRole.NameRole;
                    }
                }, (obj) => SelectedRole != null && ListRole.Count > 0));
            }
        }

        private RelayCommand deleteRole; 
        public RelayCommand DeleteRole
        {
            get
            {
                return deleteRole ?? (deleteRole = new RelayCommand(obj =>
                {
                    Role role = SelectedRole;
                    MessageBoxResult result = MessageBox.Show("Удалить данные по должности: " 
                        + role.NameRole, "Предупреждение", MessageBoxButton.OKCancel,
                        MessageBoxImage.Warning);
                    if (result == MessageBoxResult.OK)
                    {
                        ListRole.Remove(role);
                        SelectedRole = null;
                    }
                }, (obj) => SelectedRole != null && ListRole.Count > 0));
            }
        }
        private RelayCommand switchLightTheme;
        public RelayCommand SwitchLightTheme => switchLightTheme = new RelayCommand(_ => ThemeManager.ApplyTheme("LightTheme"));

        private RelayCommand switchDarkTheme;
        public RelayCommand SwitchDarkTheme => switchDarkTheme = new RelayCommand(_ => ThemeManager.ApplyTheme("DarkTheme"));
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
