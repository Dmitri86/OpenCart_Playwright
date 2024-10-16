using FluentAssertions;
using Microsoft.Playwright;
using OpenCartAutomation.Models;
using OpenCartAutomation.Pages;

namespace OpenCartAutomation.Steps;

public class HomePageSteps(IPage page) : BaseSteps(page)
{
    private HomePage HomePage => On<HomePage>();

    public LoginSteps SelectLoginOption()
    {
        HomePage.HeaderElement.SelectLoginUser().Wait();
        return new LoginSteps(page);
    }

    public SearchResultSteps SearchProduct(string productName)
    {
        HomePage.TypeSearchText(productName).Wait();
        HomePage.ClickSearchButton().Wait();
        return new SearchResultSteps(page);
    }

    public HomePageSteps AddProductToWishListUnauthorizedUser(string productName)
    {
        HomePage.AddProductToWishList(productName).Wait();
        return this;
    }

    public HomePageSteps AddProductToCart(string productName)
    {
        HomePage.AddProductToCart(productName).Wait();
        return this;
    }

    public CategorySteps SelectCategory(string category, string subCategory)
    {
        HomePage.NavBar.SelectCategory(category, subCategory).Wait();
        return new CategorySteps(page);
    }

    public HomePageSteps WaitCartIsNotEmpty()
    {
        HomePage.WaitForCartIsNotEmpty().Wait();
        return this;
    }

    public HomePageSteps VerifyCartStatusIsCorrect(string expectedStatus)
    {
        var actualStatus = HomePage.GetCartStatus().Result.Trim();
        actualStatus.Should().Be(expectedStatus);
        return this;
    }

    public HomePageSteps VerifyAlertMessageIsCorrect(string expectedMessage)
    {
        var actualMessage = HomePage.GetAlertMessage().Result;
        actualMessage.Should().Contain(expectedMessage);
        return this;
    }

    public HomePageSteps VerifyFeaturedProducts(IList<ProductModel> expectedProducts)
    {
        var featuredElements = HomePage.GetFeaturedProducts().Result;
        VerifyProductsAreEqual(featuredElements, expectedProducts);
        return this;
    }
}