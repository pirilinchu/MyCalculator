using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace MyCalculator.Models
{
    public class MyModel : INotifyPropertyChanged
    {
        private string display = "0";
        private double lastInput = 0;
        private string currentOperation = "-1";
        private bool operationComming = false;
        private Color baseColor = Color.FromHex("#F09329");

        public string Display
        {
            get => display;
            set
            {
                display = value;
                OnPropertyChanged(nameof(Display));
            }
        }
        public string CurrentOperation
        {
            get => currentOperation;
            set
            {
                currentOperation = value;
                OnPropertyChanged(nameof(CurrentOperation));
            }
        }
        public double LastInput
        {
            get => lastInput;
            set
            {
                lastInput = value;
                OnPropertyChanged(nameof(LastInput));
            }
        }
        public bool OperationComming
        {
            get => operationComming;
            set
            {
                operationComming = value;
                OnPropertyChanged(nameof(OperationComming));
            }
        }
        public Color PlusColor
        {
            get => baseColor;
            set
            {
                baseColor = value;
                OnPropertyChanged(nameof(PlusColor));
            }
        }
        public Color MinusColor
        {
            get => baseColor;
            set
            {
                baseColor = value;
                OnPropertyChanged(nameof(MinusColor));
            }
        }
        public Color DivideColor
        {
            get => baseColor;
            set
            {
                baseColor = value;
                OnPropertyChanged(nameof(DivideColor));
            }
        }
        public Color MultiplyColor
        {
            get => baseColor;
            set
            {
                baseColor = value;
                OnPropertyChanged(nameof(MultiplyColor));
            }
        }

        public void NumberSelected(string number)
        {
            //var parsedNumber = int.TryParse(number, out var intNumber);
            if (!OperationComming)
            {
                if (Display == "0" || Display == "Error") Display = "";
                string newNumber = Display + number;
                Display = newNumber;
            }
            else
            {
                OperationComming = false;
                PlusColor = Color.FromHex("#F09329");
                MultiplyColor = Color.FromHex("#F09329");
                MinusColor = Color.FromHex("#F09329");
                DivideColor = Color.FromHex("#F09329");
                var parsedNumber = double.TryParse(Display, out var intNumber);
                if (parsedNumber)
                {
                    LastInput = intNumber;
                    Display = number;
                }
            }
        }

        public void OperatorSelected(string operation)
        {
            CurrentOperation = operation;
            OperationComming = true;
            if (operation == "+")
            {
                PlusColor = Color.FromHex("#D9544F");
                MultiplyColor = Color.FromHex("#F09329");
                MinusColor = Color.FromHex("#F09329");
                DivideColor = Color.FromHex("#F09329");
            }
            else if (operation == "-")
            {
                MinusColor = Color.FromHex("#D9544F");
                PlusColor = Color.FromHex("#F09329");
                MultiplyColor = Color.FromHex("#F09329");
                DivideColor = Color.FromHex("#F09329");
            }
            else if (operation == "x")
            {
                MultiplyColor = Color.FromHex("#D9544F");
                PlusColor = Color.FromHex("#F09329");
                MinusColor = Color.FromHex("#F09329");
                DivideColor = Color.FromHex("#F09329");
            }
            else
            {
                DivideColor = Color.FromHex("#D9544F");
                PlusColor = Color.FromHex("#F09329");
                MultiplyColor = Color.FromHex("#F09329");
                MinusColor = Color.FromHex("#F09329");
            }

        }

        public void EqualSelected()
        {
            var parsedNumber = double.TryParse(Display, out var intCurrent);
            if (parsedNumber)
            {
                double result = 0;
                string currentOperator = CurrentOperation;
                if (currentOperator == "+")
                {
                    result = LastInput + intCurrent;
                }
                else if (currentOperator == "-")
                {
                    result = LastInput - intCurrent;
                }
                else if (currentOperator == "÷")
                {
                    if (intCurrent == 0)
                    {
                        Display = "Error";
                        LastInput = 0;
                        OperationComming = false;
                        return;
                    }
                    result = LastInput / intCurrent;
                }
                else if (currentOperator == "x")
                {
                    result = LastInput * intCurrent;
                }
                LastInput = Math.Round(result, 2);
                Display = LastInput.ToString();
            }
        }

        public void DeleteSelected()
        {
            LastInput = 0;
            OperationComming = false;
            Display = "0";
            CurrentOperation = "-1";
            PlusColor = Color.FromHex("#F09329");
            MultiplyColor = Color.FromHex("#F09329");
            MinusColor = Color.FromHex("#F09329");
            DivideColor = Color.FromHex("#F09329");
        }

        public void SingleDeleteSelected()
        {
            if (Display != "0" && Display != "Error")
            {
                if (Display.Length == 1) Display = "0";
                else Display = Display.Remove(Display.Length - 1);
            }
        }

        public void CommaSelected()
        {
            if (!Display.Contains("."))
            {
                Display = Display + ".";
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
