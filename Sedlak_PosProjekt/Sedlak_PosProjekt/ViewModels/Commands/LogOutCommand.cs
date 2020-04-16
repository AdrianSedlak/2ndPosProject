using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sedlak_PosProjekt.ViewModels.Commands
{
    public class LogOutCommand : ICommand
    {
        public VMMain Vm { get; set; }

        public LogOutCommand(VMMain vm)
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
            this.Vm.LogOutMethod();
        }
    }
}
