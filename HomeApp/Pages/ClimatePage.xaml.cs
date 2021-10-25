using System;
using System.Collections.Generic;
using System.ComponentModel;
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

		private void set_alarm(object sender, System.EventArgs e)
		{
            stackLayout = new StackLayout { Padding = new Thickness(60) };

            Content = stackLayout;

            // Создаем виджет выбора даты
            var datePicker = new DatePicker
            {
                Format = "D",
                // Диапазон дат: +/- неделя
                MaximumDate = DateTime.Now.AddDays(7),
                MinimumDate = DateTime.Now.AddDays(-7),
            };
            var datePickerText = new Label { Text = "Дата запуска будильника:", Margin = new Thickness(0, 30, 0, 0) };

            stackLayout.Children.Add(datePickerText);
            stackLayout.Children.Add(datePicker);

            // Виджет выбора времени.
            var timePickerText = new Label { Text = "Время запуска будильника:", Margin = new Thickness(0, 30, 0, 0) };
            var timePicker = new TimePicker
            {
                Time = new TimeSpan(0, 0, 0)
            };

            stackLayout.Children.Add(timePickerText);
            stackLayout.Children.Add(timePicker);

            Slider slider = new Slider
            {
                Minimum = 0,
                Maximum = 10,
                Value = 5.0,
                ThumbColor = Color.DodgerBlue,
                MinimumTrackColor = Color.DodgerBlue,
                MaximumTrackColor = Color.Gray
            };
            var sliderText = new Label { Text = $"Громкость сигнала будильника: {slider.Value}", HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(0, 30, 0, 0) };
            stackLayout.Children.Add(sliderText);
            stackLayout.Children.Add(slider);

            // Создаем заголовок для переключателя
            var switchHeader = new Label { Text = "Возможность повторения сигнала каждый день:", HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(0, 30, 0, 0) };
            stackLayout.Children.Add(switchHeader);

            // Создаем переключатель
            Switch switchControl = new Switch
            {
                IsToggled = false,
                HorizontalOptions = LayoutOptions.Center,
                ThumbColor = Color.DodgerBlue,
                OnColor = Color.LightSteelBlue,
            };
            stackLayout.Children.Add(switchControl);

            var button = new Button();
            button.Text = "Сохранить";
            button.BackgroundColor = Color.Silver;
            button.Margin = new Thickness(10, 30, 0, 0);
            button.CornerRadius = 15;

            stackLayout.Children.Add(button);

            button.Clicked += (sender1, e1) => button_Click(sender1, e1, datePicker.Date.ToString("dd.MM.yyyy"), timePicker.Time.ToString());

            // Регистрируем обработчик события выбора даты
            datePicker.DateSelected += (sender1, e1) => DateSelectedHandler(sender1, e1, datePickerText);
            // Регистрируем обработчик события выбора времени
            timePicker.PropertyChanged += (sender1, e1) => TimeChangedHandler(sender1, e1, timePickerText, timePicker);
            // Регистрируем обработчик события на громкость
            slider.ValueChanged += (sender1, e1) => VolumeChangedHandler(sender1, e1, sliderText);
            // Регистрируем обработчик события переключения
            switchControl.Toggled += (sender1, e1) => SwitchHandler(sender1, e1, switchHeader);
        }

        // Регистрируем обработчик события выбора даты
        public void button_Click(object sender, EventArgs e, string date, string time)
        {
            stackLayout = new StackLayout { Padding = new Thickness(60) };

            Content = stackLayout;

            var setAlarm = new Label { Text = $"Будильник сработает:", FontSize = 19, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, Padding = new Thickness(30, 100, 30, 10) };
            var setAlarm2 = new Label { Text = date + " " + time, FontSize = 19, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, Padding = new Thickness(30, 25, 30, 10) };

            stackLayout.Children.Add(setAlarm);
            stackLayout.Children.Add(setAlarm2);
        }

        public void DateSelectedHandler(object sender, DateChangedEventArgs e, Label datePickerText)
        {
            // При срабатывании выбора - будет меняться информационное сообщение.
            datePickerText.Text = "Будильник запустится " + e.NewDate.ToString("dd/MM/yyyy");
        }
        public void TimeChangedHandler(object sender, PropertyChangedEventArgs e, Label timePickerText, TimePicker timePicker)
        {
            // Обновляем текст сообщения, когда появляется новое значение времени
            if (e.PropertyName == "Time")
                timePickerText.Text = "В " + timePicker.Time;
        }
        public void SwitchHandler(object sender, ToggledEventArgs e, Label header)
        {
            if (!e.Value)
            {
                header.Text = "Без повторения";
                return;
            }

            header.Text = "Повторять каждый день";
        }

        public void VolumeChangedHandler(object sender, ValueChangedEventArgs e, Label sliderText)
        {
            // При срабатывании выбора - будет меняться информационное сообщение.
            sliderText.Text = $"Громкость сигнала будильника: {e.NewValue.ToString("0")}";
        }

    }
}