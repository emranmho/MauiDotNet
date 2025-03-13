using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BMICalculator.Models;

public class Bmi : INotifyPropertyChanged
{
    private double _bmiValue;

    public double BmiValue
    {
        get => _bmiValue;
        set
        {
            if (_bmiValue != value)
            {
                _bmiValue = value;
                NotifyPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}