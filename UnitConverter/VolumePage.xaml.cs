using Java.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter;

public partial class VolumePage : ContentPage
{
    private string[] _availableUnits = ["Litre", "Millilitre", "Cubic foot", "Cubic inch", "Gallon (US)", "Gallon (UK)"];


    public VolumePage()
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
        double[] conversionFactors = {  1, 1000, 0.0353147, 61.0237, 0.284, 0.219 };

        return sourceValue * conversionFactors[targetIndex] / conversionFactors[sourceIndex];
    }
}