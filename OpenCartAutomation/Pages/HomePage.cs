﻿using Microsoft.Playwright;

namespace OpenCartAutomation.Pages;

public class HomePage(IPage page)
{
    private readonly ILocator _searchField = page.Locator("#search input");
    private readonly ILocator _searchButton = page.Locator("#search button");
    private readonly ILocator _featuredProducts = page.Locator(".product-layout");
    private readonly ILocator _navigateBar = page.Locator("#menu");
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
}