using OpenCartAutomation.Core.Autofac;
using OpenCartAutomation.Models;
using OpenCartAutomation.Steps;

namespace OpenCartAutomation.Tests;

[TestFixture]
public class LoginTests : PageTest
{
    [Test]
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