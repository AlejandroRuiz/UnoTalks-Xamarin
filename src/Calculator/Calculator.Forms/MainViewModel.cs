using System;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;
namespace Calculator.Forms
{
    public class MainViewModel : BaseViewModel
    {
        const string SUMCOMMAND = "+";
        const string SUBSTRACTCOMMAND = "-";
        const string DIVIDECOMMAND = "÷";
        const string MULTIPLYCOMMAND = "X";
        const string CLEARCOMMAND = "Clear";
        const string EQUALSCOMMAND = "=";

        string _displayText = "0";

        public MainViewModel()
        {
            ActionCommand = new Command<string>(InvokeActionCommand);
        }

        public ICommand ActionCommand { get; }

        public string DisplayText
        {
            get => _displayText;
            set => SetProperty(ref _displayText, value);
        }

        public double? FirstNumber { get; private set; }

        public string TargetCommand { get; private set; }

        async void InvokeActionCommand(string command)
        {
            if(int.TryParse(command, out var number))
            {
                if(_displayText == "0")
                {
                    DisplayText = command;
                }
                else
                {
                    DisplayText += command;
                }
            }
            else
            {
                if(command == EQUALSCOMMAND)
                {
                    if(FirstNumber == null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Select a Command First", "Ok");
                        return;
                    }
                    PerformAction(double.Parse(DisplayText));
                    DisplayText = FirstNumber.ToString();
                    FirstNumber = null;
                    TargetCommand = null;
                }
                else if(command == CLEARCOMMAND)
                {
                    FirstNumber = null;
                    DisplayText = "0";
                }
                else
                {
                    FirstNumber = double.Parse(DisplayText);
                    DisplayText = "0";
                    TargetCommand = command;
                }
            }
        }

        void PerformAction(double secondNumber)
        {
            if (TargetCommand == SUMCOMMAND)
            {
                FirstNumber += secondNumber;
            }
            else if (TargetCommand == SUBSTRACTCOMMAND)
            {
                FirstNumber -= secondNumber;
            }
            else if (TargetCommand == MULTIPLYCOMMAND)
            {
                FirstNumber = FirstNumber * secondNumber;
            }
            else if (TargetCommand == DIVIDECOMMAND)
            {
                FirstNumber = FirstNumber / secondNumber;
            }
        }
    }
}
