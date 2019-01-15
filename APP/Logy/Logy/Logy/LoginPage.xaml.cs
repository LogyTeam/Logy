using Logy.Database;
using Logy.Logbook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Security.Cryptography;
using Logy.Database.Tables;

namespace Logy
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            txtEmail.Text = "";
            txtPwd.Text = "";
        }


        public void btnConnection_clicked(object sender, EventArgs e)
        {
            Regex rx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            var email = txtEmail.Text;
            var passwd = txtPwd.Text;

            try
            {
                if (email != "")
                {
                    if (rx.Match(email).Success)
                    {
                        if (passwd != "")
                        {
                            if (!passwd.Contains("   ") || !passwd.Contains(" "))
                            {
                                Connection(email, passwd);
                            }
                            else
                            {
                                throw new Exception("les mots de passe ne doivent pas contenir d'espace ou de tabulation");
                            }
                        }
                        else
                        {
                            throw new Exception("Vous n'avez pas rentrer de mot de passe");
                        }
                    }
                    else
                    {
                        throw new Exception("Vous n'avez pas rentrer d'email valide");
                    }
                }
                else
                {
                    throw new Exception("Vous n'avez pas rentrer d'email");
                }

            }
            catch (Exception ex)
            {
                DisplayAlert("Erreur : ", ex.Message, "OK");
            }

        }
        public void BtnInscription_clicked()
        {
            App.Current.MainPage = new RegisterPage();
        }
        private void Connection(string email, string passwrd)
        {
            passwrd = HashMethod(passwrd);
            List<Users> users = DatabaseManager.GetDB().Query<Users>("SELECT * FROM Users WHERE Email=\""+email+"\" AND Password=\""+passwrd+"\"");
            if (users.Count == 0)
            {
                DisplayAlert("Erreur : ", "Email ou mot de passe incorrect", "OK");
            }
            else
            {
                DisplayAlert("OK : ", "T'es un bon gars !", "OK");
            }

        }

        private string HashMethod(string passwrd)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(passwrd));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

    }
}
