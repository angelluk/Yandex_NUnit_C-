using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;


public class YandexTest
{
     
    static void Main(string[] args)
    {
        // Data for testing

        String userLogin = "aleksei.lukjanenko";
        String userPassword = "angelluk";

        // luanch Firefox
        IWebDriver driver = new FirefoxDriver();
        
        // set implicit wait
        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

        // open main page     
        driver.Navigate().GoToUrl("http://www.yandex.ru/");

        // input login
        driver.FindElement(By.CssSelector(".auth__username .input__box .input__control")).Click();
        driver.FindElement(By.CssSelector(".auth__username .input__box .input__control")).Clear();
        driver.FindElement(By.CssSelector(".auth__username .input__box .input__control")).SendKeys(userLogin);
        
        // input password
        driver.FindElement(By.CssSelector(".auth__password .input__box .input__control")).Click();
        driver.FindElement(By.CssSelector(".auth__password .input__box .input__control")).Clear();
        driver.FindElement(By.CssSelector(".auth__password .input__box .input__control")).SendKeys(userPassword);

        // login action
        driver.FindElement(By.CssSelector(".button.auth__login-button")).Click();


        // Should see email account 
        System.Console.WriteLine("Page title is: " + driver.Title);
        NUnit.Core.NUnitFramework.Assert.AreEqual(driver.Title,"Яндекс.Пошта");

        //Close the browser
        driver.Quit();
    }
}