using Logy.Classes;
using Logy.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Logy.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddActivityPage : ContentPage
	{

		public AddActivityPage ()
		{
			InitializeComponent ();

			startTime.Time = DateTime.Now.TimeOfDay;


		}

		private void Button_Clicked(object sender, EventArgs e)
		{
            if (name.Text != null && name.Text != "")
            {
                DatabaseManager.GetDB().Execute("INSERT INTO ACTIVITIES(Title, Description, StartDate, EndDate, fk_idPROJECT) VALUES('" + name.Text.Replace("'", "''") + "', '" + ((description.Text != null) ? description.Text.Replace("'", "''") : "") + "', '" + new DateTime(App.lastDate.Year, App.lastDate.Month, App.lastDate.Day, startTime.Time.Hours, startTime.Time.Minutes, startTime.Time.Seconds) + "', '" + new DateTime(App.lastDate.Year, App.lastDate.Month, App.lastDate.Day, endTime.Time.Hours, endTime.Time.Minutes, endTime.Time.Seconds) + "', " + App.currentProject.id + ");");

                App.Current.MainPage = new ActivityPage(App.lastDate);
            }
            else
            {
                DisplayAlert("Erreur", "Le titre est obligatoire", "Ok");
            }
           
        }

        private void backButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ActivityPage(App.lastDate);
        }
    }
}