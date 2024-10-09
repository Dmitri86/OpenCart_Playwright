using Microsoft.Playwright;
using OpenCartAutomation.Pages.CommonElements;

namespace OpenCartAutomation.Pages;

public class HomePage : WebPage
{
    private  ILocator SearchField => Page.Locator("#search input");
    private  ILocator SearchButton => Page.Locator("#search button");
    private  ILocator CartStatus => Page.Locator("#cart-total");
    private  ILocator FeaturedProducts => Page.Locator(".product-layout");
    private  ILocator AlertMessage => Page.Locator(".alert-success");

    public  HeaderElement HeaderElement => new (Page.Locator("#top"));
    public NavigationBarElement NavBar => new(Page.Locator("#menu"));

    public async Task TypeSearchText(string searchText)
    {
        await SearchField.FillAsync(searchText);
    }

    public async Task ClickSearchButton()
    {
        await SearchButton.ClickAsync();
    }

    public async Task<string> GetCartStatus()
    {
        return await CartStatus.InnerTextAsync();
    }

    public async Task<string> GetAlertMessage()
    {
        return await AlertMessage.InnerTextAsync();
    }

    public async Task<List<ProductElement>> GetFeaturedProducts()
    {
        var productsLocator = await FeaturedProducts.AllAsync();
        var productList = new List<ProductElement>();
        foreach (var locator in productsLocator)
        {
            productList.Add(new ProductElement(locator));
        }

        return productList;
    }

    public async Task AddProductToWishList(string productName)
    {
        var productsLocator = await FeaturedProducts.AllAsync();
        foreach (var locator in productsLocator)
        {
            var product = new ProductElement(locator);
            if (product.GetTitle().Result != productName)
            {
                continue;
            }
            product.ClickToWishList().Wait();
            return;
        }

        throw new ArgumentOutOfRangeException($"Product with title [{productName}] was not found");
    }

    public async Task AddProductToCart(string productName)
    {
        var productsLocator = await FeaturedProducts.AllAsync();
        foreach (var locator in productsLocator)
        {
            var product = new ProductElement(locator);
            if (product.GetTitle().Result != productName)
            {
                continue;
            }
            product.ClickAddToCart().Wait();
            return;
        }

        throw new ArgumentOutOfRangeException($"Product with title [{productName}] was not found");
    }
}