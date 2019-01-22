using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Logy.Classes;

namespace Logy
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
            loadProject();
        }

        public void loadProject()
        {

            ScrollView mainScroll = new ScrollView
            {
                
            };

            StackLayout mainStack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,

                VerticalOptions = LayoutOptions.StartAndExpand,
                Margin = new Thickness(0, 0, 1, 1),
                BackgroundColor = Color.LightSteelBlue,
            };

            StackLayout titleStack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,

                VerticalOptions = LayoutOptions.StartAndExpand,
                Margin = new Thickness(0, 0, 1, 1),
                BackgroundColor = Color.FromRgb(0,175,247),
            };

            Label title = new Label { FontSize = 32, Text = "Projets", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            titleStack.Children.Add(title);

            Button newButton = new Button { Text = "New", Command = new Command(() => App.user.CreateProject("NewProject", DateTime.Now))};
            titleStack.Children.Add(newButton);

            mainStack.Children.Add(titleStack);

            if (App.user != null)
            {
                foreach (Project p in App.user.Projects)
                {
                    StackLayout projectStack = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Margin = new Thickness(0, 1, 1, 1),
                        BackgroundColor = Color.LightSteelBlue,
                        StyleId = p.id.ToString(),

                        GestureRecognizers =
                    {
                        new TapGestureRecognizer {Command = new Command (()=>Debug.WriteLine ("clicked")),},
                    }
                    };

                    Image img = new Image { HeightRequest = 100, Source = "C:\\Users\\jason.crisante\\Documents\\Logy\\APP\\Logy\\Logy\\Logy\\Assets\\Images\\Folder.png" };

                    Label lbl = new Label { FontSize = 26, Text = p.Name, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
                    projectStack.Children.Add(img);
                    projectStack.Children.Add(lbl);
                    mainStack.Children.Add(projectStack);

                }

            }
            mainScroll.Content = mainStack;

            Content = mainScroll;


        }

        private void btnNew_Clicked(object sender, EventArgs e)
        {

        }
    }
}