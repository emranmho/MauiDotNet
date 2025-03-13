using Java.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter;

public partial class AreaPage : ContentPage
{
    private string[] _availableUnits = ["Acre", "Square Meter", "Square Kilometre", "Hectare", "Square Mile", "Square Yard",
        "Square Foot", "Square Inch"];


    public AreaPage()
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
        double[] conversionFactors = { 1, 4046.8564224, 0.0040468564, 0.4046856422, 0.0015624989, 4840, 43560, 6272640 };

        return sourceValue * conversionFactors[targetIndex] / conversionFactors[sourceIndex];
    }
}