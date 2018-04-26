using System;
using Ooui;
using Xamarin.Forms;

namespace Calculator.Forms.Web
{
    class Program
    {
        static void Main(string[] args)
        {
            Xamarin.Forms.Forms.Init();

            var mainPage = new NavigationPage(new MainPage());
            Xamarin.Forms.Application.Current = new Application { MainPage = mainPage };
            UI.Publish("/", mainPage.GetOouiElement());

            // Don't exit the app until someone hits return
            Console.ReadLine();
        }
    }
}
