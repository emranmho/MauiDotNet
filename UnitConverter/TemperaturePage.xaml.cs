using Java.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter;

public partial class TemperaturePage : ContentPage
{
    private string[] _availableUnits = ["Celsius", "Fahrenheit", "Kelvin"];


    public TemperaturePage()
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

            ResultText.Text = $"Result :\n{resultValue} {_availableUnits[TargetPicker.SelectedIndex]}";
        }
        else
        {
            ResultText.Text = "";
        }
    }

    private double ConvertValue(double sourceValue, int sourceIndex, int targetIndex)
    {
        if (sourceIndex == targetIndex)
        {
            return sourceValue;
        }

        switch (sourceIndex)
        {
            case 0:
                return targetIndex == 1 ? (sourceValue * 9.0 / 5.0) + 32.0 : sourceValue + 273.15;
            case 1:
                return targetIndex == 0
                    ? (sourceValue - 32.0) * 5.0 / 9.0
                    : ((sourceValue - 32.0) * 5.0 / 9.0) + 273.15;
            case 2:
                return targetIndex == 0 ? sourceValue - 273.15 : ((sourceValue - 273.15) * 9.0 / 5.0) + 32.0;
            default:
                return sourceValue;
        }
    }

}