//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sedlak_PosProjekt
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lernziele
    {
        public int ID { get; set; }
        public string Beschreibung { get; set; }
        public Nullable<int> Fach { get; set; }
        public Nullable<int> User { get; set; }
    
        public virtual Benutzer Benutzer { get; set; }
        public virtual Faecher Faecher { get; set; }
    }
}
