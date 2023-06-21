using Hospital_managment_system.Pages;
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

namespace Hospital_managment_system.Components.Departments
{
    /// <summary>
    /// Interaction logic for DepartmentViewUserControl.xaml
    /// </summary>
    public partial class DepartmentViewUserControl : UserControl
    {
        public long id { get ; private set; }
        public DepartmentViewUserControl()
        {
            InitializeComponent();
        }
        //public void setData(Department department)
        //{

        //}

        public void setData(Entities.Departments.Department department)
        {
            id= department.Id;
            DpNamelbl.Content = department.name;
            if (department.is_active==true)
            {
                IsActive_lbl.Content = "Active";               
            } else IsActive_lbl.Content = "Not Active";
            tbDescription.Text = department.description;


        }


    }
}
