using OpenCartAutomation.Models;
using OpenCartAutomation.Steps;

namespace OpenCartAutomation.Tests;

public class SearchTests : PageTest
{
    [TestCaseSource(nameof(SearchElements))]
    public void VerifyProductCanBeFound(KeyValuePair<string, List<ProductModel>> testData)
    {
        var (productName, expectedProductList) = testData;
        new HomePageSteps(Page)
            .LaunchOpenCart()
            .SearchProduct(productName)
            .VerifySearchTitleIsCorrect($"Search - {productName}")
            .VerifyFoundProducts(expectedProductList);
    }

    private static IEnumerable<KeyValuePair<string, List<ProductModel>>> SearchElements()
    {
        yield return new KeyValuePair<string, List<ProductModel>>("iphone", [
            new()
            {
                Title = "iPhone",
                Description =
                    "iPhone is a revolutionary new mobile phone that allows you to make a call by simply tapping a name o..",
                CurrentPrice = "$123.20"
            }
        ]);

        yield return new KeyValuePair<string, List<ProductModel>>("macbook", [
            new()
            {
                Title = "MacBook",
                Description =
                    "Intel Core 2 Duo processor Powered by an Intel Core 2 Duo processor at speeds up to 2.16GHz, the..",
                CurrentPrice = "$602.00"
            },

            new()
            {
                Title = "MacBook Air",
                Description =
                    "MacBook Air is ultrathin, ultraportable, and ultra unlike anything else. But you don’t lose in..",
                CurrentPrice = "$1,202.00"
            },

            new()
            {
                Title = "MacBook Pro",
                Description =
                    "Latest Intel mobile architecture Powered by the most advanced mobile processors from Intel, ..",
                CurrentPrice = "$2,000.00"
            }
        ]);

    }
}