using Microsoft.Playwright;
using OpenCartAutomation.Pages.CommonElements;

namespace OpenCartAutomation.Pages;

public class CategoryPage : WebPage
{
    private  ILocator CategoryName => Page.Locator("#content h2");
    private  ILocator FoundProducts => Page.Locator(".product-layout");

    public async Task<string> GetCategoryName()
    {
        return await CategoryName.InnerTextAsync();
    }

    public async Task<List<ProductElement>> GetFoundProducts()
    {
        var productsLocator = await FoundProducts.AllAsync();
        var productList = new List<ProductElement>();
        foreach (var locator in productsLocator)
        {
            productList.Add(new ProductElement(locator));
        }

        return productList;
    }
}