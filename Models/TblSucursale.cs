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
    
    public partial class TblSucursale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblSucursale()
        {
            this.TblCuentaSucursales = new HashSet<TblCuentaSucursale>();
        }
    
        public int Id { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public Nullable<double> Long { get; set; }
        public Nullable<double> Lat { get; set; }
        public string CreadoPor { get; set; }
        public byte[] FechaCreacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblCuentaSucursale> TblCuentaSucursales { get; set; }
        public virtual TblEmpresa TblEmpresa { get; set; }
    }
}