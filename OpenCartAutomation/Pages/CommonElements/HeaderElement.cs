using Microsoft.Playwright;

namespace OpenCartAutomation.Pages.CommonElements;

public class HeaderElement(ILocator locator)
{
    private readonly ILocator _myAccount = locator.Locator("a[title='My Account']");

    private ILocator DropdownElement(string element) =>
        locator.Locator($"//li[@class='dropdown open']//li[./a[text()='{element}']]");

    public async Task SelectLoginUser()
    {
        await _myAccount.ClickAsync();
        await DropdownElement("Login").ClickAsync();
    }
}