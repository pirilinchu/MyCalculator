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
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
