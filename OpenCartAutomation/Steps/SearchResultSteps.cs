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
        var actualProductsElements = _searchResultPage.GetFoundProducts().Result;
        VerifyProductsAreEqual(actualProductsElements, expectedProducts);
        return this;
    }
}