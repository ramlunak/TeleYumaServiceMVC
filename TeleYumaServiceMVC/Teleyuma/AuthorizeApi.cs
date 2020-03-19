using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleYumaServiceMVC.Teleyuma
{

    public class ErrorResponse
    {
        public int ErrorCode { get; set; }
        public Diccionario.errors ErrorType { get; set; }
        public string ErrorText { get; set; }
    }

    public class AutorizeRequest
    {
        public string apiKey { get; set; }
    }
    
    public class ErrorDictionary
    {
        public List<ErrorResponse> Errors
        {
            get
            {
                return new List<ErrorResponse>()
                {
                    new ErrorResponse{ErrorCode=0,ErrorType= Diccionario.errors.NoError,ErrorText=""},
                    new ErrorResponse{ErrorCode=1,ErrorType= Diccionario.errors.KeyError,ErrorText="Error de autenticación."},
                };
            }
        }
    }

}
