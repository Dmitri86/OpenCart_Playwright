using Microsoft.Playwright;

namespace OpenCartAutomation.Pages;

public class NavigationBarElement(ILocator locator)
{
    private ILocator _category(string categoryName) => locator.Locator($"//ul//a[text()='{categoryName}']");

    private ILocator _subCategory(string subCategoryName) =>
        locator.Locator($"//li[@class='dropdown open']//a[contains(text(), '{subCategoryName}')]");


    public async Task SelectElement(string category, string subCategory)
    {
        await _category(category).ClickAsync();
        if (!string.IsNullOrEmpty(subCategory))
        {
            await _subCategory(subCategory).ClickAsync();
        }
    }
}