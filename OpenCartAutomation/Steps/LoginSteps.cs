using Microsoft.Playwright;
using OpenCartAutomation.Models;
using OpenCartAutomation.Pages;

namespace OpenCartAutomation.Steps;

public class LoginSteps(IPage page) : BaseSteps(page)
{
    private readonly LoginPage _loginPage = new (page);

    public AccountPageSteps LoginUser(UserModel user)
    {
        _loginPage.SetEmail(user.Email).Wait();
        _loginPage.SetPassword(user.Password).Wait();
        _loginPage.ClickLogin().Wait();
        return new AccountPageSteps(page);
    }
}