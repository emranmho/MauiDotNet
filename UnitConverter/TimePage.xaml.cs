using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter;

public partial class TimePage : ContentPage
{
    private string[] _availableUnits = ["Hour","Second", "Millisecond", "Microsecond", "Minute","Day", "Week", "Month", "Year" ];


    public TimePage()
    {
        InitializeComponent();
        SourcePicker.ItemsSource = _availableUnits;
        SourcePicker.SelectedIndex = 0;
        TargetPicker.ItemsSource = _availableUnits;
        TargetPicker.SelectedIndex = 1;
    }

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(SourceText.Text)
            && double.TryParse(SourceText.Text, out double sourceValue))
        {
            double resultValue = ConvertValue(sourceValue, SourcePicker.SelectedIndex, TargetPicker.SelectedIndex);

            ResultText.Text = $"Result :\n{resultValue:F2} {_availableUnits[TargetPicker.SelectedIndex]}";
        }
        else
        {
            ResultText.Text = "";
        }
    }

    private double ConvertValue(double sourceValue, int sourceIndex, int targetIndex)
    {
        double[] conversionFactors = { 1, 3600, 3600000, 3600000000000, 60, 0.0416666667, 0.005952381, 0.0013689254, 0.0001140771 };

        return sourceValue * conversionFactors[targetIndex] / conversionFactors[sourceIndex];
    }
}