using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Lab_rab_4_Husainova_R.Z._BPI_23_02.Helper;
using Lab_rab_4_Husainova_R.Z._BPI_23_02.Model;
using Lab_rab_4_Husainova_R.Z._BPI_23_02.ViewModel;

namespace Lab_rab_4_Husainova_R.Z._BPI_23_02.View
{
    public partial class WindowEmployee : Window
    {
        public WindowEmployee()
        {
            InitializeComponent();
            DataContext = new PersonViewModel();
            PersonViewModel vmPerson = new PersonViewModel();
            RoleViewModel vmRole = new RoleViewModel();

            List<Role> roles = new List<Role>();
            foreach (Role r in vmRole.ListRole)
            {
                roles.Add(r);
            }

            ObservableCollection <PersonDpo> persons = new ObservableCollection <PersonDpo>();

            foreach (var p in vmPerson.ListPerson)
            {
                FindRole finder = new FindRole(p.RoleId);
                Role rol = roles.Find(new System.Predicate<Role>(finder.RolePredicate));

                persons.Add(new PersonDpo
                {
                    Id = p.Id,
                    RoleName = rol.NameRole,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Birthday = p.Birthday
                });
            }

            lvEmployee.ItemsSource = persons;
        }
    }
}