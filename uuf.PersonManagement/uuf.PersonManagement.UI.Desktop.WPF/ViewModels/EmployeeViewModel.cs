using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using uuf.PersonManagement.Data.EfCore;
using uuf.PersonManagement.Logic;
using uuf.PersonManagement.Model;

namespace uuf.PersonManagement.UI.Desktop.WPF.ViewModels
{
    internal class EmployeeViewModel
    {
        Core core = new Core(new EfRepository());

        public ObservableCollection<Employee> Employees { get; set; }

        public Employee SelectedEmployee { get; set; }

        /// <summary>
        /// requires PropertyChanged notification stuff
        /// </summary>
        public string DepartmentsAsText
        {
            get
            {
                if (SelectedEmployee is null)
                {
                    return string.Empty;
                }
                return string.Join(", ", SelectedEmployee.Departments.Select(x => x.Name));
            }
            set { }
        }

        /// <summary>
        /// classic manual command implementation
        /// </summary>
        public ICommand SaveCommand { get; set; } = new SaveCommand();

        /// <summary>
        /// using RelayCommand
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        public EmployeeViewModel()
        {
            Employees = new ObservableCollection<Employee>(core.Repository.GetAll<Employee>().ToList());

            DeleteCommand = new RelayCommand(() => core.Repository.Delete(SelectedEmployee));
        }
    }
}
