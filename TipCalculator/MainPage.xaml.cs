namespace TipCalculator
{
    public partial class MainPage : ContentPage
    {
        private double billAmount = 0.00d;
        private int tip = 0;
        private double tipAmount = 0.00d;
        private int split = 1;
        private double perPersonAmount = 0.00d;

        public MainPage()
        {
            InitializeComponent();
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            LblTip.Text = tip.ToString();
            LblTipAmount.Text = tipAmount.ToString("F2");
            LblSplit.Text = split.ToString();

            LblSplitAmount.Text = perPersonAmount.ToString("F2");
        }

        private void TbTotal_Completed(object sender, EventArgs e)
        {
            billAmount = double.Parse(TbTotal.Text);

            TbTotal.Unfocus();
            SlrTip.Focus();
            Calculate();
        }

        private void Calculate()
        {
            tipAmount = billAmount * tip / 100;
            perPersonAmount = (billAmount + tipAmount) / split;
            UpdateDisplay();
        }

        private void SlrTip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            tip = (int)SlrTip.Value;
            Calculate();
        }

        private void BtnMinus_Clicked(object sender, EventArgs e)
        {
            if (split > 1)
            {
                split--;
            }
            Calculate();
        }

        private void BtnPlus_Clicked(object? sender, EventArgs e)
        {
            split++;
            Calculate();
        }
    }

}
