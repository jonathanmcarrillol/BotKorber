using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace BotKorber
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassPaginaK.Test.LoginTest Test = new ClassPaginaK.Test.LoginTest();
            Test.successLogin();
        }
    }
}
