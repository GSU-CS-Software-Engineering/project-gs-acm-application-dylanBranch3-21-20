using GSUACM.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Xamarin.Forms;

namespace GSUACM.Views
{
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }
        // textbox first name ENTER
        private void textBoxFirstname_Enter(object sender, EventArgs e)
        {
            String fname = firstName.Text;
            if (fname.ToLower().Trim().Equals("first name"))
            {
                firstName.Text = "";
                
            }
        }

        // textbox first name LEAVE
        private void textBoxFirstname_Leave(object sender, EventArgs e)
        {
            String fname = lastName.Text;
            if (fname.ToLower().Trim().Equals("first name") || fname.Trim().Equals(""))
            {
                lastName.Text = "first name";
                
            }
        }


        // textbox last name ENTER
        private void textBoxLastname_Enter(object sender, EventArgs e)
        {
            String lname = lastName.Text;
            if (lname.ToLower().Trim().Equals("last name"))
            {
                lastName.Text = "";
                
            }
        }


        // textbox last name LEAVE
        private void textBoxLastname_Leave(object sender, EventArgs e)
        {
            String lname = lastName.Text;
            if (lname.ToLower().Trim().Equals("last name") || lname.Trim().Equals(""))
            {
                lastName.Text = "last name";
               
            }
        }

        // textbox email ENTER
        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            String email = emailaddress.Text;
            if (email.ToLower().Trim().Equals("email address"))
            {
                emailaddress.Text = "";
                
            }
        }
        // textbox email LEAVE
        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            String email = emailaddress.Text;
            if (email.ToLower().Trim().Equals("email address") || email.Trim().Equals(""))
            {
                emailaddress.Text = "email address";
                
            }
        }
        // textbox phone number ENTER
        private void textBoxPhone_Enter(object sender, EventArgs e)
        {
            String phone = phoneNum.Text;
            if (phone.ToLower().Trim().Equals("123-456-9123"))
            {
                phoneNum.Text = "";

            }
        }

        // textbox phone number LEAVE
        private void textBoxPhone_Leave(object sender, EventArgs e)
        {
            String phone = phoneNum.Text;
            if (phone.ToLower().Trim().Equals("123-456-9123") || phone.Trim().Equals(""))
            {
                lastName.Text = "123-456-9123";

            }
        }
        // textbox password ENTER
        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            String pword = password.Text;
            if (pword.ToLower().Trim().Equals("password"))
            {
                password.Text = "";
                password.IsPassword = true;
                
            }
        }

        // textbox password LEAVE
        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            String pword = password.Text;
            if (pword.ToLower().Trim().Equals("password") || pword.Equals(""))
            {
                password.Text = "password";
                password.IsPassword = false;
              
            }
        }

        // textbox confirm password ENTER
        private void textBoxPasswordConfirm_Enter(object sender, EventArgs e)
        {
            String cpassword = passwordConfirm.Text;
            if (cpassword.ToLower().Trim().Equals("confirm password"))
            {
                passwordConfirm.Text = "";
                passwordConfirm.IsPassword = true;
                
            }
        }

        // textbox confirm password LEAVE
        private void textBoxPasswordConfirm_Leave(object sender, EventArgs e)
        {
            String cpassword = passwordConfirm.Text;
            if (cpassword.ToLower().Trim().Equals("confirm password") ||
                cpassword.ToLower().Trim().Equals("password") ||
                cpassword.Trim().Equals(""))
            {
                passwordConfirm.Text = "confirm password";
                passwordConfirm.IsPassword = false;
                
            }
        }
        // button signup
        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            // add a new user

           DB db = new DB();
           MySqlCommand command = new MySqlCommand("INSERT INTO user(fname,lname,phone,email,password) VALUES (@fn, @ln,@ph,@email, @pass)", db.getConnection());

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = firstName.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lastName.Text;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phoneNum.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = emailaddress.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password.Text;

            // open the connection
            db.openConnection();

            // check if the textboxes contains the default values 
            if (!checkTextBoxesValues())
            {
                // check if the password equal the confirm password
                if (password.Text.Equals(passwordConfirm.Text))
                {
                    // check if this username already exists
                
           
                        // execute the query
                        if (command.ExecuteNonQuery() == 1)
                        {
                            DisplayAlert("Your Account Has Been Created", "Account Created","Ok");
                            labelGoToLogin_Click(sender,e);
                        }
                        else
                        {
                            DisplayAlert("ERROR","Account Failed to Create","Ok");
                        }
                    
                }
                else
                {
                    DisplayAlert("Wrong Confirmation Password", "Password Error", "Ok");
                }

            }
            else
            {
                DisplayAlert("Enter Your Information First", "Empty Data", "Ok");
            }



            // close the connection
            db.closeConnection();

        }


    

        // check if the textboxes contains the default values
        public Boolean checkTextBoxesValues()
        {
            String fname = firstName.Text;
            String lname = lastName.Text;
            String email = emailaddress.Text;
            String phone = phoneNum.Text;
            String pass = password.Text;

            if (fname.Equals("first name") || lname.Equals("last name") ||
                email.Equals("email address") || phone.Equals("123-456-9123")
                || pass.Equals("password"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // label go to the login form CLICK
        private async void labelGoToLogin_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

    }
}

