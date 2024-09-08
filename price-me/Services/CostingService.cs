using price_me.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace price_me.Services
{
    public class CostingService
    {
        double costPrice, sellingPrice, profit, markupValue, TaxValue;
        int markUp = 0, quantity = 0;
        bool incVat = false;

        public CostingService()
        {
                
        }

        public void SetupCostingRequest(CalculateRequest request) 
        { 
            costPrice = request.CostPrice;
            markUp = request.Markup;
            incVat = request.IncVat;
        }

        public double GetSellingPrice()
        {
            if (incVat) 
            { 
                // remove tax to calculate 
                costPrice = removeTaxFromCostPrice(costPrice);
                markupValue = GetMarkupValue();
                sellingPrice = costPrice + markupValue;
                // new tax value
                TaxValue = (sellingPrice * (15d / 100d));
                // new selling price with tax
                sellingPrice += TaxValue;
            }
            else
            {
                markupValue = GetMarkupValue();
                sellingPrice = costPrice + markupValue;
            }

            return Double.Round(sellingPrice, 2, MidpointRounding.ToEven);
        }

        private double removeTaxFromCostPrice(double price)
        {
            return price - (price * (15d / 100d));
        }

        public double GetMarkupValue()
        {
            return (costPrice * (markUp/100));
        }
    }
}
