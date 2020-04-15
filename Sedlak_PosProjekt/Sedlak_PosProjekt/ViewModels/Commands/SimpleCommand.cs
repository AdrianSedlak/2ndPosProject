using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sedlak_PosProjekt.ViewModels.Commands
{
    public class SimpleCommand : ICommand
    {
        public VMLogin Vm { get; set; }

        public SimpleCommand (VMLogin vm)
        {
            this.Vm = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.Vm.SimpleMethod();
        }
    }
}
