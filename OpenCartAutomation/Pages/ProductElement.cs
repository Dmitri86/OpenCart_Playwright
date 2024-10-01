using Microsoft.Playwright;

namespace OpenCartAutomation.Pages;

public class ProductElement(ILocator locator)
{
    private readonly ILocator _image = locator.Locator("img");
    private readonly ILocator _title = locator.Locator(".caption a");
    private readonly ILocator _description = locator.Locator(".caption  p:first-of-type");
    private readonly ILocator _priceBlock = locator.Locator(".price");
    private readonly ILocator _addToCart = locator.Locator(".//button[normalize-space(.)='Add to Cart']");
    private readonly ILocator _addToWishList = locator.Locator(".//button[@data-original-title='Add to Wish List']");

    public async Task<string> GetTitle()
    {
        return await _title.InnerTextAsync();
    }

    public async Task<string> GetDescription()
    {
        return await _description.InnerTextAsync();
    }

    public Task<string> GetCurrentPrice()
    {
        return GetPrice(PriceType.Current);
    }

    public Task<string> GetOldPrice()
    {
        return GetPrice(PriceType.Old);
    }

    public Task<string> GetExcludeTaxPrice()
    {
        return GetPrice(PriceType.ExcludeTax);
    }

    public async void ClickAddToCart()
    {
        await _addToCart.ClickAsync();
    }

    public async void ClickToWishList()
    {
        await _addToWishList.ClickAsync();
    }

    private async Task<string> GetPrice(PriceType priceType)
    {
        var priceLine = await _priceBlock.InnerTextAsync();
        return priceType switch
        {
            PriceType.Current => new Regex(@"^[$]\d+.\d+.?\d+").Match(priceLine).Value,
            PriceType.Old => new Regex(@"\W([$]\d+[.]\d+)\W").Match(priceLine).Groups.Values.Last().Value,
            PriceType.ExcludeTax => new Regex(@"\W([$]\d+.\d+)$").Match(priceLine).Groups.Values.Last().Value,
            _ => throw new NotImplementedException($"Price type [{priceType}] is not implemented")
        };
    }

    private enum PriceType
    {
        Current,
        Old,
        ExcludeTax
    }
}