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

        private teleyumaEntities1 db = new teleyumaEntities1();

        public async Task<IHttpActionResult> Get(string id)
        {
            var validateProducto = new ValidateProducto
            {
                IdCuenta = "5355043317",
                Producto = "5355043317",
                Monto = (float)20,
                TipoProducto = "movil"
            };

            if (!string.IsNullOrEmpty(id))
            {
                validateProducto = new ValidateProducto
                {
                    IdCuenta = "5355043317",
                    Producto = "5355043317",
                    Monto = (float)20,
                    TipoProducto = id
                };
            }

            var Product = await Ding.GetProductsByaccountNumber(validateProducto.Producto);
            var Provider = await Ding.GetProvidersByaccountNumber(validateProducto.Producto);

            
            if (Product is null || Provider is null)
                return CreatedAtRoute("DefaultApi", null, new { });
            else
              if (!Product.Items.Any() || !Provider.Items.Any())
                return CreatedAtRoute("DefaultApi", null, new { });


          
            var result = new Producto();
            var Listresult = new List<Producto>();

            try
            {
                if (Product.Items.Length == 0)
                {
                    return CreatedAtRoute("DefaultApi", null, new { });
                }

                if (validateProducto.TipoProducto == "movil")
                {

                    var promociones = db.DingPromo.Where(x => x.Estado == true && validateProducto.Monto >= x.Min && validateProducto.Monto <= x.Max && validateProducto.Producto.Contains("53")).ToList();
                    
                    var producto = Product.Items.First(x=>x.SkuCode == "CU_CU_TopUp");
                    var proveedor = Provider.Items.First(x =>x.ProviderCode == "CUCU");                 

                    result.Code = producto.SkuCode;
                    result.Image = "producto.png";
                    result.Name = proveedor.Name;
                    result.ProviderCode = proveedor.ProviderCode;
                    result.CountryIso = proveedor.CountryIso;
                    result.MinValue = producto.Minimum.SendValue;
                    result.MaxValue = producto.Maximum.SendValue;
                    result.CommissionRate = (float)producto.CommissionRate;
                    result.ValidationRegex = proveedor.ValidationRegex;
                    result.DisplayText = producto.DefaultDisplayText;
                    if (promociones.Any())
                        result.Bono = promociones.First().MontoText;
                    Listresult.Add(result);
                }
                else
                if (validateProducto.TipoProducto == "nauta")
                {
                  
                    var producto = Product.Items.First(x => x.SkuCode == "CU_NU_TopUp");
                    var proveedor = Provider.Items.First(x => x.ProviderCode == "CUCU");

                    result.Code = producto.SkuCode;
                    result.Image = "producto.png";
                    result.Name = proveedor.Name;
                    result.ProviderCode = proveedor.ProviderCode;
                    result.CountryIso = proveedor.CountryIso;
                    result.MinValue = producto.Minimum.SendValue;
                    result.MaxValue = producto.Maximum.SendValue;
                    result.CommissionRate = (float)producto.CommissionRate;
                    result.ValidationRegex = proveedor.ValidationRegex;
                    result.DisplayText = producto.DefaultDisplayText;
                    Listresult.Add(result);
                }
                else
                if (validateProducto.TipoProducto == "datos600MG")
                {
                                    
                    var producto = Product.Items.First(x => x.SkuCode == "1HCUCU4205");
                    var proveedor = Provider.Items.First(x =>x.ProviderCode == "1HCU");

                    result.Code = producto.SkuCode;
                    result.Image = "producto.png";
                    result.Name = proveedor.Name;
                    result.ProviderCode = proveedor.ProviderCode;
                    result.CountryIso = proveedor.CountryIso;
                    result.MinValue = producto.Minimum.SendValue;
                    result.MaxValue = producto.Maximum.SendValue;
                    result.CommissionRate = (float)producto.CommissionRate;
                    result.ValidationRegex = proveedor.ValidationRegex;
                    result.DisplayText = $"{" CUC "+ result.MinValue.ToString("F") + " - " + result.MaxValue.ToString("F")}";
                    Listresult.Add(result);
                }
                else
                if (validateProducto.TipoProducto == "datos1G")
                {
                   
                    var producto = Product.Items.First(x => x.SkuCode == "1HCUCU68614");
                    var proveedor = Provider.Items.First(x => x.ProviderCode == "1HCU");

                    result.Code = producto.SkuCode;
                    result.Image = "producto.png";
                    result.Name = proveedor.Name;
                    result.ProviderCode = proveedor.ProviderCode;
                    result.CountryIso = proveedor.CountryIso;
                    result.MinValue = producto.Minimum.SendValue;
                    result.MaxValue = producto.Maximum.SendValue;
                    result.CommissionRate = (float)producto.CommissionRate;
                    result.ValidationRegex = proveedor.ValidationRegex;
                    result.DisplayText = $"{" CUC " + result.MinValue.ToString("F") + " - " + result.MaxValue.ToString("F")}";
                    Listresult.Add(result);
                }
                else
                if (validateProducto.TipoProducto == "datos2_5G")
                {
                 
                    var producto = Product.Items.First(x => x.SkuCode == "1HCUCU26597");
                    var proveedor = Provider.Items.First(x => x.ProviderCode == "1HCU");

                    result.Code = producto.SkuCode;
                    result.Image = "producto.png";
                    result.Name = proveedor.Name;
                    result.ProviderCode = proveedor.ProviderCode;
                    result.CountryIso = proveedor.CountryIso;
                    result.MinValue = producto.Minimum.SendValue;
                    result.MaxValue = producto.Maximum.SendValue;
                    result.CommissionRate = (float)producto.CommissionRate;
                    result.ValidationRegex = proveedor.ValidationRegex;
                    result.DisplayText = $"{" CUC " + result.MinValue.ToString("F") + " - " + result.MaxValue.ToString("F")}";
                    Listresult.Add(result);
                }


                //if (Product.Items.Length == 1 && (Product.Items.First().SkuCode == "CU_CU_TopUp" || Product.Items.First().SkuCode == "CU_NU_TopUp"))
                //{
                //    result.Code = Product.Items.First().SkuCode;
                //    result.Image = "producto.png";
                //    result.Name = Provider.Items.First().Name;
                //    result.ProviderCode = Provider.Items.First().ProviderCode;
                //    result.CountryIso = Provider.Items.First().CountryIso;
                //    result.MinValue = Product.Items.First().Minimum.SendValue;
                //    result.MaxValue = Product.Items.First().Maximum.SendValue;
                //    result.CommissionRate = (float)Product.Items.First().CommissionRate;
                //    result.ValidationRegex = Provider.Items.First().ValidationRegex;
                //    result.DisplayText = Product.Items.First().DefaultDisplayText;
                //    if (promociones.Any())
                //        result.Bono = promociones.First().MontoText;
                //    Listresult.Add(result);
                //}
                //else
                //{

                //    var itm = Product.Items.Where(x => x.Minimum.SendValue >= validateProducto.Monto && x.Maximum.SendValue <= validateProducto.Monto).ToList();

                //    if (itm.Any() && (itm.First().SkuCode == "CU_CU_TopUp" || itm.First().SkuCode == "CU_NU_TopUp"))
                //    {
                //        result.Code = itm.First().SkuCode;
                //        result.Image = "producto.png";
                //        result.Name = Provider.Items.First().Name;
                //        result.ProviderCode = Provider.Items.First().ProviderCode;
                //        result.CountryIso = Provider.Items.First().CountryIso;
                //        result.MinValue = itm.First().Minimum.SendValue;
                //        result.MaxValue = itm.First().Maximum.SendValue;
                //        result.CommissionRate = (float)itm.First().CommissionRate;
                //        result.ValidationRegex = Provider.Items.First().ValidationRegex;
                //        result.DisplayText = itm.First().DefaultDisplayText;
                //        if (promociones.Any())
                //            result.Bono = promociones.First().MontoText;
                //    }
                //    else
                //    {
                //        foreach (var item in Product.Items)
                //        {
                //            if (item.SkuCode == "CU_CU_TopUp" || item.SkuCode == "CU_NU_TopUp")
                //            {
                //                result = new Producto();
                //                result.Code = item.SkuCode;
                //                result.Image = "producto.png";
                //                result.Name = Provider.Items.First().Name;
                //                result.ProviderCode = Provider.Items.First().ProviderCode;
                //                result.CountryIso = Provider.Items.First().CountryIso;
                //                result.MinValue = item.Minimum.SendValue;
                //                result.MaxValue = item.Maximum.SendValue;
                //                result.CommissionRate = (float)item.CommissionRate;
                //                result.ValidationRegex = Provider.Items.First().ValidationRegex;
                //                result.DisplayText = item.DefaultDisplayText;
                //                if (promociones.Any())
                //                    result.Bono = promociones.First().MontoText;
                //                Listresult.Add(result);
                //            }
                //        }
                //        //return CreatedAtRoute("DefaultApi", null, Listresult);
                //    }
                //}

            }
            catch (Exception ex)
            {

                return CreatedAtRoute("DefaultApi", null, new { });
            }

            if (Listresult.Count == 0)
            {
                return CreatedAtRoute("DefaultApi", null, new { });
            }

            return CreatedAtRoute("DefaultApi", null, result);
        }

        public async Task<IHttpActionResult> Post([FromBody]ValidateProducto validateProducto)
        {
            // if (Autorize.TeleyumaLogin(this.Request.Headers).ErrorCode > 0)
            //    return CreatedAtRoute("DefaultApi", null, Autorize.TeleyumaLogin(this.Request.Headers));

            var Product = await Ding.GetProductsByaccountNumber(validateProducto.Producto);
            var Provider = await Ding.GetProvidersByaccountNumber(validateProducto.Producto);


            if (Product is null || Provider is null)
                return CreatedAtRoute("DefaultApi", null, new { });
            else
            if (!Product.Items.Any() || !Provider.Items.Any())
                return CreatedAtRoute("DefaultApi", null, new { });
                               

            var result = new Producto();
            var Listresult = new List<Producto>();

            try
            {
                if (Product.Items.Length == 0)
                {
                    return CreatedAtRoute("DefaultApi", null, new { });
                }

                if (validateProducto.TipoProducto == "movil")
                {

                    var promociones = db.DingPromo.Where(x => x.Estado == true && validateProducto.Monto >= x.Min && validateProducto.Monto <= x.Max && validateProducto.Producto.Contains("53")).ToList();

                    var producto = Product.Items.First(x => x.SkuCode == "CU_CU_TopUp");
                    var proveedor = Provider.Items.First(x => x.ProviderCode == "CUCU");

                    result.Code = producto.SkuCode;
                    result.Image = "producto.png";
                    result.Name = proveedor.Name;
                    result.ProviderCode = proveedor.ProviderCode;
                    result.CountryIso = proveedor.CountryIso;
                    result.MinValue = producto.Minimum.SendValue;
                    result.MaxValue = producto.Maximum.SendValue;
                    result.CommissionRate = (float)producto.CommissionRate;
                    result.ValidationRegex = proveedor.ValidationRegex;
                    result.DisplayText = producto.DefaultDisplayText;
                    if (promociones.Any())
                        result.Bono = promociones.First().MontoText;
                    Listresult.Add(result);
                }
                else
                if (validateProducto.TipoProducto == "nauta")
                {

                    var producto = Product.Items.First(x => x.SkuCode == "CU_NU_TopUp");
                    var proveedor = Provider.Items.First(x => x.ProviderCode == "CUCU");

                    result.Code = producto.SkuCode;
                    result.Image = "producto.png";
                    result.Name = proveedor.Name;
                    result.ProviderCode = proveedor.ProviderCode;
                    result.CountryIso = proveedor.CountryIso;
                    result.MinValue = producto.Minimum.SendValue;
                    result.MaxValue = producto.Maximum.SendValue;
                    result.CommissionRate = (float)producto.CommissionRate;
                    result.ValidationRegex = proveedor.ValidationRegex;
                    result.DisplayText = producto.DefaultDisplayText;
                    Listresult.Add(result);
                }
                else
                if (validateProducto.TipoProducto == "datos600MG")
                {
                    var producto = Product.Items.First(x => x.SkuCode == "1HCUCU4205");
                    var proveedor = Provider.Items.First(x => x.ProviderCode == "1HCU");

                    result.Code = producto.SkuCode;
                    result.Image = "producto.png";
                    result.Name = proveedor.Name;
                    result.ProviderCode = proveedor.ProviderCode;
                    result.CountryIso = proveedor.CountryIso;
                    result.MinValue = producto.Minimum.SendValue;
                    result.MaxValue = producto.Maximum.SendValue;
                    result.CommissionRate = (float)producto.CommissionRate;
                    result.ValidationRegex = proveedor.ValidationRegex;
                    result.DisplayText = $"{" CUC " + result.MinValue.ToString("F") + " - " + result.MaxValue.ToString("F")}";
                    Listresult.Add(result);
                }
                else
                if (validateProducto.TipoProducto == "datos1G")
                {

                    var producto = Product.Items.First(x => x.SkuCode == "1HCUCU68614");
                    var proveedor = Provider.Items.First(x => x.ProviderCode == "1HCU");

                    result.Code = producto.SkuCode;
                    result.Image = "producto.png";
                    result.Name = proveedor.Name;
                    result.ProviderCode = proveedor.ProviderCode;
                    result.CountryIso = proveedor.CountryIso;
                    result.MinValue = producto.Minimum.SendValue;
                    result.MaxValue = producto.Maximum.SendValue;
                    result.CommissionRate = (float)producto.CommissionRate;
                    result.ValidationRegex = proveedor.ValidationRegex;
                    result.DisplayText = $"{" CUC " + result.MinValue.ToString("F") + " - " + result.MaxValue.ToString("F")}";
                    Listresult.Add(result);
                }
                else
                if (validateProducto.TipoProducto == "datos2_5G")
                {

                    var producto = Product.Items.First(x => x.SkuCode == "1HCUCU26597");
                    var proveedor = Provider.Items.First(x => x.ProviderCode == "1HCU");

                    result.Code = producto.SkuCode;
                    result.Image = "producto.png";
                    result.Name = proveedor.Name;
                    result.ProviderCode = proveedor.ProviderCode;
                    result.CountryIso = proveedor.CountryIso;
                    result.MinValue = producto.Minimum.SendValue;
                    result.MaxValue = producto.Maximum.SendValue;
                    result.CommissionRate = (float)producto.CommissionRate;
                    result.ValidationRegex = proveedor.ValidationRegex;
                    result.DisplayText = $"{" CUC " + result.MinValue.ToString("F") + " - " + result.MaxValue.ToString("F")}";
                    Listresult.Add(result);
                }


                //if (Product.Items.Length == 1 && (Product.Items.First().SkuCode == "CU_CU_TopUp" || Product.Items.First().SkuCode == "CU_NU_TopUp"))
                //{
                //    result.Code = Product.Items.First().SkuCode;
                //    result.Image = "producto.png";
                //    result.Name = Provider.Items.First().Name;
                //    result.ProviderCode = Provider.Items.First().ProviderCode;
                //    result.CountryIso = Provider.Items.First().CountryIso;
                //    result.MinValue = Product.Items.First().Minimum.SendValue;
                //    result.MaxValue = Product.Items.First().Maximum.SendValue;
                //    result.CommissionRate = (float)Product.Items.First().CommissionRate;
                //    result.ValidationRegex = Provider.Items.First().ValidationRegex;
                //    result.DisplayText = Product.Items.First().DefaultDisplayText;
                //    if (promociones.Any())
                //        result.Bono = promociones.First().MontoText;
                //    Listresult.Add(result);
                //}
                //else
                //{

                //    var itm = Product.Items.Where(x => x.Minimum.SendValue >= validateProducto.Monto && x.Maximum.SendValue <= validateProducto.Monto).ToList();

                //    if (itm.Any() && (itm.First().SkuCode == "CU_CU_TopUp" || itm.First().SkuCode == "CU_NU_TopUp"))
                //    {
                //        result.Code = itm.First().SkuCode;
                //        result.Image = "producto.png";
                //        result.Name = Provider.Items.First().Name;
                //        result.ProviderCode = Provider.Items.First().ProviderCode;
                //        result.CountryIso = Provider.Items.First().CountryIso;
                //        result.MinValue = itm.First().Minimum.SendValue;
                //        result.MaxValue = itm.First().Maximum.SendValue;
                //        result.CommissionRate = (float)itm.First().CommissionRate;
                //        result.ValidationRegex = Provider.Items.First().ValidationRegex;
                //        result.DisplayText = itm.First().DefaultDisplayText;
                //        if (promociones.Any())
                //            result.Bono = promociones.First().MontoText;
                //    }
                //    else
                //    {
                //        foreach (var item in Product.Items)
                //        {
                //            if (item.SkuCode == "CU_CU_TopUp" || item.SkuCode == "CU_NU_TopUp")
                //            {
                //                result = new Producto();
                //                result.Code = item.SkuCode;
                //                result.Image = "producto.png";
                //                result.Name = Provider.Items.First().Name;
                //                result.ProviderCode = Provider.Items.First().ProviderCode;
                //                result.CountryIso = Provider.Items.First().CountryIso;
                //                result.MinValue = item.Minimum.SendValue;
                //                result.MaxValue = item.Maximum.SendValue;
                //                result.CommissionRate = (float)item.CommissionRate;
                //                result.ValidationRegex = Provider.Items.First().ValidationRegex;
                //                result.DisplayText = item.DefaultDisplayText;
                //                if (promociones.Any())
                //                    result.Bono = promociones.First().MontoText;
                //                Listresult.Add(result);
                //            }
                //        }
                //        //return CreatedAtRoute("DefaultApi", null, Listresult);
                //    }
                //}

            }
            catch (Exception ex)
            {

                return CreatedAtRoute("DefaultApi", null, new { });
            }

            if (Listresult.Count == 0)
            {
                return CreatedAtRoute("DefaultApi", null, new { });
            }

            return CreatedAtRoute("DefaultApi", null, result);

        }

    }
}
