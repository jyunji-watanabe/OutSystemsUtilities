using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
public class ScreenShot
{
    public static string Path = "C:\\work\\ss";
    public static void TakeWholePageAsScreenShot(RemoteWebDriver driver)
    {
        // 仕様単純化のため、横スクロールは不要を前提とする
        var jsExecutor = driver as IJavaScriptExecutor;
        // JavaScriptを使って、スクロール回数の計算に使う値を取得
        var totalHeight = (long)jsExecutor.ExecuteScript("return document.body.scrollHeight;");
        var pageHeight = (long)jsExecutor.ExecuteScript("return window.innerHeight;");
        // スクロール制御用
        var scrolledHeight = (long)0;
        var currentImageCount = 1;  // ファイル名末尾に連番をつけるための変数。今何番目の画像かを示す
        var filePathPrefix = Path + "\\" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss_");

        // 1ページ分ずつスクロールしながら、スクリーンショットを撮っていく
        var iTakesScreenshot = (ITakesScreenshot)driver;
        while(scrolledHeight < totalHeight)
        {
            jsExecutor.ExecuteScript($"window.scrollTo(0, {scrolledHeight});");
            iTakesScreenshot.GetScreenshot()
                            .SaveAsFile(filePathPrefix + currentImageCount.ToString().PadLeft(5, '0') + ".png");

            // ループ制御
            currentImageCount++;
            scrolledHeight += pageHeight;
        }
    }
}