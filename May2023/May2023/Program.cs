using OpenQA.Selenium;
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
        IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
        passwordTextbox.SendKeys("123123");

        //Click on Login ButtonUserName
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.Click();

        // Check if user logged in successfully
        IWebElement hellohari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
        if (hellohari.Text == "Hello hari!")
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
        Thread.Sleep(3000);

        //Click on create new btton
        IWebElement Createnewbtn = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        Createnewbtn.Click();

        //Click Time from Typecode dropdown list
        IWebElement TypeCodedrpdwn = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
        TypeCodedrpdwn.Click();

        //input code
        IWebElement inputTxtbox = driver.FindElement(By.XPath("//*[@id=\"Code\"]"));
        inputTxtbox.SendKeys("May 2023");

        //input description
        IWebElement descptiontxtbox = driver.FindElement(By.Id("Description"));
        descptiontxtbox.SendKeys("May 2023");
        Thread.Sleep(3000);

        //input price
        IWebElement pricetxtbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        pricetxtbox.SendKeys("13");
        Thread.Sleep(2000);

        //click on save button
        IWebElement savebtn = driver.FindElement(By.Id("SaveButton"));
        savebtn.Click();
        Thread.Sleep(3000);

        //check if new record has been created in the table
        //Navigate to last page

        IWebElement lastpagebtn = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        lastpagebtn.Click();
        Thread.Sleep(2000);
        //Check if record present
        IWebElement lastrowrec = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if (lastrowrec.Text == "May 2023")
        {
            Console.WriteLine("New record created");
        }
        else
        {
            Console.WriteLine("Unable to create new record");


        }
    }


    }