using System;
using System.Collections.Generic;
using System.Data;
using Xamarin.Forms;
using MySql.Data.MySqlClient;
using GSUACM.ViewModels;
using System.Diagnostics;
using System.Data.SqlClient;

namespace GSUACM.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

 

        // label close CLICK
        private void labelClose_Click(object sender, EventArgs e)
        {
            //this.Close();
            //Application.Exit();
        }

        // button login
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            String emailAddress = email.Text;
            String pword = password.Text;
            MySqlCommand command = new MySqlCommand("SELECT * FROM user WHERE email = @email and password = @pass", db.getConnection());
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password.Text;
            db.openConnection();
            adapter.SelectCommand = command;

            adapter.Fill(table);



            //check if the user exists or not
            if (table.Rows.Count>0)
            {
                this.IsVisible = false;
                MainPage mainform = new MainPage();
                mainform.IsVisible = true;
                db.closeConnection();
            }
            else
            {
                // check if the username field is empty
                if (emailAddress==null||emailAddress=="")
                {
                    DisplayAlert("Enter Your Username To Login", "Empty Username", "Ok");
                }
                // check if the password field is empty
                else if (pword==null||pword=="")
                {
                    DisplayAlert("Enter Your Password To Login", "Empty Password", "Ok");
                }

                // check if the username or the password don't exist
                else
                {
                    Console.WriteLine(command);
                    DisplayAlert("Wrong Username Or Password", "Wrong Data", "Ok");
                }
               
            }
            db.closeConnection();
        }
        // label go to signup CLICK
        private async void labelGoToSignUp_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }
        
   
    }
}

