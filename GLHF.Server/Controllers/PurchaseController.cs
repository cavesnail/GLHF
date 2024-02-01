using Microsoft.AspNetCore.Mvc;
using GLHF.Server.Models;
using System.Net;
using System.Text.Json;
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
        public IEnumerable<Purchase> GetAllPurchases()
        {
            Console.WriteLine("Got ALLpurchases request.");
            return _purchaseRepository.GetPurchases();
        }
        [HttpGet("getPurchase")]
        public ActionResult<Purchase> GetPurchase([FromQuery]long id)
        {
            Console.WriteLine("Got purchase request.");
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            if (_purchaseRepository.GetPurchase(id) != null)
            {
                return _purchaseRepository.GetPurchase(id);
            } else
            {
                return NotFound();
            }
        }
        [HttpGet("getPurchase2")]
        public ActionResult getPurchase2([FromQuery] long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (_purchaseRepository.GetPurchase(id) != null)
            {
                return new ContentResult() { Content = JsonSerializer.Serialize(_purchaseRepository.GetPurchase(id)), StatusCode = (int)HttpStatusCode.OK };
            }
            else
            {
                return NotFound();
            }
        }
    }
}
