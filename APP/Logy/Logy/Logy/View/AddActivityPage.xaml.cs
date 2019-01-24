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
			// Inserer l'activité dans la base de donnée
		}
	}
}