using Microsoft.Playwright;

namespace OpenCartAutomation.Steps;

public abstract class BaseSteps(IPage page)
{
    protected IPage Page = page;
    public HomePageSteps LaunchOpenCart()
    {
        Page.SetViewportSizeAsync(1920, 1080);
        Page.GotoAsync("https://naveenautomationlabs.com/opencart").Wait();
        return new HomePageSteps(Page);
    }
}