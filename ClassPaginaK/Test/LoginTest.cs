using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using System.Xml;
using System.IO;

namespace ClassPaginaK.Test
{
    [TestFixture]
    public class LoginTest
    {
        string rutaArchivo = "C:\\BotKorber\\DatosDinamicos.xml";
        string User="";
                    string Password="";
                    string Tiempologeando="";
                    string Tiempoentreclick="";
                    string PrimerSelect="";
                    string SegundoSelect="";
                    string TextoModal="";
                    string TiempoScroll = "";

        public void FuncionPrincipal()
        {
            if (File.Exists(rutaArchivo))
            {
                LeerDatos();
                successLogin(User, Password, Tiempologeando, Tiempoentreclick, PrimerSelect, SegundoSelect, TextoModal, TiempoScroll);
            }
            else
            {
                if(CrearArchivo()){
                LeerDatos();
                successLogin(User,Password,Tiempologeando,Tiempoentreclick,PrimerSelect,SegundoSelect,TextoModal, TiempoScroll);
                }
            }
        }



        [Test]
        public void successLogin(string User, string Password,string Tiempologeando, string Tiempoentreclick,string PrimerSelect, string SegundoSelect, string TextoModal, string TiempoScroll)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddExcludedArgument("enable-automation");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            //options.AddArgument("--incognito");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://emc3plprodweb.koerbercloud.com/core/Default.html");
            driver.Manage().Cookies.DeleteAllCookies();
            Thread.Sleep(Convert.ToInt32(Tiempoentreclick) * 1000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("document.body.style.zoom='80%'");
            Thread.Sleep(Convert.ToInt32(Tiempoentreclick)  * 1000);


            IReadOnlyCollection<IWebElement> inputs = driver.FindElements(By.TagName("input"));
            List<IWebElement> listaInput = new List<IWebElement>(inputs);
            
            if (listaInput.Count >= 2)
            {
                IWebElement PrimerInput = listaInput[0];
                //PrimerInput.SendKeys("SUP14");
                PrimerInput.SendKeys(User);
                Console.WriteLine("ingreso usuario");
                Thread.Sleep(Convert.ToInt32(Tiempoentreclick)  * 1000);
                IWebElement SegundoInput = listaInput[1];
                //SegundoInput.SendKeys("Emergent2024*");
                SegundoInput.SendKeys(Password);
                Console.WriteLine("ingreso password");
                Thread.Sleep(Convert.ToInt32(Tiempoentreclick)  * 1000);
            }
            else
            {
                Console.WriteLine("No se encontraron suficientes elementos input en la página.");
            }

            IReadOnlyCollection<IWebElement> Buttons = driver.FindElements(By.TagName("button"));
            List<IWebElement> listaButton = new List<IWebElement>(Buttons);

            if (listaButton.Count >= 1)
            {
                IWebElement ButtonLogin = listaButton[0];
                Console.WriteLine("Click login");
                ButtonLogin.Click();
                Thread.Sleep(Convert.ToInt32(Tiempoentreclick)  * 1000);
            }
            else
            {
                Console.WriteLine("No se encontraron suficientes elementos button en la página.");
            }
            Console.WriteLine("Inicio " + Tiempologeando  + " sg");
            Thread.Sleep(Convert.ToInt32(Tiempologeando)  * 1000);
            Console.WriteLine("fin " + Tiempologeando + " sg");

            WebDriverWait waitmenu = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            waitmenu.Until(ExpectedConditions.ElementIsVisible(By.Id("menuButtonToggle")));
            IWebElement elemento = driver.FindElement(By.Id("menuButtonToggle"));
            elemento.Click();
            Console.WriteLine("Click button menu");
            Thread.Sleep(Convert.ToInt32(Tiempoentreclick)  * 1000);
            WebDriverWait waitseleccion4 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement cuartoLi = waitseleccion4.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("nav#menu ul li:nth-of-type(5)")));
            cuartoLi.Click();
            Console.WriteLine("Click korber one report");
            Thread.Sleep(Convert.ToInt32(Tiempoentreclick)  * 1000);
            WebDriverWait waitseleccion2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement SegundoLi = waitseleccion4.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("nav#menu ul li ul li:nth-of-type(2)")));
            SegundoLi.Click();
            Console.WriteLine("Click Crear informe");
            Thread.Sleep(Convert.ToInt32(Tiempoentreclick)  * 1000);
            IReadOnlyCollection<IWebElement> Select = driver.FindElements(By.TagName("select"));
            List<IWebElement> listaSelect = new List<IWebElement>(Select);

            if (Select.Count >= 1)
            {
                Thread.Sleep(Convert.ToInt32(Tiempoentreclick)  * 1000);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                IWebElement dropdown = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("span.k-dropdown-wrap.k-state-default:nth-of-type(1)")));
                dropdown.Click();
                Console.WriteLine("Click primer select");
                Thread.Sleep(Convert.ToInt32(Tiempoentreclick)  * 1000);
                //IWebElement option = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[contains(text(),'09 Colombia')]")));
                IWebElement option = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[contains(text(),'"+PrimerSelect+"')]")));
                option.Click();
                Console.WriteLine("Click seleccionar contenido select 1");
                Thread.Sleep(Convert.ToInt32(Tiempoentreclick)  * 1000);
                WebDriverWait waitSelect2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement dropdownSelect2 = waitSelect2.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//span[contains(@class, 'k-dropdown-wrap')])[2]")));
                SelectElement select = new SelectElement(listaSelect[1]);
                dropdownSelect2.Click();
                Console.WriteLine("Click Segundo select");
                Thread.Sleep(Convert.ToInt32(Tiempoentreclick)  * 1000);
                //IWebElement fifthOption = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[contains(text(),'OP_Yard')]")));
                IWebElement fifthOption = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[contains(text(),'"+SegundoSelect+"')]")));
                fifthOption.Click();
                Console.WriteLine("Click seleccionar contenido select 1");
                Thread.Sleep(Convert.ToInt32(Tiempoentreclick)  * 1000);

            }

            WebDriverWait waitEjecutar = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement ejecutar = waitEjecutar.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-hj-test-id='page-actions'] ul li:nth-of-type(2)")));
            ejecutar.Click();
            Console.WriteLine("Click en Ejecutar");
            Thread.Sleep(Convert.ToInt32(Tiempoentreclick)  * 1000);

            IReadOnlyCollection<IWebElement> inputsmodal = driver.FindElements(By.TagName("input"));
            List<IWebElement> listaInputmodal = new List<IWebElement>(inputsmodal);

            if (listaInputmodal.Count >= 2)
            {
                IWebElement PrimerInputModal = listaInputmodal[3];
                PrimerInputModal.SendKeys(TextoModal);
                Console.WriteLine("ingreso de texto en modal");
                Thread.Sleep(Convert.ToInt32(Tiempoentreclick)  * 1000);
            }
            else
            {
                Console.WriteLine("No se encontraron suficientes elementos input en la página.");
            }



            IReadOnlyCollection<IWebElement> ButtonModal = driver.FindElements(By.TagName("Button"));
            List<IWebElement> listaButtonModal = new List<IWebElement>(ButtonModal);

            if (listaButtonModal.Count >= 2)
            {
                IWebElement ButtonModalEjecutar = listaButtonModal[3];
                ButtonModalEjecutar.Click();
                Console.WriteLine("Click boton ejecutar");
                Thread.Sleep(Convert.ToInt32(Tiempoentreclick)  * 1000);
            }
            else
            {
                Console.WriteLine("No se encontraron suficientes elementos input en la página.");
            }


            WebDriverWait waitrefresh = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement iframeElement = waitrefresh.Until(ExpectedConditions.ElementIsVisible(By.XPath("//iframe[contains(@data-bind, \"attr: {'id': _divId2 }\")]")));
            Thread.Sleep(Convert.ToInt32(Tiempoentreclick)  * 1000);
            driver.SwitchTo().Frame(iframeElement);
            IWebElement selectElement = waitrefresh.Until(ExpectedConditions.ElementIsVisible(By.Id("ReportViewerControl_ctl05_ctl02_ctl00")));
            SelectElement select2 = new SelectElement(selectElement);
            Thread.Sleep(Convert.ToInt32(Tiempoentreclick)  * 1000);
            select2.SelectByIndex(0);


            IWebElement buttonElement = waitrefresh.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.ToolbarRefresh.WidgetSet")));
            buttonElement.Click();
            Thread.Sleep(Convert.ToInt32(Tiempoentreclick)  * 1000);

            while (true)
            {

                IWebElement divElement = waitrefresh.Until(ExpectedConditions.ElementIsVisible(By.Id("ReportViewerControl_ctl09")));
                js.ExecuteScript("arguments[0].scrollTop = arguments[0].scrollHeight;", divElement);


                for (int i = 0; i <= Convert.ToInt32(TiempoScroll); i++)
                {
                    Thread.Sleep(2000);
                    js.ExecuteScript("arguments[0].scrollTop = arguments[0].scrollHeight / "+Convert.ToInt32(TiempoScroll)+" * " + i + ";", divElement);
                    Thread.Sleep(500);
                }

                buttonElement.Click();
                Console.WriteLine("Click realizado en actualizar: " + DateTime.Now);


            }

        }


        public bool CrearArchivo()
        {
            bool rta = false;

            bool Arch = File.Exists(rutaArchivo);
            if (Arch)
            {
                Console.WriteLine("El archivo existe.");
                rta = true;
            }
            else
            {
                using (XmlWriter writer = XmlWriter.Create(rutaArchivo))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("RootDatos");

                    // Añadir un elemento.
                    writer.WriteStartElement("Usuario");
                    writer.WriteElementString("User", "SUP14");
                    writer.WriteElementString("Password", "Emergent2024*");
                    writer.WriteElementString("Tiempologeando", "20");
                    writer.WriteElementString("Tiempoentreclick", "3");
                    writer.WriteElementString("PrimerSelect", "09 Colombia");
                    writer.WriteElementString("SegundoSelect", "OP_Yard");
                    writer.WriteElementString("TextoModal", "H1");
                    writer.WriteElementString("TiempoScroll", "40"); 
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            return rta;
        }


        public void LeerDatos()
        {
            bool Arch = File.Exists(rutaArchivo);
            XmlDocument doc = new XmlDocument();
            XmlNodeList Usuarios = doc.GetElementsByTagName("Usuario");
            if (Arch)
            {
                doc.Load(rutaArchivo);
                foreach (XmlNode usuario in Usuarios)
                {
                     User = usuario["User"].InnerText.ToString();
                     Password = usuario["Password"].InnerText.ToString();
                     Tiempologeando = usuario["Tiempologeando"].InnerText.ToString();
                     Tiempoentreclick = usuario["Tiempoentreclick"].InnerText.ToString();
                     PrimerSelect = usuario["PrimerSelect"].InnerText.ToString();
                     SegundoSelect = usuario["SegundoSelect"].InnerText.ToString();
                     TextoModal = usuario["TextoModal"].InnerText.ToString();
                     TiempoScroll = usuario["TiempoScroll"].InnerText.ToString();
                }
               
            }
            else
            {
                CrearArchivo();
               
            }

        }
    }
}
