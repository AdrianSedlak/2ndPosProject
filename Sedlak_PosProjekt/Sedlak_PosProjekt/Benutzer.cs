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
    
    public partial class Benutzer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Benutzer()
        {
            this.Lernzieles = new HashSet<Lernziele>();
        }
    
        public int UserID { get; set; }
        public string Pwd { get; set; }
        public string Username { get; set; }
        public bool LoggedIn { get; set; }
        public string Schule { get; set; }
    
        public virtual Schule Schule1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lernziele> Lernzieles { get; set; }
    }
}
