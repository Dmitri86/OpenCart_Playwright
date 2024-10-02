using Microsoft.Playwright;

namespace OpenCartAutomation.Pages;

public class LoginPage(IPage page)
{
    private readonly ILocator _emailField = page.Locator("#input-email");
    private readonly ILocator _passwordField = page.Locator("#input-password");
    private readonly ILocator _loginButton = page.Locator("input[type='submit']");


    public async Task SetEmail(string email)
    {
        await _emailField.FillAsync(email);
    }

    public async Task SetPassword(string password)
    {
        await _passwordField.FillAsync(password);
    }

    public async Task ClickLogin()
    {
        await _loginButton.ClickAsync();
    }
}