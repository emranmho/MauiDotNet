namespace UnitConverter;

public partial class LengthPage : ContentPage
{
    private string[] _availableUnits = ["Meter", "Kilometre", "Centimetre", "Millimetre", "Mile", "Yard", "Foot", "Inch"];
    

    public LengthPage()
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
        double[] conversionFactors = { 1, 0.001, 100, 1000, 0.000621371, 1.09341, 3.28084, 39.3701};

        return sourceValue * conversionFactors[targetIndex] / conversionFactors[sourceIndex];
    }
}