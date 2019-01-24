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
	public partial class EditActivityPage : ContentPage
	{
		public EditActivityPage ()
		{
			InitializeComponent ();

			name.Text = ""; // Nom de l'activité
			description.Text = ""; // Description de l'activité
			startTime.Time = new TimeSpan(); // Mettre l'heure du début
			endTime.Time = new TimeSpan(); // Mettre l'heure de fin
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			// Mettre à jour les infos dans la db
		}
	}
}