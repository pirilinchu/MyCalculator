using MyCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyCalculator
{
    class MainPageViewModel
    {
        public MyModel Model { get; set; }
        
        public ICommand NumberCommand { get; set; }
        public ICommand OperatorCommand { get; set; }
        public ICommand EqualCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SingleDeleteCommand { get; set; }
        public ICommand CommaCommand { get; set; }


        public MainPageViewModel()
        {
            Model = new MyModel();
            NumberCommand = new Command<string>(numberSelected);
            OperatorCommand = new Command<string>(operatorSelected);
            EqualCommand = new Command(equalSelected);
            DeleteCommand = new Command(deleteSelected);
            SingleDeleteCommand = new Command(singleDeleteSelected);
            CommaCommand = new Command(commaSelected);
        }

        private void numberSelected(string number)
        {
            //var parsedNumber = int.TryParse(number, out var intNumber);
            if (!Model.OperationComming)
            {
                if (Model.Display == "0" || Model.Display == "Error") Model.Display = "";
                string newNumber = Model.Display + number;
                Model.Display = newNumber;
            }
            else
            {
                Model.OperationComming = false;
                Model.PlusColor = Color.FromHex("#F09329");
                Model.MultiplyColor = Color.FromHex("#F09329");
                Model.MinusColor = Color.FromHex("#F09329");
                Model.DivideColor = Color.FromHex("#F09329");
                var parsedNumber = double.TryParse(Model.Display, out var intNumber);
                if (parsedNumber)
                {
                    Model.LastInput = intNumber;
                    Model.Display = number;
                }
            }
        }

        private void operatorSelected(string operation)
        {
            Model.CurrentOperation = operation;
            Model.OperationComming = true;
            if (operation == "+")
            {
                Model.PlusColor = Color.FromHex("#D9544F");
                Model.MultiplyColor = Color.FromHex("#F09329");
                Model.MinusColor = Color.FromHex("#F09329");
                Model.DivideColor = Color.FromHex("#F09329");
            }
            else if (operation == "-")
            {
                Model.MinusColor = Color.FromHex("#D9544F");
                Model.PlusColor = Color.FromHex("#F09329");
                Model.MultiplyColor = Color.FromHex("#F09329");
                Model.DivideColor = Color.FromHex("#F09329");
            }
            else if (operation == "x")
            {
                Model.MultiplyColor = Color.FromHex("#D9544F");
                Model.PlusColor = Color.FromHex("#F09329");
                Model.MinusColor = Color.FromHex("#F09329");
                Model.DivideColor = Color.FromHex("#F09329");
            }
            else
            {
                Model.DivideColor = Color.FromHex("#D9544F");
                Model.PlusColor = Color.FromHex("#F09329");
                Model.MultiplyColor = Color.FromHex("#F09329");
                Model.MinusColor = Color.FromHex("#F09329");
            }

        }

        private void equalSelected()
        {
            var parsedNumber = double.TryParse(Model.Display, out var intCurrent);
            if (parsedNumber)
            {
                double result = 0;
                string currentOperator = Model.CurrentOperation;
                if (currentOperator == "+")
                {
                    result = Model.LastInput + intCurrent;
                }
                else if (currentOperator == "-")
                {
                    result = Model.LastInput - intCurrent;
                }
                else if (currentOperator == "÷")
                {
                    if (intCurrent == 0)
                    {
                        Model.Display = "Error";
                        Model.LastInput = 0;
                        Model.OperationComming = false;
                        return;
                    }
                    result = Model.LastInput / intCurrent;
                }
                else if (currentOperator == "x")
                {
                    result = Model.LastInput * intCurrent;
                }
                Model.LastInput = Math.Round(result, 2);
                Model.Display = Model.LastInput.ToString();
            }
        }

        private void deleteSelected()
        {
            Model.LastInput = 0;
            Model.OperationComming = false;
            Model.Display = "0";
            Model.CurrentOperation = "-1";
            Model.PlusColor = Color.FromHex("#F09329");
            Model.MultiplyColor = Color.FromHex("#F09329");
            Model.MinusColor = Color.FromHex("#F09329");
            Model.DivideColor = Color.FromHex("#F09329");
        }

        private void singleDeleteSelected()
        {
            if (Model.Display != "0" || Model.Display != "Error")
            {
                Model.Display = Model.Display.Remove(Model.Display.Length - 1);
            }
        }

        private void commaSelected()
        {
            if(!Model.Display.Contains("."))
            {
                Model.Display = Model.Display + ".";
            }
        }

    }
}
