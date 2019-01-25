using Logy.Classes;
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
	public partial class ActivityPage : ContentPage
	{
		public ActivityPage ()
		{
			InitializeComponent ();

			List<Activity> activities = new List<Activity>(); //Load activity

			ScrollView scrollview = Content.FindByName<ScrollView>("sc");

			foreach (Activity activity in activities)
			{
				
			}
		}
	}
}