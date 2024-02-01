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

        [HttpGet("getAllPurchases")]
        public IEnumerable<Purchase> GetAllPurchases()
        {
            return _purchaseRepository.GetPurchases();
        }
        [HttpGet("getPurchase")]
        public ActionResult<Purchase> GetPurchase([FromQuery]long id)
        {
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
    }
}
