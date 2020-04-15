using GalaSoft.MvvmLight.Command;
using Sedlak_PosProjekt.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Sedlak_PosProjekt
{
    public class VMLogin
    {
        public Action CloseAction {get; set;}

        public SimpleCommand SimpleCommand { get; set; }

        public VMLogin() {
            this.SimpleCommand = new SimpleCommand(this);
        }

        public void SimpleMethod() {
            CloseAction();
        }
    }
}
