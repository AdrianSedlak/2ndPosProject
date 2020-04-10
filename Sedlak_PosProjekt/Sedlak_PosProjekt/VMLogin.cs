using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sedlak_PosProjekt
{
    class VMLogin
    {
        public RelayCommand<IClosable> CloseWindowCommand { get; private set; }

        public VMLogin() {
            this.CloseWindowCommand = new RelayCommand<IClosable>(this.CloseWindow);
        }

        private void CloseWindow(IClosable window) {
            if (window != null) {
                window.Close();            
            }        
        }
    }
}
