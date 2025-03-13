using System.Globalization;

namespace BMICalculator.Models;

public class ValueToStringConverter : IValueConverter
{
    private const Double lim_normalWeight = 18.5F;
    private const Double lim_overWeight = 25.0F;
    private const Double lim_obeseWeight = 30.0F;
    
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var bmi = (double)value!;
        var result = string.Empty;
        
        switch (bmi)
        {
            case < lim_normalWeight:
                result = "Under Weight";
                break;
            case >= lim_normalWeight and < lim_overWeight:
                return "Normal Weight";
            case >= lim_overWeight and < lim_obeseWeight:
                return "Over Weight";
            case >= lim_obeseWeight:
                return "Obese Weight";
        }

        return result; 
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}