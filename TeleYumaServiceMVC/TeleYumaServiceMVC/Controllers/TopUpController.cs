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
    public class TopUpController : ApiController
    {

        // POST: api/TopUp
        public async Task<IHttpActionResult> Post([FromBody]Teleyuma.Teleyuma.TopUpRequest topUpRequest)
        {

            if (Autorize.TeleyumaLogin(this.Request.Headers).ErrorCode > 0)
                return CreatedAtRoute("DefaultApi", null, Autorize.TeleyumaLogin(this.Request.Headers));

            //Transformar datos         

            var DingRequest = new Ding.SendTransferRequest();
            DingRequest.SkuCode = topUpRequest.SkuCode;
            DingRequest.AccountNumber = topUpRequest.AccountNumber;
            DingRequest.SendValue = topUpRequest.SendValue;
            DingRequest.DistributorRef = topUpRequest.DistributorRef;
            DingRequest.ValidateOnly = topUpRequest.ValidateOnly;

            var result = await Ding.SendTransfer(DingRequest);
            return CreatedAtRoute("DefaultApi", null, result);
        }

         
        public async Task<IHttpActionResult> Get(string id)
        {
            var result = await Ding.GetProductsByaccountNumber(id);
            return CreatedAtRoute("DefaultApi", null, result);
        }

    }
}
