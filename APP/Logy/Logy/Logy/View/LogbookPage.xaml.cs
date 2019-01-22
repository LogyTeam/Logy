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
        DateTime dateTime = DateTime.Now;

        Grid grid;
        StackLayout stackLayout;

        public LogbookPage()
        {
            InitializeComponent();

            grid = Content.FindByName<Grid>("gr");
            stackLayout = Content.FindByName<StackLayout>("dateMonth");

            var btn = new Button
            {
                Text = "Précédent"
            };

            btn.Clicked += new EventHandler(PreviousMonth);

            stackLayout.Children.Add(btn);


            var lbl = new Label
            {
                Text = this.dateTime.ToString("MMMM yyyy"),
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20,
                ClassId = "lblDate"
            };


            stackLayout.Children.Add(lbl);

            btn = new Button
            {
                Text = "Suivant"
            };

            btn.Clicked += new EventHandler(NextMonth);

            stackLayout.Children.Add(btn);


            DateTime.DaysInMonth(dateTime.Year, dateTime.Month);

            var dateMax = 31;

            
        }

        private void UpdateLabelDate()
        {
            Label label = (Label)this.stackLayout.Children.First(x => x.ClassId == "lblDate");

            label.Text = this.dateTime.ToString("MMMM yyyy");
        }

        private void NextMonth(object sender, EventArgs e)
        {
            if (this.dateTime.Month == 12)
            {
                this.dateTime = new DateTime(this.dateTime.Year + 1, 1, 1);
            }
            else
            {
                this.dateTime = this.dateTime.AddMonths(1);
            }
            UpdateLabelDate();
        }

        private void PreviousMonth(object sender, EventArgs e)
        {
            if (this.dateTime.Month == 1)
            {
                this.dateTime = new DateTime(this.dateTime.Year - 1, 12, 1);
            }
            else
            {
                this.dateTime = this.dateTime.AddMonths(-1);
            }
            UpdateLabelDate();
        }
    }
}