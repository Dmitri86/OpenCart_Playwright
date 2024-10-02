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

    public CategorySteps SelectCategory(string category, string subCategory)
    {
        _homePage.SelectCategory(category, subCategory);
        return new CategorySteps(page);
    }

    public HomePageSteps VerifyFeaturedProducts(IList<ProductModel> expectedProducts)
    {
        var featuredElements = _homePage.GetFeaturedProducts().Result;
        featuredElements.Count.Should().Be(expectedProducts.Count);
        var actualProducts = new List<ProductModel>();
        foreach (var element in featuredElements)
        {
            actualProducts.Add(new ProductModel
            {
                Title = element.GetTitle().Result,
                Description = element.GetDescription().Result,
                CurrentPrice = element.GetCurrentPrice().Result,
                OldPrice = element.GetOldPrice().Result,
                ExcludeTaxPrice = element.GetExcludeTaxPrice().Result
            });
        }

        actualProducts.Should().BeEquivalentTo(expectedProducts);

        return this;
    }
}