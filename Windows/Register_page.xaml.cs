using Hospital_managment_system.Constants;
using Hospital_managment_system.Models;
using Hospital_managment_system.Security;
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
    /// Interaction logic for Register_page.xaml
    /// </summary>
    public partial class Register_page : Window
    {
        public Register_page()
        {
            InitializeComponent();
        }

        private async void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

            int cnt = 0;
            if (Tb_FirstName.Text.Length > 0 && Tb_FirstName.Text.Length < 32) cnt += 1;
            if (Tb_SecondName.Text.Length > 0 && Tb_SecondName.Text.Length < 32) cnt += 1;
            if (Tb_Email.Text.Length > 0 && Tb_Email.Text.Length < 32 && Tb_Email.Text.Contains('@') && Tb_Email.Text.Contains('.')) cnt += 1;
            if (Tb_Password.Password.Length >= 8 && Tb_Password.Password.Length < 32) cnt += 1;

            if (cnt == 4)
            {
                var admin = new Admins();
                admin.first_name = Tb_FirstName.Text;
                admin.last_name = Tb_SecondName.Text;
                admin.email = Tb_Email.Text;

                string password = Tb_Password.Password.ToString();
                var hasherResult = Hashing.Hash(password);

                admin.password_hash = hasherResult.PasswordHash;
                admin.salt = hasherResult.salt;

                try
                {
                    var dbResult = await RegisterAync(admin);
                    if (dbResult) MessageBox.Show("Successfully Registred!! ");
                    else MessageBox.Show("!! Error Try again !!");
                }
                catch
                {
                    MessageBox.Show("Error Something wrong");

                }

            }
            else MessageBox.Show("Check your informations , something wrong !😑 ");

        }
        public async Task<bool> RegisterAync(Admins admin)
        {
            int result = 0;
            await using (var connection = new NpgsqlConnection(Db_Constants.DB_CONNECTION_STRING))
            {
                await connection.OpenAsync();
                string query = "insert into admins(first_name,second_name,email,password_hash,salt) values(@f_name,@s_name,@email,@password_h,@salt);";
                await using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("f_name",admin.first_name);
                    command.Parameters.AddWithValue("s_name", admin.last_name);
                    command.Parameters.AddWithValue("email",admin.email);
                    command.Parameters.AddWithValue("password_h", admin.password_hash);
                    command.Parameters.AddWithValue("salt", admin.salt);

                    result = await command.ExecuteNonQueryAsync();   
                }

                await connection.CloseAsync();
            }
            return result > 0;


        }
    }
}
