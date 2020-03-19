using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeleYumaServiceMVC.Teleyuma;

namespace TeleYumaServiceMVC.Models
{
    public static class Autorize
    {
        private static teleyumaEntities1 db = new teleyumaEntities1();

        public static ErrorResponse TeleyumaLogin(System.Net.Http.Headers.HttpRequestHeaders headers)
        {
            return new ErrorDictionary().Errors.First(x => x.ErrorType == Diccionario.errors.NoError);
            string apiKey = null;

            if (headers.Contains("apiKey"))
            {
                apiKey = headers.GetValues("apiKey").First();
            }
            if (string.IsNullOrEmpty(apiKey))
            {
                return apiKeyNull();
            }

            try
            {
                var users = db.Credenciales.Where(x => x.Proveedor == "teleyuma").ToList();
                var keys = users.Where(x => x.KeyGenerate == apiKey);

                if (keys.Any())
                    return new ErrorDictionary().Errors.First(x => x.ErrorType == Diccionario.errors.NoError);
                else
                    return new ErrorDictionary().Errors.First(x => x.ErrorCode == 1);
            }
            catch
            {
                return new ErrorDictionary().Errors.First(x => x.ErrorType == Diccionario.errors.KeyError);
            }

        }

        public static ErrorResponse apiKeyNull()
        {
            return new ErrorDictionary().Errors.First(x => x.ErrorType == Diccionario.errors.KeyError);
        }

    }
}