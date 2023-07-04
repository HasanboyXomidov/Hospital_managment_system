using Hospital_managment_system.Constants;
using Hospital_managment_system.Models;
using Hospital_managment_system.Security;
using MaterialDesignThemes.Wpf;
using Npgsql;
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

namespace Hospital_managment_system.Windows
{
    /// <summary>
    /// Interaction logic for Login_page.xaml
    /// </summary>
    public partial class Login_page : Window
    {
        public Login_page()
        {
            InitializeComponent();
        }

        public async void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var admin = new Admins();            
            string email = admin.email=Tb_Email.Text;                                    
            string password_hash = Tb_Password.Password.ToString();
            var checking_end = await CheckAync(email, password_hash);                        
            if (checking_end==true && password_hash.Length!=0 && password_hash.Length<32 && email.Length>12 && email.Length<35)
            {
                MessageBox.Show("Successfully signed in !");
                this.Close();

            } else MessageBox.Show("Not found user !");



        }
        public async Task<bool> CheckAync(string email, string password)
        {
            int check = 0;

            await using (var connection = new NpgsqlConnection(Db_Constants.DB_CONNECTION_STRING))
            {
                await connection.OpenAsync();
                string query = "select * from admins where email = @email";

                await using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("email", email);
                    //command.Parameters.AddWithValue("password_hash", password);

                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            string db_email = reader.GetString(3);
                            string password_check_hash = reader.GetString(4);  
                            string salt_check = reader.GetString(5);
                            var ch_h = Hashing.Verify(password, password_check_hash, salt_check);
                            //var ch_h =  Hashing.Verify("hasanboy123", "$2a$11$5drFhXOtfLoonrF8TzNo0eC2na01CREjYfPjt2qSr26nGfVMwYRaC", "15fae526-dc4e-408e-a30d-7a3a3fecf3b5");
                            if (ch_h==true)
                            {
                                check += 1;
                            }
                            //string db_password = reader.GetString(4);

                        }
                    }
                }


                await connection.CloseAsync();
            }
            if (check==1) return true ; else return false;
        }
        
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Tb_Password.PasswordChar = '\0';
        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Register_page register_Page = new Register_page();  
            register_Page.ShowDialog();
            this.Close();
        }
    }
}
