using price_me.Services;

namespace price_me
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        CostingService service = new CostingService();

        private void Slider_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {

            if (string.IsNullOrEmpty(txtCost.Text))
                return;

            double value = double.Round(e.NewValue);
            lblMarkup.Text = value.ToString();  

            service.SetupCostingRequest(new models.CalculateRequest
            {
                CostPrice = double.Parse(txtCost.Text),
                IncVat = chkIncVat.IsChecked,
                Markup = int.Parse(lblMarkup.Text)
            });

            lblSelling.Text = service.GetSellingPrice().ToString();
            lblProfit.Text = service.GetMarkupValue().ToString();
        }
    }

}
  