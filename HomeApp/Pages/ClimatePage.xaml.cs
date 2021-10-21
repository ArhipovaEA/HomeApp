using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClimatePage : ContentPage
    {
        public ClimatePage()
        {
            InitializeComponent();
           
        }

		/// <summary>
		/// Внешние датчики
		/// </summary>
		private void get_wether(object sender, System.EventArgs e)
		{
			Grid grid = new Grid()
			{
				RowDefinitions =
				{
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
				},
				ColumnDefinitions =
				{
					new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)}
				},
				BackgroundColor = Color.Black,
				RowSpacing = 5
			};

			grid.Children.Add(new BoxView { Color = Color.LightBlue }, 0, 0);
			grid.Children.Add(new BoxView { Color = Color.Blue }, 0, 1);
			grid.Children.Add(new BoxView { Color = Color.Teal }, 0, 2);

			StackLayout topRow = new StackLayout() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
			topRow.Children.Add(new Label { Text = "В доме", FontSize = 40, HorizontalTextAlignment = TextAlignment.Center });
			topRow.Children.Add(new Label { Text = "+26 °С", FontSize = 60, HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.DarkBlue });
			grid.Children.Add(topRow, 0, 0);

			StackLayout midRow = new StackLayout() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
			midRow.Children.Add(new Label { Text = "На улице", FontSize = 40, HorizontalTextAlignment = TextAlignment.Center });
			midRow.Children.Add(new Label { Text = "+3 °С", FontSize = 60, HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.DarkBlue });
			grid.Children.Add(midRow, 0, 1);

			StackLayout btmRow = new StackLayout() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
			btmRow.Children.Add(new Label { Text = "Давление", FontSize = 40, HorizontalTextAlignment = TextAlignment.Center });
			btmRow.Children.Add(new Label { Text = "750 mm", FontSize = 60, HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.DarkBlue });
			grid.Children.Add(btmRow, 0, 2);

			Content = grid;
		}
}
}