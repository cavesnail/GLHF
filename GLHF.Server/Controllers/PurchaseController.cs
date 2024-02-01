using Microsoft.AspNetCore.Mvc;
using GLHF.Server.Models;
namespace GLHF.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {

        readonly PurchaseRepository _purchaseRepository = new();

        [HttpGet("test")]
        public string GetString()
        {
            return "testString";
        }
        [HttpGet("GetPurchases")]
        public IEnumerable<Purchase> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Purchase
            {
                UnitPrice = 0,
                Quantity = 0,
                Name = "wassup"
            })
            .ToArray();
        }
        [HttpGet("getAllPurchases")]
        public IEnumerable<Purchase> GetAllPurchases()
        {
            return _purchaseRepository.GetPurchases();
        }
        [HttpGet("getPurchase{id}")]
        public ActionResult<Purchase> GetPurchase(long id)
        {
            if (_purchaseRepository.GetPurchase(id) != null)
            {
                return _purchaseRepository.GetPurchase(id);
            } else
            {
                return NotFound();
            }
            
        }
    }
}
