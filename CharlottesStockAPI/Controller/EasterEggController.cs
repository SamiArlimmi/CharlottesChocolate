using ChocolateLibrary;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CharlottesStockAPI.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class EasterEggController : ControllerBase
    {
        private static List<EasterEgg> easterEggs = new List<EasterEgg>
        {
            new EasterEgg(1, "Lys Chocolate", 500, 15),
            new EasterEgg(2, "Mørk Chocolate", 700, 8),
            new EasterEgg(3, "Mørk Chocolate", 799, 20),
            new EasterEgg(4, "Mørk Chocolate", 999, 4),
            new EasterEgg(5, "Mørk Chocolate", 1200, 12),
            new EasterEgg(6, "Mørk Chocolate", 1400, 1),
            new EasterEgg(7, "Mørk Chocolate", 2000, 27),
        };

        // GET: api/EasterEgg
        [HttpGet]
        public ActionResult<IEnumerable<EasterEgg>> Get()
        {
            return Ok(easterEggs);
        }

        // GET: api/EasterEgg/1
        [HttpGet("{productNo}")]
        public ActionResult<EasterEgg> GetByProductNo(int productNo)
        {
            var easterEgg = easterEggs.Find(e => e.ProductNo == productNo);
            if (easterEgg == null)
            {
                return NotFound();
            }
            return Ok(easterEgg);
        }

        // GET: api/EasterEgg/stockLevelBelow/{minStockLevel}
        [HttpGet("stockLevelBelow/{minStockLevel}")]
        public ActionResult<IEnumerable<EasterEgg>> GetStockLevel(int minStockLevel)
        {
            var eggsBelowMinStockLevel = easterEggs.Where(e => e.InStock < minStockLevel).ToList();
            if (eggsBelowMinStockLevel.Count == 0)
            {
                return NotFound();
            }
            return Ok(eggsBelowMinStockLevel);
        }

        // PUT: api/EasterEgg/update
        [HttpPut("update")]
        public IActionResult UpdateEgg([FromBody] EasterEgg updatedEgg)
        {
            try
            {
                var existingEgg = easterEggs.Find(e => e.ProductNo == updatedEgg.ProductNo);
                if (existingEgg == null)
                {
                    return NotFound();
                }

                // Update properties
                existingEgg.ChocolateType = updatedEgg.ChocolateType;
                existingEgg.Price = updatedEgg.Price;
                existingEgg.InStock = updatedEgg.InStock;

                return Ok(existingEgg);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
