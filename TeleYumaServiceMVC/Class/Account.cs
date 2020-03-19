using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Linq;




namespace TeleYumaApp.Class
{
    public class AccountObject
    {
        [DataMember]
        public account_info account_info { get; set; }
    }

    public class AccountObjectArray
    {
        [DataMember]
        public account_info[] account_list { get; set; }
    }

    public class account_info
    {

        [DataMember]
        public int i_account { get; set; }
        [DataMember]

        public string id { get; set; }
        [DataMember]

        public int i_customer { get; set; }
        [DataMember]

        public int billing_model { get; set; }
        [DataMember]

        public string activation_date { get; set; }
        [DataMember]

        public int i_product { get; set; }
        [DataMember]

        public string baddr1 { get; set; }
        [DataMember]

        public string baddr2 { get; set; }
        [DataMember]

        public string AuthorizationOnlyTransaction_id
        {
            get
            {
                if (baddr3 == "" || baddr3 == null)
                    return "0";
                else
                    return baddr3.Replace(" ", "");
            }
            set
            {
                baddr3 = value;
            }
        }
        [DataMember]

        public string baddr3 { get; set; }
        [DataMember]

        public string baddr4 { get; set; }
        [DataMember]

        public string baddr5 { get; set; }
        [DataMember]

        public int i_distributor { get; set; }

        [DataMember]

        public string batch_name { get; set; }
        [DataMember]

        public int control_number { get; set; }
        [DataMember]
        public string bill_status { get; set; }
        [DataMember]

        public string iso_4217 { get; set; }
        [DataMember]

        public float opening_balance { get; set; }
        [DataMember]

        public decimal balance { get; set; }
        [DataMember]
                    

        public string login { get; set; }
        [DataMember]

        public string password { get; set; }
        [DataMember]

        public string firstname { get; set; }
        [DataMember]

        public string lastname { get; set; }

        [DataMember]

        public string fullname { get { return firstname + " " + lastname; } }

        [DataMember]

        public string iniciales
        {
            get
            {
                try
                {
                    var inicial_nombre = firstname.ToCharArray()[0].ToString().ToUpper();
                    var inicial_apellido = lastname.ToCharArray()[0].ToString().ToUpper();
                    return inicial_nombre + inicial_apellido;
                }
                catch
                {
                    return "";
                }

            }
        }
        [DataMember]

        public string cont1 { get; set; }
        [DataMember]

        public string phone1 { get; set; }
        [DataMember]

        public string phone2 { get; set; }
        [DataMember]

        public string email { get; set; }
        [DataMember]

        public string country { get; set; }
        [DataMember]

        public string h323_password { get; set; }
        [DataMember]

        public string ecommerce_enabled = "Y";
        [DataMember]

        public string blocked { get; set; }
        [DataMember]
        [DefaultValue("0")]
        public string cont2 { get; set; }

        [DataMember]
        public MakeAccountTransactionResponse AccountTransactionResponse = new MakeAccountTransactionResponse();

      
    }


    public class GetAccountXDRListRequest
    {

        [DataMember]
        public string i_account { get; set; }
        [DataMember]
        public string from_date { get; set; }
        [DataMember]
        public string to_date { get; set; }

    }

    public class GetAccountXDRListResponse
    {
        [DataMember]
        public XDRInfo[] xdr_list { get; set; }
        [DataMember]
        public int total { get; set; }
    }

    public class XDRInfo
    {
        [DataMember]
        public string i_service { get; set; }
        [DataMember]
        public string subdivision { get; set; }
        [DataMember]
        public string disconnect_reason { get; set; }
        [DataMember]
        public string i_xdr { get; set; }
        [DataMember]
        public string CLD { get; set; }
        [DataMember]
        public string call_recording_server_url { get; set; }
        [DataMember]
        public string connect_time { get; set; }
        [DataMember]
        public string CLI { get; set; }
        [DataMember]
        public float charged_amount { get; set; }
        [DataMember]
        public decimal charged_amount2
        {
            get
            {
                var value = decimal.Round(Convert.ToDecimal(charged_amount), 2);
                if (value < 0)
                    return (value * -1);
                return value;
            }
        }
        private string _bill_time { get; set; }
           

        [DataMember]
        public string bill_time
        {
            get {
               return _bill_time;
            } set {
                try
                {
                    TimeZoneInfo easternZone;

                    try
                    {
                        easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                    }
                    catch (TimeZoneNotFoundException)
                    {
                        easternZone = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
                    }
                    _bill_time = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Parse(value), "UTC", easternZone.Id).ToString("yyyy-MM-dd h:mm:ss tt");

                }
                catch (Exception ex)
                {

                    _bill_time = value;
                } 
            }
        }
        [DataMember]
        public string bit_flags { get; set; }
        [DataMember]
        public string unix_connect_time { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string bill_status { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string account_id { get; set; }
        [DataMember]
        public string unix_disconnect_time { get; set; }
        [DataMember]
        public string disconnect_cause { get; set; }
        [DataMember]
        public string charged_quantity { get; set; }
        [DataMember]
        public string call_recording_url { get; set; }
        [DataMember]
        public string disconnect_time { get; set; }

    }


    public class MakeAccountTransactionRequest
    {
        [DataMember]
        public int i_account { get; set; }
        [DataMember]
        public string action { get; set; }
        [DataMember]
        public decimal amount { get; set; }
        [DataMember]
        public string visible_comment { get; set; }
        [DataMember]
        public string transaction_id { get; set; }

        [DataMember]
        public payment_method_info card_info { get; set; }

    }


    public class MakeAccountTransactionResponse
    {

        [DataMember]
        public string i_payment_transaction { get; set; }
        [DataMember]
        public float balance { get; set; }
        [DataMember]
        public string transaction_id { get; set; }

        [DataMember]
        public string authorization { get; set; }
        [DataMember]
        public string result_code { get; set; }
        [DataMember]
        public string i_xdr { get; set; }

    }



}
