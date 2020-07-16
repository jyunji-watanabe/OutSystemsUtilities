using System;
using OpenQA.Selenium.Chrome;

namespace OutSystemsUtilities
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://jyunjiwatanabe1.outsystemscloud.com/OutDoc/eSpace_List.aspx");
                

            }
        }
    }
}
