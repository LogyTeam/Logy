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
	public partial class AddProjectPage : ContentPage
	{
		public AddProjectPage ()
		{
			InitializeComponent ();
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
            // Inserer l'activité dans la base de donnée

            if (name.Text != "")
            {
                App.user.CreateProject(name.Text, description.Text, DateTime.Now);
                App.Current.MainPage = new MainPage();
            }

		}
	}
}