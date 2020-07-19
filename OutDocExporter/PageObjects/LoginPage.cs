using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

public class LoginPage 
{
    private const string PageTitle = "Login";
    private RemoteWebDriver driver;
    public LoginPage(RemoteWebDriver driver)
    {
        this.driver = driver;
        if (this.driver.Title != LoginPage.PageTitle)
        {
            throw new IllegalPageStateException(
                "ページタイトルが想定と異なります（想定：" + LoginPage.PageTitle + "、実際：" + this.driver.Title + "）");
        }
    }

    public void SetCredential(string userName, string password)
    {
        // UserNameとPasswordを入力
        var table = driver.FindElement(By.CssSelector(".MainContent table table"));
        var userInput = table.FindElement(By.CssSelector("tr:nth-of-type(3) input"));
        userInput.Clear();
        userInput.SendKeys(userName);
        var passwordInput = table.FindElement(By.CssSelector("tr:nth-of-type(5) input"));
        passwordInput.Clear();
        passwordInput.SendKeys(password);
    }

    public WelcomePage LoginAndGoToWelcomePage()
    {
        driver.FindElement(By.CssSelector("input[type=submit]")).Click();
        return new WelcomePage(this.driver);
    }
}