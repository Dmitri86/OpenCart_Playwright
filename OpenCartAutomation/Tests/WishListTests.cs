using Allure.NUnit;
using OpenCartAutomation.Steps;

namespace OpenCartAutomation.Tests;

[TestFixture]
[AllureNUnit]
public class WishListTests : BaseTest
{
    [Test]
    public void VerifyOnlyAuthorizedUserCanAddProductToWishList()
    {
        const string product = "iPhone";
        const string expectedMessage = $" You must login or create an account to save {product} to your wish list!";

        new HomePageSteps(Page)
            .LaunchOpenCart()
            .AddProductToWishListUnauthorizedUser(product)
            .VerifyAlertMessageIsCorrect(expectedMessage);
    }
}