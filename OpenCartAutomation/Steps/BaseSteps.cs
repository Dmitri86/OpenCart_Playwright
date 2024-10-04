using FluentAssertions;
using Microsoft.Playwright;
using OpenCartAutomation.Core.Autofac;
using OpenCartAutomation.Models;
using OpenCartAutomation.Models.Configuration;
using OpenCartAutomation.Pages.CommonElements;

namespace OpenCartAutomation.Steps;

public abstract class BaseSteps(IPage page)
{
    protected IPage Page = page;

    public HomePageSteps LaunchOpenCart()
    {
        Page.SetViewportSizeAsync(1920, 1080);
        var url = DependencyResolver.Resolve<AppConfiguration>().OpenCartSetting.Url;
        Page.GotoAsync(url).Wait();
        return new HomePageSteps(Page);
    }

    protected void VerifyProductsAreEqual(IList<ProductElement> actualProductsElements, IList<ProductModel> expectedProducts)
    {
        actualProductsElements.Count.Should().Be(expectedProducts.Count);
        var actualProducts = new List<ProductModel>();
        foreach (var element in actualProductsElements)
        {
            actualProducts.Add(new ProductModel
            {
                Title = element.GetTitle().Result,
                Description = element.GetDescription().Result,
                CurrentPrice = element.GetCurrentPrice().Result,
                OldPrice = element.GetOldPrice().Result,
                ExcludeTaxPrice = element.GetExcludeTaxPrice().Result
            });
        }

        actualProducts.Should().BeEquivalentTo(expectedProducts);
    }
}