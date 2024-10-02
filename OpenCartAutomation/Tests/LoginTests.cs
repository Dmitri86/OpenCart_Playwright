using OpenCartAutomation.Models;
using OpenCartAutomation.Steps;

namespace OpenCartAutomation.Tests;

[TestFixture]
public class LoginTests : PageTest
{
    [Test]
    public void VerifyUserCanLogin()
    {
        var testUser = new UserModel
        {
            Email = "atlasshragged777@gmail.com",
            Password = "1234566aZ"
        };

        new HomePageSteps(Page)
            .LaunchOpenCart()
            .SelectLoginOption()
            .LoginUser(testUser)
            .VerifyAccountPageIsOpen();
    }
}