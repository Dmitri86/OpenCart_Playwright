using Microsoft.Playwright;
using OpenCartAutomation.Pages.CommonElements;

namespace OpenCartAutomation.Pages;

public class SearchResultPage(IPage page)
{
    private readonly ILocator _searchTitle = page.Locator("#content h1");
    private readonly ILocator _foundProducts = page.Locator(".product-layout");

    public async Task<string> GetSearchTitle()
    {
        return await _searchTitle.InnerTextAsync();
    }

    public async Task<List<ProductElement>> GetFoundProducts()
    {
        var productsLocator =  await _foundProducts.AllAsync();
        var productList = new List<ProductElement>();
        foreach (var locator in productsLocator)
        {
            productList.Add(new ProductElement(locator));
        }

        return productList;
    }
}