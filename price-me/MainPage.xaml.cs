using price_me.Services;
using price_me.models;


namespace price_me
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        CostingService service;
        CalculateRequest request;




        public MainPage()
        {

            InitializeComponent();

            service = new CostingService();
            request = new CalculateRequest();
        }



        private void Slider_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {

            if (string.IsNullOrEmpty(txtCost.Text))
                return;

            double value = double.Round(e.NewValue);
            lblMarkup.Text = $"{value.ToString()} %";

            request.CostPrice = double.Parse(txtCost.Text);
            request.IncVat = chkIncVat.IsChecked;
            request.Markup = int.Parse(value.ToString());

            service.SetupCostingRequest(request);

            setSellingPriceAndProfit();

        }

        private void sldVolumne_ValueChanged(object sender, ValueChangedEventArgs e)
        {

            double value = double.Round(e.NewValue);

            if (string.IsNullOrEmpty(lblProfit.Text))
                return;

            if (value < 1)
                return;

            if (double.Parse(lblProfit.Text) <= 1)
                return;

            service.SetupCostingRequest(request);
            setSellingPriceAndProfit();


            lblVolume.Text = value.ToString();  
            lblProfit.Text = (value * double.Parse(lblProfit.Text)).ToString();
        }

        private void setSellingPriceAndProfit()
        {
            lblSelling.Text = service.GetSellingPrice().ToString();
            lblProfit.Text = service.GetMarkupValue().ToString();
        }
    }

}
  