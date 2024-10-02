using OpenCartAutomation.Models;
using OpenCartAutomation.Steps;

namespace OpenCartAutomation.Tests;

[TestFixture]
public class NavigationBarTests : PageTest
{
    [TestCaseSource(nameof(NavigationMenuTestData))]
    public void VerifyNavigationMenu(KeyValuePair<(string, string), List<ProductModel>> testData)
    {
        var ((category, subCategory), expectedProducts) = testData;
        new HomePageSteps(Page)
            .LaunchOpenCart()
            .SelectCategory(category, subCategory)
            .VerifyCategoryIsCorrect(category, subCategory)
            .VerifyFoundProducts(expectedProducts);
    }


    private static IEnumerable<KeyValuePair<(string, string), List<ProductModel>>> NavigationMenuTestData()
    {
        yield return new KeyValuePair<(string, string), List<ProductModel>>(("Tablets", string.Empty), [
            new ProductModel
            {
                Title = "Samsung Galaxy Tab 10.1",
                Description =
                    "Samsung Galaxy Tab 10.1, is the world’s thinnest tablet, measuring 8.6 mm thickness, running w..",
                CurrentPrice = "$241.99",
                OldPrice = string.Empty,
                ExcludeTaxPrice = "$199.99"
            }
        ]);
        
        yield return new KeyValuePair<(string, string), List<ProductModel>>(("Desktops", "Mac"), [
            new ProductModel
            {
                Title = "iMac",
                Description = "Just when you thought iMac had everything, now there\u00b4s even more. More powerful Intel Core 2 Duo pro..",
                CurrentPrice = "$122.00",
                OldPrice = string.Empty,
                ExcludeTaxPrice = "$100.00"
            }
        ]);
    }
}