using Microsoft.Playwright;
using OpenCartAutomation.Models;
using OpenCartAutomation.Pages;

namespace OpenCartAutomation.Steps;

public class LoginSteps(IPage page) : BaseSteps(page)
{
    private LoginPage LoginPage => On<LoginPage>();

    public AccountPageSteps LoginUser(UserModel user)
    {
        LoginPage.SetEmail(user.Email).Wait();
        LoginPage.SetPassword(user.Password).Wait();
        LoginPage.ClickLogin().Wait();
        return new AccountPageSteps(page);
    }
}