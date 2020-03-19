using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TeleYumaServiceMVC.Areas.Admin.Models;

namespace TeleYumaServiceMVC.Areas.Admin.Controllers
{
    public class AdminHomeController : BaseController
    {
        // GET: Admin/AdminHome
        public async Task<ActionResult> Index()
        {
            var model = await _Global.GetDistributors();
            return View(model);
        }

        public async Task<ActionResult> Facturacion(string id)
        {
            var customer = await _Global.GetcustomerById(id);

            var utc_from = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Parse(_Global.FromDate), "US Eastern Standard Time", "UTC").ToString("yyyy-MM-dd HH:mm:ss");
            var utc_to = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Parse(_Global.ToDate), "US Eastern Standard Time", "UTC").ToString("yyyy-MM-dd HH:mm:ss");

            var facturacion = new Facturacion();

            Session["FacturacionFromDate"] = _Global.FromDate;
            Session["FacturacionToDate"] = _Global.ToDate;

            facturacion.XDRListResponse = await customer.GetCustomerXDR(new GetRetailCustomerXDRListRequest { from_date = utc_from, to_date = utc_to });
            await facturacion.Cargar(customer);
                       
            return View(facturacion);
        }

        // GET: Admin/AdminHome/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/AdminHome/Create
        public ActionResult Create()
        {
            Session["TipoTienda"] = TipoTienda.Padre;
            return View(new customer_info());
        }

        [HttpPost]
        public async Task<ActionResult> Create(customer_info account)
        {           
            //if (!IsLogin()) return RedirectToAction("Index", "Login");
            //else
            //{
            if (ModelState.IsValid)
            {
                //validar impuesto..................................
                Session["CurrentCustomer"] = account;
                if (account.impuesto < IMPUESTO)
                {
                    account.ErrorHandlingCrearCuenta.faul = true;
                    account.ErrorHandlingCrearCuenta.faultstring = "El impuesto de la tienda tiene que ser mayor o igual que su impuesto(" + IMPUESTO + "%)";
                    return View(account);
                }

                //validar fondos disponibles

                //var fondos = await FONDOS();
                //if (account.LimiteCredito > fondos)
                //{
                //    account.ErrorHandlingCrearCuenta.faul = true;
                //    account.ErrorHandlingCrearCuenta.faultstring = "El credito que desea asignar es mayor que su fondo.";
                //    return View(account);
                //}

                account.note = ":DISTRIB: 2:2:" + account.impuesto + ":";

                ////CALCULAR DIFERENCIA DE SALDO

                //var porcionDistrubuidor = account.LimiteCredito;
                //var comisionDistribuidor = IMPUESTO;

                //var TotalSegunComision = (float)_Global.ReglaDeTres(comisionDistribuidor,0,porcionDistrubuidor);

                //var DineroFicticio = (float)_Global.ReglaDeTres(account.impuesto, TotalSegunComision, 0);
                //account.credit_limit = DineroFicticio;

                // //----------------------------

                account.credit_limit = account.LimiteCredito;
                var resul = await SetAccount(account);
                if (!resul.faul)
                {
                    //((customer_info)Session["CurrentCustomer"]).credit_limit -= account.LimiteCredito;
                    //await ((customer_info)Session["CurrentCustomer"]).Actualizar();
                    //Session["CurrentCustomer"] = await ((customer_info)Session["CurrentCustomer"]).Reload();
                    ShowSuccess(resul.faultstring);
                    await FONDOS();
                    return RedirectToAction("Index");
                }
                else
                {
                    account.ErrorHandlingCrearCuenta = resul;
                    await FONDOS();

                    return View(account);
                }

            }
            else
            {
                return View(account);
            }
            //}
        }


        public async Task<ErrorHandling> SetAccount(customer_info account)
        {

            try
            {
                var now = DateTime.Now;

                var YY = now;
                var MM = now.Month.ToString();
                var DD = now.Day.ToString();

                if (MM.Length == 1)
                    MM = "0" + MM;
                if (DD.Length == 1)
                    DD = "0" + DD;

                var activationDate = now.Year + "-" + MM + "-" + DD;
                account.ComisionDelPadre = IMPUESTO;
                //id de la cuenta       
                account.opening_balance = 0;
                account.iso_4217 = "USD";
                account.i_distributor = await ID_DISTRIBUIDOR();
                account.i_customer_type = 3;  //Online customers 
                account.batch_name = ID_CUENTA + "-di-pinless";
                account.billing_model = 1;
                account.payment_commission_rate = 100;
                account.sale_commission_rate = 100;
                account.i_time_zone = 109;
                account.i_ui_time_zone = 109;
                account.control_number = 1;
                account.h323_password = account.password;
               // account.i_product = 22791;
                account.activation_date = activationDate.Trim();
                account.phone1 = account.phone1;
                account.firstname = account.firstname;
                account.name = account.fullname;
                account.lastname = account.lastname;
                account.email = account.email;
                account.login = account.phone1;
                account.password = account.password;
                account.note = account.note;

            }
            catch (Exception ex)
            {
                ;
            }

            var valid = await account.Validar();
            if (!valid.faul)
            {

                var result = await account.Crear();
                return result;
            }
            else
                return valid;

        }

        // GET: Admin/AdminHome/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/AdminHome/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminHome/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/AdminHome/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
