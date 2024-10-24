using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace BotKorber
{
    class Program
    {
        static void Main(string[] args)
        {
            string rutaCarpeta = "C:\\BotKorber";
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }
            ClassPaginaK.Test.LoginTest Test = new ClassPaginaK.Test.LoginTest();
            Test.FuncionPrincipal();
        }
    }
}
