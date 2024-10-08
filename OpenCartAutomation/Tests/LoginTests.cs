using Allure.NUnit;
using Allure.NUnit.Attributes;
using OpenCartAutomation.Core.Autofac;
using OpenCartAutomation.Models;
using OpenCartAutomation.Steps;

namespace OpenCartAutomation.Tests;

[TestFixture]
[AllureNUnit]
public class LoginTests : BaseTest
{
    [Test]
    [AllureDescription("Verify User can Login")]
    public void VerifyUserCanLogin()
    {
        var testUser = DependencyResolver.Resolve<UserModel>();

        new HomePageSteps(Page)
            .LaunchOpenCart()
            .SelectLoginOption()
            .LoginUser(testUser)
            .VerifyAccountPageIsOpen();
    }
}