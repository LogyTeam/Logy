using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            StackLayout mainStack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,

                VerticalOptions = LayoutOptions.StartAndExpand,
                Margin = new Thickness(0, 0.5, 1, 0),
                BackgroundColor = Color.LightSteelBlue,
            };

            StackLayout titleStack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,

                VerticalOptions = LayoutOptions.StartAndExpand,
                Margin = new Thickness(0.50, 0.5, 1, 0),
                BackgroundColor = Color.Green,
            };
            Label title = new Label { FontSize = 32, Text = "Projets", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            titleStack.Children.Add(title);



            StackLayout projectStack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,

                VerticalOptions = LayoutOptions.StartAndExpand,
                Margin = new Thickness(0.50, 0.5, 0.5, 0.5),
                BackgroundColor = Color.Brown,
            };

            Image img = new Image { HeightRequest = 100, Source = "C:\\Users\\jason.crisante\\Documents\\Logy\\APP\\Logy\\Logy\\Logy\\Assets\\Images\\Folder.png" };
            Label lbl = new Label { FontSize = 26, Text = "2", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Margin = new Thickness(0.50, 0.5, 0.5, 0.5) };
            projectStack.Children.Add(img);
            projectStack.Children.Add(lbl);

            Image img2 = new Image { HeightRequest = 100, Source = "C:\\Users\\jason.crisante\\Documents\\Logy\\APP\\Logy\\Logy\\Logy\\Assets\\Images\\Folder.png" };
            Label lbl2 = new Label { FontSize = 26, Text = "3", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Margin = new Thickness(0.50, 0.5, 0.5, 0.5) };
            projectStack.Children.Add(img2);
            projectStack.Children.Add(lbl2);


            mainStack.Children.Add(titleStack);
            mainStack.Children.Add(projectStack);



            Content = mainStack;
         /*   Content = new StackLayout
            {
                
                Parent = st,
                Orientation = StackOrientation.Horizontal,
                
                VerticalOptions = LayoutOptions.StartAndExpand,
                Margin = new Thickness(0, 0, 1, 0),
                BackgroundColor = Color.LightSteelBlue,
                Children =
                {
                                      
                    new Image { HeightRequest = 100,Source = "C:\\Users\\jason.crisante\\Documents\\Logy\\APP\\Logy\\Logy\\Logy\\Assets\\Images\\Folder.png" },
                    new Label { FontSize=26,Text="2",HorizontalOptions=LayoutOptions.Center,VerticalOptions=LayoutOptions.Center },
                }
            };
            */

        }

    
    }
}