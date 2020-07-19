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
                                                .AddJsonFile("appsettings.json", true,true)
                                                .Build();
            var url = configuration.GetSection("HostAddress").Value + "OutDoc";
            var userName = configuration.GetSection("UserName").Value;
            var password = configuration.GetSection("Password").Value;
            using (var driver = new ChromeDriver())
            {
                // ログインページヘ遷移し、ログインを実行する
                driver.Navigate().GoToUrl(url);
                var loginPage = new LoginPage(driver);
                loginPage.SetCredential(userName, password);
                var WelcomePage = loginPage.LoginAndGoToWelcomePage();
                
                var debugdummy = "dummy";
            }
        }
    }
}
