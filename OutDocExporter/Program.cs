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
            var url = configuration.GetSection("HostAddress").Value + "OutDoc/eSpace_List.aspx";
            var userName = configuration.GetSection("UserName").Value;
            var password = configuration.GetSection("Password").Value;
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(url);
                // UserNameとPasswordを入力
                var table = driver.FindElement(By.CssSelector(".MainContent table table"));
                var userInput = table.FindElement(By.CssSelector("tr:nth-of-type(3) input"));
                userInput.Clear();
                userInput.SendKeys(userName);
                var passwordInput = table.FindElement(By.CssSelector("tr:nth-of-type(5) input"));
                passwordInput.Clear();
                passwordInput.SendKeys(password);
                // ログインボタンをクリック
                driver.FindElement(By.CssSelector("input[type=submit]")).Click();

                var debugdummy = "dummy";
            }
        }
    }
}
