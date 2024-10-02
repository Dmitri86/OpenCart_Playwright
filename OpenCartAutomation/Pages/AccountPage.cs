using Microsoft.Playwright;

namespace OpenCartAutomation.Pages;

public class AccountPage(IPage page)
{
    private readonly ILocator _editYourAccountInformation = page.GetByText("Edit your account information");

    public async Task<bool> EditYourAccountInformationIsVisible()
    {
        return await _editYourAccountInformation.IsVisibleAsync();
    }
}