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
	public partial class EditProjectPage : ContentPage
	{
		public EditProjectPage ()
		{
			InitializeComponent ();

			name.Text = ""; // Mettre le nom du projet actuel 
			description.Text = ""; // Mettre la description du projet

		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			//Mettre à jour la base de donnée
		}
	}
}