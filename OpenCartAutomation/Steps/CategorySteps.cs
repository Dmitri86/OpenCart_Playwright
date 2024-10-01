using FluentAssertions;
using Microsoft.Playwright;
using OpenCartAutomation.Models;
using OpenCartAutomation.Pages;

namespace OpenCartAutomation.Steps;

public class CategorySteps(IPage page) : BaseSteps(page)
{
    private readonly CategoryPage _categoryPage = new(page);

    public CategorySteps VerifyCategoryIsCorrect(string expectedCategory, string expectedSubcategory)
    {
        var expectedText = string.IsNullOrEmpty(expectedSubcategory) ? expectedCategory : expectedSubcategory;
        var actualTitle = _categoryPage.GetCategoryName().Result;
        actualTitle.Should().Be(expectedText);
        return this;
    }

    public CategorySteps VerifyFoundProducts(IList<ProductModel> expectedProducts)
    {
        var actualProductLocators = _categoryPage.GetFoundProducts().Result;
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