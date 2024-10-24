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
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.body.style.zoom='80%'");

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

            WebDriverWait waitmenu = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            waitmenu.Until(ExpectedConditions.ElementIsVisible(By.Id("menuButtonToggle")));
            IWebElement elemento = driver.FindElement(By.Id("menuButtonToggle"));
            elemento.Click();
            Console.WriteLine("Click button menu");
            Thread.Sleep(3000);
            WebDriverWait waitseleccion4 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement cuartoLi = waitseleccion4.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("nav#menu ul li:nth-of-type(5)")));
            cuartoLi.Click();
            Console.WriteLine("Click korber one report");
            Thread.Sleep(3000);
            WebDriverWait waitseleccion2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement SegundoLi = waitseleccion4.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("nav#menu ul li ul li:nth-of-type(2)")));
            SegundoLi.Click();
            Console.WriteLine("Click Crear informe");
            Thread.Sleep(3000);
            IReadOnlyCollection<IWebElement> Select = driver.FindElements(By.TagName("select"));
            List<IWebElement> listaSelect = new List<IWebElement>(Select);

            if (Select.Count >= 1)
            {
                Thread.Sleep(3000);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                IWebElement dropdown = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("span.k-dropdown-wrap.k-state-default:nth-of-type(1)")));
                dropdown.Click();
                Console.WriteLine("Click primer select");
                Thread.Sleep(2000);
                IWebElement option = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div li[data-offset-index='13']")));
                option.Click();
                Console.WriteLine("Click seleccionar contenido select 1");
                Thread.Sleep(3000);
                WebDriverWait waitSelect2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement dropdownSelect2 = waitSelect2.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//span[contains(@class, 'k-dropdown-wrap')])[2]")));
                SelectElement select = new SelectElement(listaSelect[1]);
                dropdownSelect2.Click();                                                                                              
                Console.WriteLine("Click Segundo select");
                Thread.Sleep(2000);
                IWebElement fifthOption = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[contains(text(),'OP_Yard')]")));
                fifthOption.Click();
                Console.WriteLine("Click seleccionar contenido select 1");
                Thread.Sleep(3000);

            }

            WebDriverWait waitEjecutar = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement ejecutar = waitEjecutar.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-hj-test-id='page-actions'] ul li:nth-of-type(2)")));
            ejecutar.Click();
            Console.WriteLine("Click en Ejecutar");
            Thread.Sleep(2000);

            IReadOnlyCollection<IWebElement> inputsmodal = driver.FindElements(By.TagName("input"));
            List<IWebElement> listaInputmodal = new List<IWebElement>(inputsmodal);

            if (listaInputmodal.Count >= 2)
            {
                IWebElement PrimerInputModal = listaInputmodal[3];
                PrimerInputModal.SendKeys("H1");
                Console.WriteLine("ingreso de texto en modal");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("No se encontraron suficientes elementos input en la página.");
            }



            IReadOnlyCollection<IWebElement> ButtonModal = driver.FindElements(By.TagName("Button"));
            List<IWebElement> listaButtonModal = new List<IWebElement>(ButtonModal);

            if (listaButtonModal.Count >= 2)
            {
                IWebElement ButtonModalEjecutar= listaButtonModal[3];
                ButtonModalEjecutar.Click();
                Console.WriteLine("Click boton ejecutar");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("No se encontraron suficientes elementos input en la página.");
            }


            WebDriverWait waitrefresh = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement iframeElement = waitrefresh.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("iframe[id='_divId2']")));
            driver.SwitchTo().Frame(iframeElement);

            // Esperar a que el botón dentro del iframe esté presente
            IWebElement buttonElement = waitrefresh.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.ToolbarRefresh.WidgetSet")));

            // Hacer clic en el botón
            buttonElement.Click();



            IWebElement spanElement = waitrefresh.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.ToolbarRefresh.WidgetSet")));

            spanElement.Click();

            //IWebElement iconElement = waitrefresh.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("i.icon-without-text.fa.fa-fw.fa-refresh")));
            //iconElement.Click();
            while (true)
            {
                spanElement.Click();
                Console.WriteLine("Click realizado en actualizar: " + DateTime.Now);
                Thread.Sleep(10000);
            }

        }

    }
}
