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
	public partial class LogbookPage : ContentPage
	{
		public LogbookPage ()
		{
			InitializeComponent ();

            Grid grid = Content.FindByName<Grid>("gr");

            var dateMax = 31;

            for (int row = 0; row < 5;row++)
            {
                for(int colum = 0;colum < 6; colum++)
                {
                    

                    for (int x = 1; x <= dateMax+1; x++)
                    {
                        var butt = new Button { Text = x.ToString(), BackgroundColor = Color.LightSteelBlue };

                        Grid.SetRow(butt, row);
                        Grid.SetColumn(butt, colum);

                        grid.Children.Add(butt);
                    }
                }
            }

            
           
		}
	}
}