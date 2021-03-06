﻿using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            System.Console.WriteLine("ドキュメントを出力するモジュール名を指定してください。");
            return;
        }
        var eSpaceName = args[0];
        if (Directory.Exists(ScreenShot.Path) == false)
        {
            System.Console.WriteLine($"出力先フォルダ{ScreenShot.Path}を作成するか、出力先フォルダを変更してください");
            return;
        }
        IConfiguration configuration = new ConfigurationBuilder()
                                            .AddJsonFile("appsettings.json", true, true)
                                            .Build();
        var url = configuration.GetSection("HostAddress").Value + "OutDoc";
        var userName = configuration.GetSection("UserName").Value;
        var password = configuration.GetSection("Password").Value;
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
            // スクリーンショットを取得
            ScreenShot.TakeWholePageAsScreenShot(driver);

            var debugdummy = "dummy";   // デバッグ用（ブラウザ表示した状態でブレークするため）ダミー行
        }
    }
}
