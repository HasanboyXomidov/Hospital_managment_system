using Hospital_managment_system.Entities.Departments;
using Hospital_managment_system.Helpers;
using Hospital_managment_system.Interfaces.Departments;
using Hospital_managment_system.Repositories.Departments;
using Hospital_managment_system.Repositories.Doctors;
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

namespace Hospital_managment_system.Windows.Departments
{
    /// <summary>
    /// Interaction logic for DepartmentCreateWindow.xaml
    /// </summary>
    public partial class DepartmentCreateWindow : Window
    {
        public readonly IDepartmentRepository _departmentrepository;
        public DepartmentCreateWindow()
        {
            InitializeComponent();
            this._departmentrepository = new DepartmentRepository();
        }
        

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int cnt = 0;
            if(lblName.Text.Length!=0 && lblName.Text.Length<50) cnt++;            
            if(cnt>0)
            {
                Department department = new Department();
                department.name = lblName.Text;
                if (cbIs_active.IsChecked == true)
                {
                    department.is_active = true;
                }
                else department.is_active = false;
                department.description = new TextRange(rbDescription.Document.ContentStart, rbDescription.Document.ContentEnd).Text;
                department.created_at = department.updated_at = TimeHelper.GetDateTime();
                var result = await _departmentrepository.CreateAsync(department);
                if (result > 0) { MessageBox.Show("Success"); this.Close(); }
                else MessageBox.Show("Errorr");
            }            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
    }
}
