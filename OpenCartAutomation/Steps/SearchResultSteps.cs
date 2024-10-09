using FluentAssertions;
using Microsoft.Playwright;
using OpenCartAutomation.Models;
using OpenCartAutomation.Pages;

namespace OpenCartAutomation.Steps;

public class SearchResultSteps(IPage page) : BaseSteps(page)
{
    private SearchResultPage SearchResultPage => On<SearchResultPage>();

    public SearchResultSteps VerifySearchTitleIsCorrect(string expectedTitle)
    {
        var actualTitle = SearchResultPage.GetSearchTitle().Result;
        actualTitle.Should().Be(expectedTitle);
        return this;
    }

    public SearchResultSteps VerifyFoundProducts(IList<ProductModel> expectedProducts)
    {
        var actualProductsElements = SearchResultPage.GetFoundProducts().Result;
        VerifyProductsAreEqual(actualProductsElements, expectedProducts);
        return this;
    }
}