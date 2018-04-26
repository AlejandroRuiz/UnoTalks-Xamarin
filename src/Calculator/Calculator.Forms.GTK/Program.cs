using System;
using Xamarin.Forms.Platform.GTK;

namespace Calculator.Forms.GTK
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Gtk.Application.Init();
            Xamarin.Forms.Forms.Init();
            var app = new App();
            var window = new FormsWindow();
            window.LoadApplication(app);
            window.SetApplicationTitle("Calculator App");
            window.Show();
            Gtk.Application.Run();
        }
    }
}
