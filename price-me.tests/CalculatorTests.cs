using NuGet.Frameworks;

namespace price_me.tests
{
    [TestClass]
    public class CalculatorTests
    {
        double costPrice, sellingPrice, profit, markupValue, TaxValue;
        int markUp = 0, quantity = 0;
        bool incVat = false;

        [TestMethod]
        public void CostPrice_Less_Tax_Equals_Expected()
        {
            // arrange
            double costPrice, sellingPrice, profit, markupValue, TaxValue;
            int markUp = 0, quantity = 0;
            bool incVat = false;

            // act
            costPrice = 500.00;
            var costPriceLessTax = removeTaxFromCostPrice(costPrice);

            // asset
            Assert.AreEqual(425,costPriceLessTax);

        }

        [TestMethod]
        public void CalculateSellingPrice_WithTaxOnCostPrice()
        {
            // arrange
            costPrice = 500;
            markUp = 50;
            incVat = true;
            var expected = 733.12d;

            // act
            sellingPrice = GetSellingPrice();

            // Assert
            Assert.AreEqual(expected, sellingPrice);

        }

        [TestMethod]
        public void GetMarkupValue_Test()
        {
            //arrange
            markUp = 50;
            costPrice = 500;
            int expected = 250;
            //act
            var markupValue = GetMarkupValue();
            //asset
            Assert.AreEqual(expected, markupValue);
        }

        [TestMethod]
        public void CalculateSellingPrice_WITHOUT_TAX()
        {
            // arrange
            costPrice = 500;
            markUp = 50;
            incVat = false;
            var expected = 750d;

            // Act
            sellingPrice = GetSellingPrice();

            // Assert
            Assert.AreEqual(expected, sellingPrice);

        }


        private double GetMarkupValue()
        {
            return (costPrice * (markUp / 100d));
        }
        private double removeTaxFromCostPrice(double price)
        {
            return price - (price * (15d / 100d));
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

            return Double.Round(sellingPrice,2,MidpointRounding.ToEven);
        }
    }
}