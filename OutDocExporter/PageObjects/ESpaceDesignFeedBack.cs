using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

public class ESpaceDesignFeedBack
{
    private const string PageTitle = "OutDoc - eSpace ";    // 例：「OutDoc - eSpace HousesoftSampleBPT」
    private RemoteWebDriver driver;
    private string eSpaceName;
    public ESpaceDesignFeedBack(RemoteWebDriver driver, string eSpaceName)
    {
        this.driver = driver;
        this.eSpaceName = eSpaceName;
        var expectedTitle = ESpaceDesignFeedBack.PageTitle + this.eSpaceName;
        // トップメニューのアクティブなタブ内テキスト
        if (driver.Title != expectedTitle)
        {
            throw new IllegalPageStateException(
                "選択されているタブが想定と異なります（想定：" + expectedTitle + "、実際：" + this.driver.Title + "）");
        }
    }

    /// <summary>
    /// Open Documentationボタンが表示されるまで待ち、クリックする
    /// </summary>
    public void WaitForButtonAndClick()
    {
        // 最長2分間待つタイマー
        var waitForOpenDocumentButton = new WebDriverWait(this.driver, new System.TimeSpan(0, 2, 0));
        // 「Open Documentation」というvalueを持つボタンが表示されるのを待ち、表示されたらクリック
        waitForOpenDocumentButton.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".Button[value^=Open]")))
                                 .Click();
    }
}