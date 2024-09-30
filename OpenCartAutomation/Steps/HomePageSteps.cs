using Microsoft.Playwright;
using OpenCartAutomation.Pages;

namespace OpenCartAutomation.Steps;

public class HomePageSteps(IPage page) : BaseSteps(page)
{
    private readonly HomePage _homePage = new (page);

    public SearchResultSteps SearchProduct(string productName)
    {
        _homePage.TypeSearchText(productName);
        _homePage.ClickSearchButton();
        return new SearchResultSteps(page);
    }
}