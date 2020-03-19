using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TeleYumaServiceMVC.Models;
using TeleYumaServiceMVC.Teleyuma;

namespace TeleYumaServiceMVC.Controllers
{
    public class ProductoController : ApiController
    {

        private TeleYumaEntities1 db = new TeleYumaEntities1();

        public async Task<IHttpActionResult> Get()
        {
            var validateProducto = new ValidateProducto
            {
                IdCuenta = "5355043317",
                Producto = "royber.arias@nauta.com.cu",
                Monto = 5,
                TipoProducto = "nauta"
            };

            var Product = await Ding.GetProductsByaccountNumber(validateProducto.Producto);
            var Provider = await Ding.GetProvidersByaccountNumber(validateProducto.Producto);
                      

            if (Product is null || Provider is null)
            {
                ;
            }

            if (!Product.Items.Any() || !Provider.Items.Any())
            {
                ;
            }

            var promociones = db.DingPromo.Where(x => x.Estado == true && validateProducto.Monto >= x.Min && validateProducto.Monto <= x.Max).ToList();

            var result = new Producto();

            try
            {
                result.Code = Product.Items.First().SkuCode;
                result.Image = "producto.png";
                result.Name = Provider.Items.First().Name;
                result.ProviderCode = Provider.Items.First().ProviderCode;
                result.CountryIso = Provider.Items.First().CountryIso;
                result.MinValue = Product.Items.First().Minimum.SendValue;
                result.MaxValue = Product.Items.First().Maximum.SendValue;
                result.CommissionRate = (float)Product.Items.First().CommissionRate;
                result.ValidationRegex = Provider.Items.First().ValidationRegex;
                result.DisplayText = Product.Items.First().DefaultDisplayText;
                if (promociones.Any())
                    result.Bono = promociones.First().MontoText;

            }
            catch (Exception)
            {

              return  CreatedAtRoute("DefaultApi", null, new { });
            }

           return CreatedAtRoute("DefaultApi", null, result);
        }

        public async Task<IHttpActionResult> Post([FromBody]ValidateProducto validateProducto)
        {
            if (Autorize.TeleyumaLogin(this.Request.Headers).ErrorCode > 0)
                return CreatedAtRoute("DefaultApi", null, Autorize.TeleyumaLogin(this.Request.Headers));

            var Product = await Ding.GetProductsByaccountNumber(validateProducto.Producto);
            var Provider = await Ding.GetProvidersByaccountNumber(validateProducto.Producto);


            if (Product is null || Provider is null)
                return CreatedAtRoute("DefaultApi", null, new { });
            if (!Product.Items.Any() || !Provider.Items.Any())
                return CreatedAtRoute("DefaultApi", null, new { });

            var promociones = db.DingPromo.Where(x => x.Estado == true && validateProducto.Monto >= x.Min && validateProducto.Monto <= x.Max).ToList();

            var result = new Producto();

            try
            {
                result.Code = Product.Items.First().SkuCode;
                result.Image = "producto.png";
                result.Name = Provider.Items.First().Name;
                result.ProviderCode = Provider.Items.First().ProviderCode;
                result.CountryIso = Provider.Items.First().CountryIso;
                result.MinValue = Product.Items.First().Minimum.SendValue;
                result.MaxValue = Product.Items.First().Maximum.SendValue;
                result.CommissionRate = (float)Product.Items.First().CommissionRate;
                result.ValidationRegex = Provider.Items.First().ValidationRegex;
                result.DisplayText = Product.Items.First().DefaultDisplayText;
                if (promociones.Any())
                    result.Bono = promociones.First().MontoText;

            }
            catch (Exception)
            {

                return CreatedAtRoute("DefaultApi", null, new { });
            }

            return CreatedAtRoute("DefaultApi", null, result);

        }

    }
}
