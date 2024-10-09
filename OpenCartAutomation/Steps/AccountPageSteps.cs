using FluentAssertions;
using Microsoft.Playwright;
using OpenCartAutomation.Pages;

namespace OpenCartAutomation.Steps;

public class AccountPageSteps(IPage page) : BaseSteps(page)
{
    private AccountPage AccountPage => On<AccountPage>();

    public AccountPageSteps VerifyAccountPageIsOpen()
    {
        AccountPage.EditYourAccountInformationIsVisible().Result.Should().BeTrue();
        return this;
    }
}