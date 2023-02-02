using TaxCalculatorAPI.Services;

namespace TestAPI
{
    public class PurchaseTests
    {
        IPurchaseService purchaseService;

        [SetUp]
        public void Setup()
        {
            purchaseService = new PurchaseService();
        }

        [Test]
        public void TestNetAmount()
        {
            var purchase = purchaseService.CalculateByNetAmount(100, 20);
            Assert.IsNotNull(purchase);
            Assert.Multiple(() =>
            {
                Assert.That(purchase.Amount.Net, Is.EqualTo(100));
                Assert.That(purchase.Amount.Gross, Is.EqualTo(120));
                Assert.That(purchase.Amount.VAT, Is.EqualTo(20));
                Assert.That(purchase.Amount.VATRate, Is.EqualTo(20));
            });

            var zeroNetPurchase = purchaseService.CalculateByNetAmount(0, 20);
            Assert.Multiple(() =>
            {
                Assert.That(zeroNetPurchase.Amount.Net, Is.EqualTo(0));
                Assert.That(zeroNetPurchase.Amount.Gross, Is.EqualTo(0));
                Assert.That(zeroNetPurchase.Amount.VAT, Is.EqualTo(0));
            });
        }

        [Test]
        public void TestVatAmount()
        {
            var purchase = purchaseService.CalculateByVatAmount(20, 20);
            Assert.IsNotNull(purchase);
            Assert.Multiple(() =>
            {
                Assert.That(purchase.Amount.Net, Is.EqualTo(100));
                Assert.That(purchase.Amount.Gross, Is.EqualTo(120));
                Assert.That(purchase.Amount.VAT, Is.EqualTo(20));
                Assert.That(purchase.Amount.VATRate, Is.EqualTo(20));
            });

            var zeroVatPurchase = purchaseService.CalculateByVatAmount(0, 20);
            Assert.Multiple(() =>
            {
                Assert.That(zeroVatPurchase.Amount.Net, Is.EqualTo(0));
                Assert.That(zeroVatPurchase.Amount.Gross, Is.EqualTo(0));
                Assert.That(zeroVatPurchase.Amount.VAT, Is.EqualTo(0));
            });
        }

        [Test]
        public void TestGrossAmount()
        {
            var purchase = purchaseService.CalculateByGrossAmount(120, 20);
            Assert.IsNotNull(purchase);
            Assert.Multiple(() =>
            {
                Assert.That(purchase.Amount.Net, Is.EqualTo(100));
                Assert.That(purchase.Amount.Gross, Is.EqualTo(120));
                Assert.That(purchase.Amount.VAT, Is.EqualTo(20));
                Assert.That(purchase.Amount.VATRate, Is.EqualTo(20));
            });

            var zeroGrossPurchase = purchaseService.CalculateByGrossAmount(0, 20);
            Assert.Multiple(() =>
            {
                Assert.That(zeroGrossPurchase.Amount.Net, Is.EqualTo(0));
                Assert.That(zeroGrossPurchase.Amount.Gross, Is.EqualTo(0));
                Assert.That(zeroGrossPurchase.Amount.VAT, Is.EqualTo(0));
            });
        }

        [Test]
        public void TestAmountVatRate()
        {
            var purchase = purchaseService.CalculateAmountVatRate(100, 120, 20);
            Assert.IsNotNull(purchase);
            Assert.Multiple(() =>
            {
                Assert.That(purchase.Amount.Net, Is.EqualTo(100));
                Assert.That(purchase.Amount.Gross, Is.EqualTo(120));
                Assert.That(purchase.Amount.VAT, Is.EqualTo(20));
                Assert.That(purchase.Amount.VATRate, Is.EqualTo(20));
            });
        }
    }
}