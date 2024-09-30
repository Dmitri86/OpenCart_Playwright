using Microsoft.Playwright;

namespace OpenCartAutomation.Pages;

public class HomePage(IPage page)
{
    private readonly ILocator _searchField = page.Locator("#search input");
    private readonly ILocator _searchButton = page.Locator("#search button");
    //private readonly string topProductsList = ".product-layout";

    public async void TypeSearchText(string searchText)
    {
        await _searchField.FillAsync(searchText);
    }

    public async void ClickSearchButton()
    {
        await _searchButton.ClickAsync();
    }
}