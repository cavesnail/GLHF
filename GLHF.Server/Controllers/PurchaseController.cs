using Microsoft.AspNetCore.Mvc;
using GLHF.Server.Models;
using System.Net;
using System.Text.Json;
using System.Runtime.Serialization;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Nodes;
namespace GLHF.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {

        public readonly PurchaseRepository _purchaseRepository = new();

        [HttpGet("test")]
        public string GetString()
        {
            return "testString";
        }

        [HttpGet("getAllPurchases")]
        public IEnumerable<PurchaseSimple> GetAllPurchases()
        {
            Console.WriteLine("Got ALLpurchases request.");
            //have list, need to recreate list but w/ PurchaseSimples
            IEnumerable<Purchase> purchases = _purchaseRepository.GetPurchases();
            List<PurchaseSimple> newPurchases = new();
            foreach (Purchase purchase in purchases)
            {
                PurchaseSimple currentPurchase = new();
                currentPurchase.GenerateFromPurchase(purchase);
                newPurchases.Add(currentPurchase);
            }
            return newPurchases;
        }
        [HttpGet("getAllPurchasesTrimmed")]
        public IEnumerable<JsonObject> GetAllTrimmed()
        {
            Console.WriteLine("Running trimmed purchase.");
            IEnumerable<Purchase> purchases = _purchaseRepository.GetPurchases();
            List<JsonObject> newPurchases = new();
            foreach (Purchase purchase in purchases)
            {

                //get total price and later add it to json object. ah, json my beloved - so mutable
                decimal totalPrice = purchase.UnitPrice * purchase.Quantity;


                string serialised = JsonSerializer.Serialize<Purchase>(purchase);
                //JSObject des = JsonSerializer.Deserialize<JSObject>(serialised);
                JsonObject des = JsonSerializer.Deserialize<JsonObject>(serialised);
                des.Remove("Quantity");
                des.Remove("UnitPrice");
                des.Remove("Description");
                des.Add("TotalCost", totalPrice);
                newPurchases.Add(des);
            }
            return newPurchases;
        }
        [HttpGet("getPurchase")]
        public ActionResult<JsonObject> GetPurchase([FromQuery]long id)
        {
            Console.WriteLine("Got purchase request.");
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            if (_purchaseRepository.GetPurchase(id) != null)
            {
                Console.WriteLine("Returning single purchase.");
                Purchase purchase = _purchaseRepository.GetPurchase(id);
                decimal totalPrice = purchase.UnitPrice * purchase.Quantity;
                string serialised = JsonSerializer.Serialize<Purchase>(purchase);
                JsonObject des = JsonSerializer.Deserialize<JsonObject>(serialised);
                des.Remove("Id");
                des.Add("TotalCost", totalPrice);
                return des;
            } else
            {
                return NotFound();
            }
        }

        //SUMMARY STATISTICS

        /*
         Need the following summaries:
        - time series of spend per month
        - most expensive month
        - month with most units bought
        - product name related to the most expensive purchase
        - product name with most units bought
         */
        [HttpGet("timeSeries")]
        public ActionResult getTimeSeries()
        {
            return BadRequest();
        }
    }
}
