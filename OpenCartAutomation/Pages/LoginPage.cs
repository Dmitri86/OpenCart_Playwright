using Microsoft.Playwright;

namespace OpenCartAutomation.Pages;

public class LoginPage : WebPage
{
    private  ILocator EmailField => Page.Locator("#input-email");
    private  ILocator PasswordField => Page.Locator("#input-password");
    private  ILocator LoginButton => Page.Locator("input[type='submit']");


    public async Task SetEmail(string email)
    {
        await EmailField.FillAsync(email);
    }

    public async Task SetPassword(string password)
    {
        await PasswordField.FillAsync(password);
    }

    public async Task ClickLogin()
    {
        await LoginButton.ClickAsync();
    }
}