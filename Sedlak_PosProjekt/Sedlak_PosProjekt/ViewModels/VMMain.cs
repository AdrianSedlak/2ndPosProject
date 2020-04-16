using Sedlak_PosProjekt.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedlak_PosProjekt
{
    public class VMMain
    {
        public LogOutCommand LogOutCommand { get; set; }
        public SearchCommand SearchCommand { get; set; }
        public AddCommand AddCommand { get; set; }


        public void LogOutMethod() {
            Login login = new Login();
            login.ShowDialog();
        }

        public void SearchMethod() {
            Console.WriteLine("Search");
        }

        public void AddMethod() {
            Console.WriteLine("Add");
        }

        public VMMain()
        {
            this.LogOutCommand = new LogOutCommand(this);
            this.SearchCommand = new SearchCommand(this);
            this.AddCommand = new AddCommand(this);
        }
	}
}
