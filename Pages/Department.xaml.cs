using Hospital_managment_system.Components.Departments;
using Hospital_managment_system.Interfaces.Departments;
using Hospital_managment_system.Repositories.Departments;
using Hospital_managment_system.Utilities;
using Hospital_managment_system.Windows.Departments;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital_managment_system.Pages
{
    /// <summary>
    /// Interaction logic for Department.xaml
    /// </summary>
    public partial class Department : Page
    {
        public readonly IDepartmentRepository _departmentRepository;
        public Department()
        {
            InitializeComponent();
            this._departmentRepository = new DepartmentRepository();
        }
        

        private void MouseCreateClick(object sender, RoutedEventArgs e)
        {
            DepartmentCreateWindow win = new DepartmentCreateWindow();
            win.ShowDialog();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            Paginations paginations = new Paginations()
            {
                PageNumber=1,
                PageSize=30
            };
            var department_for_counting = await _departmentRepository.GetTotalDepartment();
            TotalDepartmentlbl.Content = department_for_counting.ToString();



            var departments = await _departmentRepository.GetAllAsync(paginations);
            TopDepartmentlbl.Content= departments[0].name.ToString();
            int countActive = 0;
            int countNotActive = 0;
            foreach ( var department in departments )
            {
                if(department.is_active==true) countActive++;
                else countNotActive++;
                DepartmentViewUserControl departmentViewUserControl = new DepartmentViewUserControl();
                departmentViewUserControl.setData(department);
                MainWP.Children.Add(departmentViewUserControl);

            }
            ActivelDepartmentlbl.Content=countActive.ToString();
            NotActiveDepartmentlbl.Content= countNotActive.ToString();
        }
    }
}
