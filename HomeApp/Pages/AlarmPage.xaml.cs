using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlarmPage : ContentPage
    {
        public AlarmPage()
        {
            InitializeComponent();
        }

        public void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            if (e.NewDate >= DateTime.Today)
            {
                VisualStateManager.GoToState(datePicker, "Valid");
                VisualStateManager.GoToState(timePicker, "Valid");
            }
            else
            {
                VisualStateManager.GoToState(datePicker, "Invalid");
            }

            if (e.NewDate == DateTime.Today & timePicker.Time.Hours < DateTime.Now.Hour)
            {
                VisualStateManager.GoToState(timePicker, "Invalid");
            }
            else if (e.NewDate == DateTime.Today & timePicker.Time.Hours == DateTime.Now.Hour & timePicker.Time.Minutes < DateTime.Now.Minute)
            {
                VisualStateManager.GoToState(timePicker, "Invalid");
            }
            else
            {
                VisualStateManager.GoToState(timePicker, "Valid");
            }
        }

        public void TimePicker_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Time")
            {
                //labelTime.Text = "Вы выбрали " + timePicker.Time;
                var d = DateTime.Today;
                var tt = DateTime.Now.ToString("HH:mm:ss");
                var tp = timePicker.Time.ToString();

                if (datePicker.Date < DateTime.Today)
                {
                    // SetState(timePicker, true);
                    VisualStateManager.GoToState(timePicker, "Invalid");
                }
                else if (datePicker.Date == DateTime.Today & timePicker.Time.Hours < DateTime.Now.Hour)
                {
                    VisualStateManager.GoToState(timePicker, "Invalid");
                }
                else if (datePicker.Date == DateTime.Today & timePicker.Time.Hours == DateTime.Now.Hour & timePicker.Time.Minutes < DateTime.Now.Minute)
                {
                    VisualStateManager.GoToState(timePicker, "Invalid");
                }
                else
                {
                    VisualStateManager.GoToState(timePicker, "Valid");
                }
            }
        }

        void SetState(Label label, bool isValid)
        {
            string visualState = isValid ? "Valid" : "Invalid";
            VisualStateManager.GoToState(label, visualState);

        }
        public void slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (labelSlider != null)
                labelSlider.Text = String.Format("Выбрано: {0:F1}", e.NewValue.ToString("0"));
        }

        public void switcher_Toggled(object sender, ToggledEventArgs e)
        {
            if (!e.Value)
            {
                labelSwitch.Text = "Нет";
                return;
            }

            labelSwitch.Text = "Да";
        }

        private void OnButtonClicked(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            button.Text = "Нажато!";

            datePicker.IsEnabled = false;
            timePicker.IsEnabled = false;
            sliderControl.IsEnabled = false;
            switchControl.IsEnabled = false;

            labelSave.Text = "Будильник установлен на " + datePicker.Date.ToString("dd.MM") + " " + timePicker.Time.ToString();

        }

    }

 }