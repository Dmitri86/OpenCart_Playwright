using FluentAssertions;
using Microsoft.Playwright;
using OpenCartAutomation.Pages;

namespace OpenCartAutomation.Steps;

public class AccountPageSteps(IPage page) : BaseSteps(page)
{
    private readonly AccountPage _accountPage = new (page);

    public AccountPageSteps VerifyAccountPageIsOpen()
    {
        _accountPage.EditYourAccountInformationIsVisible().Result.Should().BeTrue();
        return this;
    }
}