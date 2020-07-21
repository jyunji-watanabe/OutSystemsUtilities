using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

public class HomeScreen
{
    private const string PageTitle = "OutDoc";
    private RemoteWebDriver driver;
    public HomeScreen(RemoteWebDriver driver)
    {
        this.driver = driver;
        // TitleのOutDocは各ページ共通のようだが、このページには
        // 操作対象が他のページと共通のヘッダしかないのでTitle確認でOKとする
        if (this.driver.Title != HomeScreen.PageTitle)
        {
            throw new IllegalPageStateException(
                "ページタイトルが想定と異なります（想定：" + HomeScreen.PageTitle + "、実際：" + this.driver.Title + "）");
        }
    }

    public ESpaceList MoveToESpaceList()
    {
        this.driver.FindElementByCssSelector(".Menu_TopMenus>div:nth-of-type(2)>a").Click();
        return new ESpaceList(this.driver);
    }
}