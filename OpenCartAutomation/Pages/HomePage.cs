using Microsoft.Playwright;
using OpenCartAutomation.Pages.CommonElements;

namespace OpenCartAutomation.Pages;

public class HomePage(IPage page)
{
    private readonly ILocator _searchField = page.Locator("#search input");
    private readonly ILocator _searchButton = page.Locator("#search button");
    private readonly ILocator _cartStatus = page.Locator("#cart-total");
    private readonly ILocator _featuredProducts = page.Locator(".product-layout");
    private readonly ILocator _alertMessage = page.Locator(".alert-success");

    public  HeaderElement HeaderElement => new (page.Locator("#top"));
    public NavigationBarElement NavBar => new(page.Locator("#menu"));

    public async Task TypeSearchText(string searchText)
    {
        await _searchField.FillAsync(searchText);
    }

    public async Task ClickSearchButton()
    {
        await _searchButton.ClickAsync();
    }

    public async Task<string> GetCartStatus()
    {
        return await _cartStatus.InnerTextAsync();
    }

    public async Task<string> GetAlertMessage()
    {
        return await _alertMessage.InnerTextAsync();
    }

    public async Task<List<ProductElement>> GetFeaturedProducts()
    {
        var productsLocator = await _featuredProducts.AllAsync();
        var productList = new List<ProductElement>();
        foreach (var locator in productsLocator)
        {
            productList.Add(new ProductElement(locator));
        }

        return productList;
    }

    public async Task AddProductToWishList(string productName)
    {
        var productsLocator = await _featuredProducts.AllAsync();
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
        var productsLocator = await _featuredProducts.AllAsync();
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