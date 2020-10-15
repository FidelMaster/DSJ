//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DSJ.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblPersona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblPersona()
        {
            this.TblCoordinadores = new HashSet<TblCoordinadore>();
        }
    
        public int Id { get; set; }
        public Nullable<int> IdCuenta { get; set; }
        public string Nombre { get; set; }
        public byte[] Apellido { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public Nullable<int> Celular { get; set; }
        public Nullable<int> Telefono { get; set; }
        public byte[] FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaActualizacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblCoordinadore> TblCoordinadores { get; set; }
        public virtual TblCuenta TblCuenta { get; set; }
    }
}
