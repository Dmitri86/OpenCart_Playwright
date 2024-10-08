using Allure.NUnit;
using Allure.NUnit.Attributes;
using OpenCartAutomation.Models;
using OpenCartAutomation.Steps;

namespace OpenCartAutomation.Tests;

[TestFixture]
[AllureNUnit]
public class FeaturedProductsTests : BaseTest
{
    [Test]
    [AllureDescription("Featured Products")]
    public void VerifyFeaturedProductsAreCorrect()
    {
        var expectedProducts = new List<ProductModel>
        {
            new()
            {
                Title = "MacBook",
                Description =
                    "Intel Core 2 Duo processor Powered by an Intel Core 2 Duo processor at speeds up to 2.16GHz..",
                CurrentPrice = "$602.00",
                OldPrice = string.Empty,
                ExcludeTaxPrice = "$500.00"
            },
            new()
            {
                Title = "iPhone",
                Description = "iPhone is a revolutionary new mobile phone that allows you to make a call by simply tapping a nam..",
                CurrentPrice = "$123.20",
                OldPrice = string.Empty,
                ExcludeTaxPrice = "$101.00"
            },
            new()
            {
                Title = "Apple Cinema 30\"",
                Description = "The 30-inch Apple Cinema HD Display delivers an amazing 2560 x 1600 pixel resolution. Designed sp..",
                CurrentPrice = "$110.00",
                OldPrice = "$122.00",
                ExcludeTaxPrice = "$90.00"
            },
            new()
            {
                Title = "Canon EOS 5D",
                Description = "Canon's press material for the EOS 5D states that it 'defines (a) new D-SLR category', while we'r..",
                CurrentPrice = "$98.00",
                OldPrice = "$122.00",
                ExcludeTaxPrice = "$80.00"
            }
        };

        new HomePageSteps(Page)
            .LaunchOpenCart()
            .VerifyFeaturedProducts(expectedProducts);
    }
}