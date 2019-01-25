using Logy.Classes;
using Logy.Database;
using Logy.Database.Tables;
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

        public ActivityPage()
        {
            InitializeComponent();
        }

        public ActivityPage (DateTime date)
		{
			InitializeComponent ();

            LoadContent(date);        
		}

        public void LoadContent(DateTime date)
        {

            pageTitle.Text = "Activités - " + date.Date.ToString("dd.MM.yyyy");

            List<Activities> dbActivities = DatabaseManager.GetDB().Query<Activities>("SELECT * FROM ACTIVITIES WHERE fk_idPROJECT="+App.currentProject.id+ " ORDER BY StartDate ASC"); //Load activity
            dbActivities = dbActivities.Where(x => x.StartDate.Date == date.Date).ToList();

            List<Activity> activities = new List<Activity>();

            dbActivities.ForEach(x => activities.Add(x.CreateObject()));

            ScrollView scrollview = Content.FindByName<ScrollView>("sc");
            StackLayout mainStack = new StackLayout();

            foreach (Activity activity in activities)
            {
                StackLayout activityLayout = new StackLayout { BackgroundColor = Color.LightBlue};
                Label titleLabel = new Label { BackgroundColor = Color.SkyBlue, Text = activity.StartHour.Hour + ":" + activity.StartHour.Minute + " - " + activity.EndHour.Hour + ":" + activity.EndHour.Minute + " : " + activity.Title, TextColor = Color.Black };
                Label content = new Label { Text = activity.Description, TextColor = Color.Black, Margin = new Thickness(10, 1, 1, 1), HeightRequest = 60, LineBreakMode = LineBreakMode.WordWrap };

                activityLayout.Children.Add(titleLabel);
                activityLayout.Children.Add(content);

                mainStack.Children.Add(activityLayout);
            }

            scrollview.Content = mainStack;
        }

        private void addButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new AddActivityPage();
        }

        private void backButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new LogbookPage(App.currentProject);
        }
    }
}