using BMICalculator.Models;

namespace BMICalculator
{
    public partial class MainPage : ContentPage
    {
        private Bmi myBmi;
        public MainPage()
        {
            InitializeComponent();
            myBmi = new Bmi { BmiValue = 0 };
            BindingContext = myBmi;
        }

        private void SlrWeight_OnValueChanged(object? sender, ValueChangedEventArgs e)
        {
            CalculateBmi();
        }

        private void CalculateBmi()
        {
            Double height = SlrHeight.Value / 100;
            Double weight = SlrWeight.Value;
            
            myBmi.BmiValue = weight /(height * height);
        }
        
        private async void OnTooltipClicked(object sender, EventArgs e)
        {
            string bmiStandards = "BMI Standards:\n" +
                                  "Under Weight: < 18.5\n" +
                                  "Normal Weight: 18.5 - 24.9\n" +
                                  "Over Weight: 25 - 29.9\n" +
                                  "Obese: >= 30";

            await DisplayAlert("BMI Standards", bmiStandards, "OK");
        }
    }

}
