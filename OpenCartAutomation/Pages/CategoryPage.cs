using Microsoft.Playwright;

namespace OpenCartAutomation.Pages;

public class CategoryPage(IPage page)
{
    private readonly ILocator categoryName = page.Locator("#content h2");
    private readonly ILocator _foundProducts = page.Locator(".product-layout");

    public async Task<string> GetCategoryName()
    {
        return await categoryName.InnerTextAsync();
    }

    public async Task<List<ProductElement>> GetFoundProducts()
    {
        var productsLocator = await _foundProducts.AllAsync();
        var productList = new List<ProductElement>();
        foreach (var locator in productsLocator)
        {
            productList.Add(new ProductElement(locator));
        }

        return productList;
    }
}