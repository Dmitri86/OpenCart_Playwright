using Allure.Net.Commons;
using Microsoft.Playwright;
using NUnit.Framework.Interfaces;
using System.Reflection;

namespace OpenCartAutomation.Tests;

[Parallelizable(ParallelScope.Fixtures)]
public abstract class BaseTest : PageTest
{
    [SetUp]
    public void SetUp()
    {
        Page.SetViewportSizeAsync(1920, 1080);
        Page.SetDefaultTimeout(17000);
    }

    [TearDown]
    public async Task TearDown()
    {
        var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
        if (testStatus == TestStatus.Failed)
        {
            var path = GetPath();
            await Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = path,
                FullPage = true
            });
            AllureApi.AddAttachment(path, "img/png");
        }
    }

    private string GetPath()
    {
        var fileName = Guid.NewGuid() + ".png";
        var directory = Directory
            .CreateDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\screenshots")
            .FullName;
        var filePath = directory + fileName;
        return filePath;

    }
}