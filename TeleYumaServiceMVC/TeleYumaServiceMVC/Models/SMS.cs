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
    
    public partial class SMS
    {     
        public int Idsms { get; set; }
        public string i_account { get; set; }
        public string monto { get; set; }
        public string NumeroTelefono { get; set; }
        public string NombreContacto { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string RemitenteNumero { get; set; }
        public string RemitenteNombre { get; set; }
        public string Firma { get; set; }
        public Nullable<int> ItemHeight { get; set; }
        public Nullable<bool> Entrante { get; set; }
        public Nullable<bool> Saliente { get; set; }
        public Nullable<bool> IsSend { get; set; }
        public Nullable<bool> IsNew { get; set; }
        public string Phone1 { get; set; }
        public Nullable<bool> Notify { get; set; }
        public int id { get; set; }
        public string Mensaje { get; set; }
    }
}