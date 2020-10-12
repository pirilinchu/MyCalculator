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
            NumberCommand = new Command<string>(Model.NumberSelected);
            OperatorCommand = new Command<string>(Model.OperatorSelected);
            EqualCommand = new Command(Model.EqualSelected);
            DeleteCommand = new Command(Model.DeleteSelected);
            SingleDeleteCommand = new Command(Model.SingleDeleteSelected);
            CommaCommand = new Command(Model.CommaSelected);
        }
    }
}
