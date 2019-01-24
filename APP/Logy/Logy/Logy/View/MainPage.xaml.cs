using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Logy.Classes;

namespace Logy.View
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
                Orientation = StackOrientation.Horizontal,

                VerticalOptions = LayoutOptions.StartAndExpand,
                Margin = new Thickness(0, 0, 1, 1),
                BackgroundColor = Color.FromRgb(0,175,247),
            };

            Button logoutButton = new Button { Text = "Back", HorizontalOptions = LayoutOptions.Start, Command = new Command(() => {
                App.user = null;
                App.Current.MainPage = new LoginPage();
            }) };
            Label title = new Label { FontSize = 32, Text = "Projets", HorizontalOptions = LayoutOptions.CenterAndExpand };
            titleStack.Children.Add(logoutButton);
            titleStack.Children.Add(title);

            Button newButton = new Button { Text = "New", Command = new Command(() => { App.Current.MainPage = new AddProjectPage(); })};
            titleStack.Children.Add(newButton);
            mainStack.Children.Add(titleStack);

            if (App.user != null)
            {
                foreach (Project p in App.user.Projects)
                {
                    StackLayout projectStack = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        BackgroundColor = Color.LightSteelBlue,
                        GestureRecognizers =
                        {
                            new TapGestureRecognizer {Command = new Command (()=>ClickOnProject(p) )},
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

        public void ClickOnProject(Project project)
        {
            App.Current.MainPage = new LogbookPage(project);
        }
    }
}