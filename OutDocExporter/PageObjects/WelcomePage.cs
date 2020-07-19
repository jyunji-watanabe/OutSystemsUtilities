using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

public class WelcomePage
{
    private const string PageTitle = "OutDoc";
    private RemoteWebDriver driver;
    public WelcomePage(RemoteWebDriver driver)
    {
        this.driver = driver;
        if (this.driver.Title != WelcomePage.PageTitle)
        {
            throw new IllegalPageStateException(
                "ページタイトルが想定と異なります（想定：" + WelcomePage.PageTitle + "、実際：" + this.driver.Title + "）");
        }
    }
}