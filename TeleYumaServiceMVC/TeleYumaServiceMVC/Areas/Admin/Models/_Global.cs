using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TeleYumaServiceMVC.Areas.Admin.Models
{



    public class AuthInfo
    {
        [DataMember]
        public string session_id { get; set; }
        [DataMember]
        public string login { get; set; }
        [DataMember]
        public string password { get; set; }

    }
    public enum TipoTienda
    {
        Padre,
        Hijo
    }
    public enum RolTienda
    {
        Gerente,
        Asociado
    }

    public static class _Global
    {
        public static async Task<customer_info> GetcustomerById(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {

                    var param = JsonConvert.SerializeObject(new { i_customer = id });
                    var URL = _Global.BaseUrlAdmin + _Global.Servicio.Customer + "/" + _Global.Metodo.get_customer_info + "/" + _Global.AuthInfoAdminJson + "/" + param;
                    var response = await client.GetStringAsync(URL);
                    return JsonConvert.DeserializeObject<CustomerObject>(response).customer_info;
                }
                catch (Exception ex)
                {
                    return new customer_info();
                }
            }
        }

        public static async Task<List<customer_info>> GetDistributors()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var param = JsonConvert.SerializeObject(new GetCustomerListRequest {offset = 0,limit = 5000 ,i_customer_type = 3});
                    var URL = _Global.BaseUrlAdmin + _Global.Servicio.Customer + "/" + _Global.Metodo.get_customer_list + "/" + _Global.AuthInfoAdminJson + "/" + param;
                    var response = await client.GetAsync(URL);
                    var json = await response.Content.ReadAsStringAsync();
                    var ErrorHandling = JsonConvert.DeserializeObject<ErrorHandling>(json);
                    if (ErrorHandling.faultstring is null)
                    {
                        return JsonConvert.DeserializeObject<GetCustomerListResponse>(json).customer_list.ToList();
                    }
                    else
                        return new List<customer_info>();
                }
                catch (Exception ex)
                {
                    return new List<customer_info>();
                }

            }

        }

        public static float ReglaDeTres(float porciento = 0, float total = 0, float porcion = 0)
        {

            try
            {

                int countValidator = 0;
                if (total is 0) countValidator++; if (porciento is 0) countValidator++; if (porcion is 0) countValidator++;
                if (countValidator != 1)
                    return 0;
                else
                {
                    if (porciento is 0)
                    {
                        return porcion * 100 / total;
                    }
                    else if (total is 0)
                    {
                        return porcion * 100 / porciento;
                    }
                    else
                    {
                        return porciento * total / 100;
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public static string FromDate
        {
            get
            {
                return "2019/04/29 00:00:00";
            }
        }

        public static string ToDate
        {
            get
            {
                return "2019/05/05 23:59:00";
            }
        }

        public static string GetDateFormat_YYMMDD(DateTime DateTime, string Hora = "inicio")
        {
            var YY = DateTime.Year.ToString();
            var MM = DateTime.Month.ToString();
            var DD = DateTime.Day.ToString();

            if (MM.Length == 1)
                MM = "0" + MM;
            if (DD.Length == 1)
                DD = "0" + DD;

            if (Hora == "inicio")
                return YY + "-" + MM + "-" + DD + " 00:00:00";
            else
                return YY + "-" + MM + "-" + DD + " 23:59:59";
        }

        public const bool ModoPrueba = true;
        
        public static string AuthInfoAdminJson
        {
            get
            {
                var admin = new AuthInfo
                {
                    login = "app-45-yuma",
                    password = "appyuma8708@**"
                };
                return JsonConvert.SerializeObject(admin);
            }
        }

        public static string BaseUrlServicio = "http://localhost:58723/api/";
        //public static string BaseUrlServicio = "http://smsteleyuma.azurewebsites.net/Service1.svc/";

        public static string BaseUrlAdmin = "https://mybilling.teleyuma.com/rest/";

        public static string BaseUrlCliente = "https://mybilling.teleyuma.com:8444/rest/";

        public static string CodigoVerificacion
        {
            get
            {
                var Codigo = "";

                var ran = new Random();
                var numeros = "123456789".ToCharArray();
                for (int x = 0; x < 4; x++)
                {
                    var ranNumero = ran.Next(numeros.Length);
                    var number = numeros[ranNumero].ToString();
                    Codigo += number;
                }
                return Codigo;
            }

        }

        public class Servicio
        {
            public const string Session = "Session";
            public const string Customer = "Customer";
            public const string Account = "Account";
        }

        public class Metodo
        {
            //Comun

            public const string change_password = "change_password ";

            #region  Session

            public const string login = "login";

            #endregion

            #region  Customer

            public const string get_customer_info = "get_customer_info";
            public const string get_customer_list = "get_customer_list";
            public const string add_customer = "add_customer";
            public const string update_customer = "update_customer";
            public const string make_transaction = "make_transaction";
            public const string get_payment_method_info = "get_payment_method_info";
            public const string update_payment_method = "update_payment_method";
            public const string update_service_features = "update_service_features";
            public const string get_customer_xdrs = "get_customer_xdrs";
            public const string validate_customer_info = "validate_customer_info";


            #endregion

            #region  Account
            public const string get_account_info = "get_account_info";
            public const string get_account_list = "get_account_list";
            public const string add_account = "add_account";
            public const string update_account = "update_account";
            public const string validate_account_info = "validate_account_info";
            public const string get_xdr_list = "get_xdr_list";

            #endregion


        }

        public static string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

    }

    public class ErrorHandling
    {
        [DataMember]
        [DefaultValue(false)]
        public bool faul { get; set; }
        [DataMember]
        public string faultcode { get; set; }
        [DataMember]
        public string faultstring
        {
            get
           ;
            set;
        }
    }
}