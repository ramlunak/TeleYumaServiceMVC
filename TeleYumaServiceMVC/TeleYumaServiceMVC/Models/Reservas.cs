//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeleYumaServiceMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reservas
    {
        public int IdReserva { get; set; }
        public Nullable<int> IdPromocion { get; set; }
        public string IdCuenta { get; set; }
        public string Telefono { get; set; }
        public Nullable<double> Monto { get; set; }
        public Nullable<double> TotalPagar { get; set; }
        public string FechaReserva { get; set; }
        public string FechaRecarga { get; set; }
        public string Estado { get; set; }
        public string Mensaje { get; set; }
        public Nullable<int> i_account { get; set; }
        public int id { get; set; }
    }
}
