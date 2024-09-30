using FluentAssertions;
using Microsoft.Playwright;
using OpenCartAutomation.Models;
using OpenCartAutomation.Pages;

namespace OpenCartAutomation.Steps;

public class SearchResultSteps(IPage page) : BaseSteps(page)
{
    private readonly SearchResultPage _searchResultPage = new(page);

    public SearchResultSteps VerifySearchTitleIsCorrect(string expectedTitle)
    {
        var actualTitle = _searchResultPage.GetSearchTitle().Result;
        actualTitle.Should().Be(expectedTitle);
        return this;
    }

    public SearchResultSteps VerifyFoundProducts(IList<ProductModel> expectedProducts)
    {
        var actualProductLocators = _searchResultPage.GetFoundProducts().Result;
        actualProductLocators.Count.Should().Be(expectedProducts.Count);
        var actualProducts = new List<ProductModel>();
        foreach (var locator in actualProductLocators)
        {
            actualProducts.Add(new ProductModel
            {
                Title = locator.GetTitle().Result,
                Description = locator.GetDescription().Result,
                CurrentPrice = locator.GetCurrentPrice().Result
            });
        }

        actualProducts.Should().BeEquivalentTo(expectedProducts);
        return this;
    }
}