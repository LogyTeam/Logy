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
	public partial class LogbookPage : ContentPage
	{
        DateTime dateTime = DateTime.Now;

        Grid grid;
        StackLayout stackLayout;
        Project project = null;

        public LogbookPage(Project project)
        {
            InitializeComponent();

            this.project = project;

            pageTitle.Text = project.Name;

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

            LoadDate();

		}

        public void LoadDate()
        {

            List<Button> newChildren = new List<Button>();

            List<Activities> activities = DatabaseManager.GetDB().Query<Activities>("SELECT * FROM ACTIVITIES WHERE fk_idPROJECT="+project.id);

            var dateMax = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);

            int row = 0;
            int column = 0;
            for (int i = 1; i <= dateMax; i++)
            {
                int nbAct = activities.Where(x => x.StartDate.Date == new DateTime(dateTime.Year, dateTime.Month, i).Date).Count();
                Button btn = new Button { Text = i.ToString(), BackgroundColor = (nbAct > 0) ? Color.SteelBlue : Color.LightSteelBlue, };

                Grid.SetRow(btn, row);
                Grid.SetColumn(btn, column);

                btn.Clicked += new EventHandler(btnDateClicked);

                newChildren.Add(btn);

                column++;

                if (column > 5)
                {
                    row++;
                    column = 0;
                }
            }
            grid.Children.Clear();
            newChildren.ForEach(x => grid.Children.Add(x));

        }

        private void btnDateClicked(object sender, EventArgs e)
		{
			var btn = (Button)sender;

            App.lastDate = new DateTime(this.dateTime.Year, this.dateTime.Month, int.Parse(btn.Text));
            App.Current.MainPage = new ActivityPage(new DateTime(this.dateTime.Year, this.dateTime.Month, int.Parse(btn.Text)));
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
            LoadDate();
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
            LoadDate();

        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }
    }
}