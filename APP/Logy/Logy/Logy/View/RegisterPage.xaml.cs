using Logy.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Security.Cryptography;
using Logy.Database.Tables;

namespace Logy.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
		}
        public void BtnRegister_Clicked(object sender, EventArgs e)
        {
            Regex rx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            var email = txtEmail.Text;
            var passwd = txtPwd.Text;
            var passwdconf = txtPwdConf.Text;

            try
            {

                if (email != "")
                {
                    if (rx.Match(email).Success)
                    {
                        if (passwd != "" || passwdconf != "")
                        {
                            if (!passwd.Contains("   ") || !passwd.Contains(" "))
                            {
                                CreateAccount(email, passwd);
                            }
                            else
                            {
                                throw new Exception("les mots de passe ne doivent pas contenir d'espace ou de tabulation");
                            }
                        }
                        else
                        {
                            throw new Exception("Rentrez les champs des mots de passe");
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
        private void CreateAccount(string email, string password)
        {
            DatabaseManager.GetDB().Execute("INSERT INTO Users(Username, Email, Password) VALUES(\"\", \"" + email+"\", \""+ HashMethod(password) + "\")");
            App.Current.MainPage = new LoginPage();
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
