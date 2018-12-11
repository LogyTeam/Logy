using Logy.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Logy
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public void btnConnection_clicked(object sender, EventArgs e)
        {
            DatabaseManager.Connect();
            List<Dictionary<string, string>> users = DatabaseManager.Select("SELECT * FROM user;");

            foreach (Dictionary<string, string> user in users)
            {
                this.lblInscription.Text = user["username"];
            }
        }
    }
}
