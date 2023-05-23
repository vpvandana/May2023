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
        Thread.Sleep(1000);

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
        Thread.Sleep(2000);

        //To delete a row in the table

       /* //Go to First page

        IWebElement firstpagebtn = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[1]/span"));
        firstpagebtn.Click(); */

        //click on delete button

        IWebElement deletebtn = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
        deletebtn.Click();

        //click on OK button in the popup menu

        Thread.Sleep(3000);
        IAlert alert = driver.SwitchTo().Alert();

        // String alertMessage = driver.SwitchTo().Alert().getText();
        Thread.Sleep(2000);
        alert.Accept();
     // Console.WriteLine("First record deleted !");
        Thread.Sleep(2000);

        //check if record is deleted from table
        IWebElement lastrowrecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
         

         if (lastrowrecord.Text != "May 2023")
         {
             Console.WriteLine("Last record deleted !");

         }
         else

         {
             Console.WriteLine(" Last record not deleted!");
         }

        //To edit a row in the table

        //Click on edit button
        IWebElement Editbtn = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
        Thread.Sleep(2000);
        Editbtn.Click();
        Thread.Sleep(3000);

        //Edit Code
        IWebElement codetxtboxedit = driver.FindElement(By.XPath("//*[@id=\"Code\"]"));
        codetxtboxedit.Clear();
        Thread.Sleep(1000);
        codetxtboxedit.SendKeys("June2023");
        Thread.Sleep(3000);

        //Edit Description
        IWebElement descriptiontxtboxedit = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
        descriptiontxtboxedit.Clear();  
        descriptiontxtboxedit.SendKeys("June2023");
        Thread.Sleep(3000);

        //Edit Price
        IWebElement pricetxtboxedit = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
      //pricetxtboxedit.Clear();
        pricetxtboxedit.SendKeys("30");
        Thread.Sleep(2000);

        //Click on Save button
        IWebElement Savebtn = driver.FindElement(By.Id("SaveButton"));
        Savebtn.Click();
        Thread.Sleep(1000);
        //Console.WriteLine("Record edited successfully");

        //Check if last row edited

        //Navigate to last page button
        IWebElement lastpgbtn = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]"));
        lastpgbtn.Click();  
        Thread.Sleep(2000); 

        // Check if last code not the same
        IWebElement lastrowrecord1 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        
        if (lastrowrecord1.Text == "June2023")
        {
            Console.WriteLine("Code edited successfully");
        }
        else
        {
            Console.WriteLine("Code not edited !");
        }
    }

    }