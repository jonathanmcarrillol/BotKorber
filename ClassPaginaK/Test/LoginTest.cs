using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;

namespace ClassPaginaK.Test
{
    [TestFixture]
    public class LoginTest
    {
        [Test]
        public void successLogin()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddExcludedArgument("enable-automation");


            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://emc3plprodweb.koerbercloud.com/core/Default.html");
            Thread.Sleep(3000);

            //IReadOnlyCollection<IWebElement> Select = driver.FindElements(By.TagName("select"));
            //List<IWebElement> listaSelect = new List<IWebElement>(Select);


            //WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //IWebElement elemento2 = wait2.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-hj-test-id='username']")));




            IReadOnlyCollection<IWebElement> inputs = driver.FindElements(By.TagName("input"));
            List<IWebElement> listaInput = new List<IWebElement>(inputs);





            if (listaInput.Count >= 2)
            {
                //IWebElement PrimerInput = listaInput[0];
                //PrimerInput.SendKeys("SUP15");
                //IWebElement SegundoInput = listaInput[1];
                //SegundoInput.SendKeys("EMERGENT001");

                IWebElement PrimerInput = listaInput[0];
                PrimerInput.SendKeys("SUP14");
                Console.WriteLine("ingreso usuario");
                Thread.Sleep(3000);
                IWebElement SegundoInput = listaInput[1];
                SegundoInput.SendKeys("Emergent2024*");
                Console.WriteLine("ingreso password");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("No se encontraron suficientes elementos input en la página.");
            }


            //if (Select.Count >= 1)
            //{
            //    Thread.Sleep(1000);
            //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //    IWebElement dropdown = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("span.k-dropdown-wrap.k-state-default")));
            //    dropdown.Click();
            //    IWebElement option = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div li[data-offset-index='3']")));
            //    option.Click();

            //}
           
            IReadOnlyCollection<IWebElement> Buttons = driver.FindElements(By.TagName("button"));
            List<IWebElement> listaButton = new List<IWebElement>(Buttons);

            if (listaButton.Count >= 1)
            {
                IWebElement ButtonLogin = listaButton[0];
                Console.WriteLine("Click login");
                ButtonLogin.Click();
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("No se encontraron suficientes elementos button en la página.");
            }
            Console.WriteLine("Inicio 20 sg");
            Thread.Sleep(20000);
            Console.WriteLine("fin 20 sg");

            // Esperar a que el documento esté completamente cargado
            WebDriverWait waitmenu = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            waitmenu.Until(ExpectedConditions.ElementIsVisible(By.Id("menuButtonToggle")));
            // Ahora puedes seguir interactuando con otros elementos
            IWebElement elemento = driver.FindElement(By.Id("menuButtonToggle"));
            elemento.Click();
     //WebDriverWait waitmenu = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //IWebElement optionmenu = waitmenu.Until(ExpectedConditions.ElementIsVisible(By.Id("menuButtonToggle")));
            //optionmenu.Click();
            Console.WriteLine("Click button menu");

            Thread.Sleep(3000);


            WebDriverWait waitseleccion4 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement cuartoLi = waitseleccion4.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("nav#menu ul li:nth-of-type(5)")));


            cuartoLi.Click();

            Thread.Sleep(3000);

            WebDriverWait waitseleccion2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement SegundoLi = waitseleccion4.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("ul li:nth-of-type(2)")));
            SegundoLi.Click();

            Thread.Sleep(3000);

        }

    }
}
