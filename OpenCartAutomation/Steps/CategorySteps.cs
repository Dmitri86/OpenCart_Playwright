using FluentAssertions;
using Microsoft.Playwright;
using OpenCartAutomation.Models;
using OpenCartAutomation.Pages;

namespace OpenCartAutomation.Steps;

public class CategorySteps(IPage page) : BaseSteps(page)
{
    private CategoryPage CategoryPage => On<CategoryPage>();

    public CategorySteps VerifyCategoryIsCorrect(string expectedCategory, string expectedSubcategory)
    {
        var expectedText = string.IsNullOrEmpty(expectedSubcategory) ? expectedCategory : expectedSubcategory;
        var actualTitle = CategoryPage.GetCategoryName().Result;
        actualTitle.Should().Be(expectedText);
        return this;
    }

    public CategorySteps VerifyFoundProducts(IList<ProductModel> expectedProducts)
    {
        var actualProductsElements = CategoryPage.GetFoundProducts().Result;
        VerifyProductsAreEqual(actualProductsElements, expectedProducts);
        return this;
    }
}