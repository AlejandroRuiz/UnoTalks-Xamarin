using System;
using MvvmHelpers;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinForms3.View;

namespace XamarinForms3.ViewModel
{
    public class XamarinForms3ViewModel : BaseViewModel
    {
        public const string FlexLayoutCommand = "FlexLayoutCommand";

        public const string RightToLeftCommand = "RightToLeftCommand";

        public const string StyleSheetsCommand = "StyleSheetsCommand";

        public const string VisualStateManagerCommand = "VisualStateManagerCommand";

        public XamarinForms3ViewModel()
        {
            Title = "Xamarin.Forms 3";
            ActionCommand = new Command<string>(InvokeActionCommand);
        }

        public ICommand ActionCommand { get; }

        async void InvokeActionCommand(string command)
        {
            await Application.Current.MainPage.Navigation.PushAsync(GetPage(command));
        }

        Page GetPage(string command)
        {
            switch(command)
            {
                case FlexLayoutCommand:
                    return new FlexLayoutPage();
                case RightToLeftCommand:
                    return new RightToLeftPage();
                case StyleSheetsCommand:
                    return new StyleSheetsPage();
                case VisualStateManagerCommand:
                    return new VisualStateManagerPage();
                default:
                    return null;
            }
        }
    }
}
