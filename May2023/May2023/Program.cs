﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    private static void Main(string[] args)
    {
        //Launch Browser
        IWebDriver driver = new ChromeDriver();


        //Launch The application Turn up Portal
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
        driver.Manage().Window.Maximize();

        
        //Enter the valid username
        IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
        usernameTextbox.SendKeys("hari"); 
        
        //Enter the valid password
        IWebElement passwordTextbox =  driver.FindElement(By.Id("Password"));
        passwordTextbox.SendKeys("123123");

        //Click on Login ButtonUserName
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.Click();

        // Check if user logged in successfully
        IWebElement hellohari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
        if(hellohari.Text == "Hello hari!")
        {
            Console.WriteLine("User Logged in successfully");
        }
        else
        {
            Console.WriteLine("User not Logged in!");
        }
        // Navigate to Administration
        IWebElement Administrationtab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        Administrationtab.Click();

        //Click on Time and Materials module
        IWebElement Tandmbtn = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul[1]/li[5]/ul/li[3]/a"));
        Tandmbtn.Click();

        //Click on create new btton
        IWebElement Createnewbtn = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        Createnewbtn.Click();   

        //Click Time from Typecode dropdown list

        //input code

        //input description

        //input price

        //check if new record has been created in the table



    }
}