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
    
    public partial class Promocion
    {
        public int IdPromocion { get; set; }
        public Nullable<int> Estado { get; set; }
        public string Texto { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Noti { get; set; }
        public Nullable<int> IntervaloNoti { get; set; }
        public Nullable<int> Monto { get; set; }
        public int Id { get; set; }
    }
}