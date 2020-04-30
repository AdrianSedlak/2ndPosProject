using Sedlak_PosProjekt.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sedlak_PosProjekt
{
    public class VMMain:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Action CloseAction { get; set; }

        public IEnumerable<Lernziele> AlleLernziele {
            get {
                HIF3eLernzielDBEntities db = new HIF3eLernzielDBEntities();
                var erg = from l in db.Lernzieles
                          join b in db.Benutzers on l.User equals b.UserID
                          where b.LoggedIn == true
                          select l;
                return erg.ToList();
            }
        }

        private String titel;

        public String VMTitel
        {
            get { return titel; }
            set { titel = value;
                PropertyChanged(this, new PropertyChangedEventArgs("VMTitel"));
            }
        }

        private String beschreibung;

        public String VMBeschreibung
        {
            get { return beschreibung; }
            set { beschreibung = value;
                PropertyChanged(this, new PropertyChangedEventArgs("VMBeschreibung"));
            }
        }

        private DateTime vmLernzielDatum;

        public DateTime VmLernzielDatum
        {
            get { return vmLernzielDatum; }
            set { vmLernzielDatum = value;
                PropertyChanged(this, new PropertyChangedEventArgs("VmLernzielDatum"));
            }
        }

        public LogOutCommand LogOutCommand { get; set; }
        public AddCommand AddCommand { get; set; }
        public DeleteCommand DeleteCommand { get; set; }

        public void LogOutMethod() {
            Login login = new Login();
            login.ShowDialog();
            CloseAction();
        }

        public void AddMethod() {
            HIF3eLernzielDBEntities db = new HIF3eLernzielDBEntities();
            Benutzer CurrentUsers = (from a in db.Benutzers
                                     where a.LoggedIn==true
                                              select a).FirstOrDefault<Benutzer>();
            Lernziele Lernziel = new Lernziele { User = CurrentUsers.UserID, Titel = VMTitel, Beschreibung = VMBeschreibung, Datum=VmLernzielDatum};
            db.Lernzieles.Add(Lernziel);
            db.SaveChanges();
            PropertyChanged(this, new PropertyChangedEventArgs("AlleLernziele"));
            VMBeschreibung = "";
            VMTitel = "";
        }

        public void DeleteMethod() {
            if (GewaehltesLernziel != null) {
                HIF3eLernzielDBEntities db = new HIF3eLernzielDBEntities();
                Lernziele Gewaehlt = db.Lernzieles.Find(GewaehltesLernziel.ID);
                if (Gewaehlt != null)
                {
                    db.Lernzieles.Remove(Gewaehlt);
                    db.SaveChanges();
                    PropertyChanged(this, new PropertyChangedEventArgs("AlleLernziele"));
                }
            }
            
        }

        private Lernziele gewaehltesLernziel;

        public Lernziele GewaehltesLernziel
        {
            get { return gewaehltesLernziel; }
            set { gewaehltesLernziel = value;
                PropertyChanged(this, new PropertyChangedEventArgs("GewaehltesLernziel"));
            }
        }


        public VMMain()
        {
            this.LogOutCommand = new LogOutCommand(this);
            this.AddCommand = new AddCommand(this);
            this.DeleteCommand = new DeleteCommand(this);
        }
	}
}
