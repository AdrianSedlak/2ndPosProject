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

        public void LoginMethod() {
            HIF3eLernzielDBEntities db = new HIF3eLernzielDBEntities();
            if (validatePassword() == true) {
                CloseAction();
            }
        }

        public void RegisterMethod() {
            HIF3eLernzielDBEntities db = new HIF3eLernzielDBEntities();
            if (PassWord.Length > 5 && UserName.Length > 2)
            {
                string hashPassWord = HashCalculator.ComputeSha256Hash(PassWord);
                Benutzer b = new Benutzer { Pwd = hashPassWord, Username = UserName };
                db.Benutzers.Add(b);
                db.SaveChanges();
                CloseAction();
            }
            else {
                Response = "Username min. 3 Letters, Pwd 6.";
            }
        }

        private bool validatePassword() {
            HIF3eLernzielDBEntities db = new HIF3eLernzielDBEntities();
            if (UserName == null || PassWord == null) 
            {
                Response = "Please enter both values!";
                return false;
            }
            string userDB = (from a in db.Benutzers
                             where a.Username == UserName
                             select a.Username).First().Trim().ToString();
            string passwordDB = (from a in db.Benutzers
                                 where a.Username == userDB
                                 select a.Pwd).First().Trim().ToString();
            if (userDB == UserName && passwordDB == HashCalculator.ComputeSha256Hash(PassWord))
            {
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
