using Hospital_managment_system.Entities.PatientsDoctors;
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

namespace Hospital_managment_system.Windows.PatientsDoctorsPage
{
    /// <summary>
    /// Interaction logic for QueueWindowShow.xaml
    /// </summary>
    public partial class QueueWindowShow : Window
    {
        public QueueWindowShow()
        {
            InitializeComponent();
        }
        public void setData(PatientDoctor patientDoctor)
        {
            lblqueue.Content = patientDoctor.patient_queue;
        }
    }
}
