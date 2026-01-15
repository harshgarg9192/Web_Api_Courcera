using Microsoft.AspNetCore.Mvc;
using WebApi_Courcera.Models;

namespace WebApi_Courcera.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        // GET: api/shirts
        [HttpGet]
        public ActionResult<IEnumerable<Shirt>> GetShirts()
        {
            return Ok(ShirtStore.Shirts);
        }

        // GET: api/shirts/5
        [HttpGet("{id:int}")]
        public ActionResult<Shirt> GetShirtById(int id)
        {
            var shirt = Shirt.GetShirtID(id);
            if (shirt == null)
                return NotFound($"Shirt with id {id} not found");

            return Ok(shirt);
        }

        // POST: api/shirts
        [HttpPost]
        public ActionResult AddShirt([FromBody] Shirt shirt)
        {
            if (shirt == null)
                return BadRequest("Shirt data is required");

            ShirtStore.Shirts.Add(shirt);
            return CreatedAtAction(nameof(GetShirtById), new { id = shirt.Id }, shirt);
        }

        // PUT: api/shirts/5
        [HttpPut("{id:int}")]
        public ActionResult UpdateShirt(int id, [FromBody] Shirt shirt)
        {
            if (shirt == null || id != shirt.Id)
                return BadRequest("Invalid shirt data");

            var existingShirt = Shirt.GetShirtID(id);
            if (existingShirt == null)
                return NotFound($"Shirt with id {id} not found");

            existingShirt.Name = shirt.Name;
            existingShirt.Color = shirt.Color;
            existingShirt.Price = shirt.Price;
            existingShirt.Gender = shirt.Gender;

            return Ok("Shirt updated successfully");
        }

        // DELETE: api/shirts/5
        [HttpDelete("{id:int}")]
        public ActionResult DeleteShirt(int id)
        {
            var shirt = Shirt.GetShirtID(id);
            if (shirt == null)
                return NotFound($"Shirt with id {id} not found");

            ShirtStore.Shirts.Remove(shirt);
            return Ok("Shirt purchased successfully");
        }
    }
}
