using Microsoft.Playwright;

namespace OpenCartAutomation.Pages;

public class AccountPage : WebPage
{
    private ILocator EditYourAccountInformation => Page.GetByText("Edit your account information");

    public async Task<bool> EditYourAccountInformationIsVisible()
    {
        return await EditYourAccountInformation.IsVisibleAsync();
    }
}