//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeleYumaServiceMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RecargaNauta
    {
        public int id { get; set; }
        public string IdCuenta { get; set; }
        public Nullable<int> product_id { get; set; }
        public string TipoRecarga { get; set; }
        public Nullable<int> CodigoPais { get; set; }
        public string Numero { get; set; }
        public Nullable<int> Monto { get; set; }
        public Nullable<double> Impuesto { get; set; }
        public Nullable<double> Importe { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
    }
}
