using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;

namespace OutSystemsUtilities
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                                                .AddJsonFile("appsettings.json", true, true)
                                                .Build();
            var url = configuration.GetSection("HostAddress").Value + "OutDoc";
            var userName = configuration.GetSection("UserName").Value;
            var password = configuration.GetSection("Password").Value;
            var eSpaceName = "HousesoftSampleTraditional";
            try
            {            
                DownloadDocument(url, userName, password, eSpaceName);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private static void DownloadDocument(string url, string userName, string password, string eSpaceName)
        {
            using (var driver = new ChromeDriver())
            {
                // ログインページヘ遷移し、ログインを実行する
                driver.Navigate().GoToUrl(url);
                var loginPage = new Login(driver);
                loginPage.SetCredential(userName, password);
                var homeScreen = loginPage.LoginAndGoToHomeScreen();
                // eSpacesページへ遷移する
                var eSpacesList = homeScreen.MoveToESpaceList();
                // eSpace名で検索して対象モジュールのみ表示した上で、クリックして開く（ドキュメントページへ）
                var eSpaceDesingFeedBack = eSpacesList.OpenESpace(eSpaceName);
                // 生成されたドキュメントを開く
                eSpaceDesingFeedBack.WaitForButtonAndClick();

                var debugdummy = "dummy";   // デバッグ用（ブラウザ表示した状態でブレークするため）ダミー行
            }
        }
    }
}
