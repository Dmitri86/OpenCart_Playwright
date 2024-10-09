using Microsoft.Playwright;
using OpenCartAutomation.Pages.CommonElements;

namespace OpenCartAutomation.Pages;

public class SearchResultPage : WebPage
{
    private  ILocator SearchTitle => Page.Locator("#content h1");
    private  ILocator FoundProducts => Page.Locator(".product-layout");

    public async Task<string> GetSearchTitle()
    {
        return await SearchTitle.InnerTextAsync();
    }

    public async Task<List<ProductElement>> GetFoundProducts()
    {
        var productsLocator =  await FoundProducts.AllAsync();
        var productList = new List<ProductElement>();
        foreach (var locator in productsLocator)
        {
            productList.Add(new ProductElement(locator));
        }

        return productList;
    }
}