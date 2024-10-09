using Microsoft.Playwright;

namespace OpenCartAutomation.Pages;

public class WebPage
{
    protected IPage Page { get; private set; }

    public void Init(IPage page) => this.Page = page;

    public async Task GoToAsync(string url)
    {
        await Page.GotoAsync(url);
    }
}