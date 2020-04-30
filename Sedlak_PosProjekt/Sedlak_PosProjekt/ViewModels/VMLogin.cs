using GalaSoft.MvvmLight.Command;
using Sedlak_PosProjekt.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Sedlak_PosProjekt
{
    public class VMLogin:INotifyPropertyChanged
    {

        public LoginCommand LoginCommand { get; set; }
        public RegisterCommand RegisterCommand { get; set; }
        public Action CloseAction { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private String response;

        public String Response
        {
            get { return response; }
            set { response = value; PropertyChanged(this, new PropertyChangedEventArgs("Response"));
            }
        }

        public VMLogin()
        {
            HIF3eLernzielDBEntities db = new HIF3eLernzielDBEntities();
            IEnumerable<Benutzer> AllUsers = (from a in db.Benutzers
                                              select a);
            foreach (Benutzer b in AllUsers) {
                b.LoggedIn = false;
            }
            db.SaveChanges();
            this.LoginCommand = new LoginCommand(this);
            this.RegisterCommand = new RegisterCommand(this);
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string passWord;

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        public String Schule { get; set; }

        public void LoginMethod() {
            HIF3eLernzielDBEntities db = new HIF3eLernzielDBEntities();
            if (validatePassword() == true) {
                MainWindow newWindow = new MainWindow();
                newWindow.ShowDialog();
                CloseAction();
            }
        }

        public void RegisterMethod() {
            HIF3eLernzielDBEntities db = new HIF3eLernzielDBEntities();
            if (PassWord == null || UserName == null || Schule == null) {
                Response = "Please fill out all Fields!";
            }
            else
            {
                if (PassWord.Length > 5 && UserName.Length > 2)
                {
                    string hashPassWord = HashCalculator.ComputeSha256Hash(PassWord);
                    Benutzer b = new Benutzer { Pwd = hashPassWord, Username = UserName, LoggedIn = true, Schule=Schule};
                    db.Benutzers.Add(b);
                    db.SaveChanges();
                    MainWindow newWindow = new MainWindow();
                    newWindow.ShowDialog();
                    CloseAction();
                }
                else
                {
                    Response = "Username min. 3 Letters, Pwd 6.";
                }
            }
        }

        private bool validatePassword() {
            HIF3eLernzielDBEntities db = new HIF3eLernzielDBEntities();
            if (UserName == null || PassWord == null) 
            {
                Response = "Please enter both values!";
                return false;
            }
            Benutzer User = (from a in db.Benutzers
                             where a.Username == UserName
                             select a).FirstOrDefault<Benutzer>();
            if (User == null) {
                Console.WriteLine("Non existing user");
                Response = "This User does not exist";
                return false;
            }
            if (User.Username == UserName && User.Pwd == HashCalculator.ComputeSha256Hash(PassWord))
            {
                User.LoggedIn = true;
                db.SaveChanges();
                return true;
            }
            else 
            {
                Response = "Password not correct";
                return false;
            }
        }
    }
}
