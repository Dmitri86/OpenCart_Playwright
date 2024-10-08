using Allure.NUnit;
using OpenCartAutomation.Steps;

namespace OpenCartAutomation.Tests;

[TestFixture]
[AllureNUnit]
public class ProductCartTests : BaseTest
{
    [TestCaseSource(nameof(TestData))]
    public void VerifyUserCanAddFeaturedProductToCart(KeyValuePair<string, string> testData)
    {
        var (productName, filledCart) = testData;
        const string emptyCart = "0 item(s) - $0.00";
        var expectedAlertMessage = $"Success: You have added {productName} to your shopping cart!";

        new HomePageSteps(Page)
            .LaunchOpenCart()
            .VerifyCartStatusIsCorrect(emptyCart)
            .AddProductToCart(productName)
            .VerifyAlertMessageIsCorrect(expectedAlertMessage)
            .VerifyCartStatusIsCorrect(filledCart);
    }

    private static IEnumerable<KeyValuePair<string, string>> TestData()
    {
        yield return new KeyValuePair<string, string>("MacBook", "1 item(s) - $602.00");
        yield return new KeyValuePair<string, string>("Canon EOS 5D", "1 item(s) - $98.00");
    }
}