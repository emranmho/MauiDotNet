using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter;

public partial class WeightPage : ContentPage
{
    private string[] _availableUnits = ["Kilogram", "Gram", "Milligram", "Tonne", "Stone", "Pound", "Ounce"];


    public WeightPage()
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

            ResultText.Text = $"Result :\n{resultValue.ToString("F2")} {_availableUnits[TargetPicker.SelectedIndex]}";
        }
        else
        {
            ResultText.Text = "";
        }
    }

    private double ConvertValue(double sourceValue, int sourceIndex, int targetIndex)
    {
        double[] conversionFactors = { 1, 1000, 1000000, 0.001, 0.157473, 2.20462, 35.274 };

        return sourceValue * conversionFactors[targetIndex] / conversionFactors[sourceIndex];
    }
}