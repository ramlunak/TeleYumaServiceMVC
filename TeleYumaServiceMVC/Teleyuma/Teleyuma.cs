using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TeleYumaServiceMVC.Teleyuma
{
    public class Teleyuma
    {
        public List<Producto> Productos
        {
            get
            {
                return new List<Producto> {
                    new Producto
                    {
                        Code = "CU_CU_TopUp",
                        Image = "producto.png",
                        Name = "Recarga movil",
                        ProviderCode = "CUCU",
                        CountryIso = "CU",
                        MinValue = 10,
                        MaxValue = 80,
                        CommissionRate= (float)0.07,
                        ValidationRegex = "^0?53([0-9]{8})$",
                        DisplayText = "CUC 10.00-80.00",
                    },
                     new Producto
                    {
                        Code = "CU_NU_TopUp",
                        Image = "producto.png",
                        Name = "Recarga nauta",
                        ProviderCode = "NUCU",
                        CountryIso = "CU",
                        MinValue = 5,
                        MaxValue = 50,
                        CommissionRate = (float)0.07,
                        ValidationRegex = "^[\\w\\._%+-]+@nauta\\.(?:com|co)\\.cu$",
                        DisplayText = "CUC 5.00-50.00",
                    },

                };
            }
        }


        public class TopUpRequest
        {
            public string AccountNumber { get; set; }
            public string SkuCode { get; set; }
            public float SendValue { get; set; }
            public string DistributorRef { get; set; }
            public bool ValidateOnly { get; set; }

        }

        public class TopUpResponse
        {
            public string AccountNumber { get; set; }
            public string TransferRef { get; set; }
            public string DistributorRef { get; set; }
            public float ReceiveValue { get; set; }
            public float SendValue { get; set; }
            public float ReceiveCurrencyIso { get; set; }
            public float SendCurrencyIso { get; set; }
            public float CommissionApplied { get; set; }
            public string StartedUtc { get; set; }
            public string CompletedUtc { get; set; }
            public string ProcessingState { get; set; }
            public string ResultCode { get; set; }
            public ErrorCode[] ErrorCodes { get; set; }

        }

        public class ErrorCode
        {
            [DataMember]
            public string Code { get; set; }
            [DataMember]
            public string Context { get; set; }

        }

    }
}