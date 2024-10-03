using FluentAssertions;
using Microsoft.Playwright;
using OpenCartAutomation.Models;
using OpenCartAutomation.Pages;

namespace OpenCartAutomation.Steps;

public class HomePageSteps(IPage page) : BaseSteps(page)
{
    private readonly HomePage _homePage = new(page);

    public LoginSteps SelectLoginOption()
    {
        _homePage.HeaderElement.SelectLoginUser().Wait();
        return new LoginSteps(page);
    }

    public SearchResultSteps SearchProduct(string productName)
    {
        _homePage.TypeSearchText(productName).Wait();
        _homePage.ClickSearchButton().Wait();
        return new SearchResultSteps(page);
    }

    public HomePageSteps AddProductToWishListUnauthorizedUser(string productName)
    {
        _homePage.AddProductToWishList(productName).Wait();
        return this;
    }

    public CategorySteps SelectCategory(string category, string subCategory)
    {
        _homePage.NavBar.SelectCategory(category, subCategory).Wait();
        return new CategorySteps(page);
    }

    public HomePageSteps VerifyAlertMessageIsCorrect(string expectedMessage)
    {
        var actualMessage = _homePage.GetAlertMessage().Result;
        actualMessage.Should().Contain(expectedMessage);
        return this;
    }

    public HomePageSteps VerifyFeaturedProducts(IList<ProductModel> expectedProducts)
    {
        var featuredElements = _homePage.GetFeaturedProducts().Result;
        VerifyProductsAreEqual(featuredElements, expectedProducts);
        return this;
    }
}