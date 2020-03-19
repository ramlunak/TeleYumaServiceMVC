using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TeleYumaApp.Class;

namespace TeleYumaServiceMVC.Areas.Admin.Controllers
{
    public class AppContactsController : Controller
    {
        // GET: Admin/AppContacts
        public async Task<ActionResult> Index()
        {
           var emails = await AppContactList();
            return View(emails);
        }

        public async Task<ActionResult> Phone()
        {
            var emails = await AppContactListPhone();
            return View(emails);
        }

        public async Task<List<string>> AppContactList()
        {
            string url = @"https://mybilling.teleyuma.com/rest/Account/get_account_list/{""session_id"":""9a5d0bcc0236d542cccc6cf158840562""}/{""offset"":""1"",""limit"":""1000"",""i_customer"":""260271""}";
            List<account_info> accountList = new List<account_info>();
           List<string> emails = new List<string>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("apiKey", "a6V9NPooCNWzGaaEMsvPvQ==");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

                try
                {
                    var response = await client.GetAsync(url);
                    var result = await response.Content.ReadAsStringAsync();
                    accountList = JsonConvert.DeserializeObject<AccountObjectArray>(result).account_list.ToList();
                    ;
                }
                catch (Exception ex)
                {
                    ;
                }
            }

            foreach (var item in accountList)
            {
                emails.Add(item.email);
            }
            return emails;
        }

        public async Task<List<string>> AppContactListPhone()
        {
            string url = @"https://mybilling.teleyuma.com/rest/Account/get_account_list/{""session_id"":""9a5d0bcc0236d542cccc6cf158840562""}/{""offset"":""1"",""limit"":""1000"",""i_customer"":""260271""}";
            List<account_info> accountList = new List<account_info>();
            List<string> emails = new List<string>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("apiKey", "a6V9NPooCNWzGaaEMsvPvQ==");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

                try
                {
                    var response = await client.GetAsync(url);
                    var result = await response.Content.ReadAsStringAsync();
                    accountList = JsonConvert.DeserializeObject<AccountObjectArray>(result).account_list.ToList();
                    ;
                }
                catch (Exception ex)
                {
                    ;
                }
            }

            foreach (var item in accountList)
            {
                emails.Add(item.phone1);
            }
            return emails;
        }

        // GET: Admin/AppContacts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/AppContacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AppContacts/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AppContacts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/AppContacts/Edit/5
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

        // GET: Admin/AppContacts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/AppContacts/Delete/5
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
