namespace UnitConverter;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void LengthBtn_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new LengthPage());
    }

    private async void WeightBtn_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new WeightPage());
    }

    private async void VolumeBtn_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new VolumePage());
    }

    private async void TempBtn_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new TemperaturePage());
    }

    private async void AreaBtn_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new AreaPage());
    }

    private async void TimeBtn_OnClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new TimePage());
    }
}