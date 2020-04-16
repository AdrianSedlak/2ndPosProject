using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sedlak_PosProjekt.ViewModels.Commands
{
    public class SearchCommand : ICommand
    {
        public VMMain Vm { get; set; }
        public event EventHandler CanExecuteChanged;

        public SearchCommand(VMMain vm)
        {
            this.Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.Vm.SearchMethod();
        }
    }
}
