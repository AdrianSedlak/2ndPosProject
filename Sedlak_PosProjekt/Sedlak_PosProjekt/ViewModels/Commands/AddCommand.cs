using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sedlak_PosProjekt.ViewModels.Commands
{
    public class AddCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public VMMain Vm { get; set; }

        public AddCommand(VMMain vm)
        {
            this.Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.Vm.AddMethod();
        }
    }
}
