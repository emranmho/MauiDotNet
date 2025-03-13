namespace ColorPicker
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object? sender, EventArgs e)
        {
            SetBackgroundColor(Color.FromRgb(0, 0, 0));
        }

        private void SetBackgroundColor(Color color)
        {
            LblInfo.Text = "";
            AppBackground.BackgroundColor = color;
            RgbValue.Text = color.ToHex();
        }

        private void slrValue_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var red = RValue.Value;
            var green = GValue.Value;
            var blue = BValue.Value;

            SetBackgroundColor(Color.FromRgb(red, green, blue));
        }

        private void GenerateRandomColor(object sender, EventArgs e)
        {
            var random = new Random();

            var color = Color.FromRgb(
                random.Next(0, 255),
                random.Next(0, 255),
                random.Next(0, 255));

            SetBackgroundColor(color);

        }

        private async void CopyBtn_Clicked(object? sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(RgbValue.Text);
            LblInfo.Text = "Copied to clipboard";
        }
    }

}
