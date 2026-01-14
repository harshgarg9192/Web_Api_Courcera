using Microsoft.AspNetCore.Mvc;
using WebApi_Courcera.Models;

namespace WebApi_Courcera.Controllers
{
    [ApiController]
    [Route("API/[Controller]")]
    public class ShirtsController:ControllerBase
    {
        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok(ShirtStore.Shirts);
        }
        [HttpGet("{id}")]
        public IActionResult GetShirtByAnything(int id)
        {
            Shirt s=Shirt.GetShirtID(id);
            if (s == null) return NotFound();
            return Ok(s);
        }
        [HttpPut]
        public IActionResult AddShirt([FromBody] Shirt s)
        {
            ShirtStore.Shirts.Add(s);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult SellShirt(int id)
        {
            Shirt s =Shirt.GetShirtID(id);
            if (s == null) return NotFound();
            ShirtStore.Shirts.Remove(s);
            return Ok("shirt have sucessfully purchased");
        }
        [HttpPost]
        public IActionResult UpdateShirt([FromBody] Shirt? s)
        {
            if(s == null) return BadRequest();
            Shirt shirt = Shirt.GetShirtID(s.Id);
            ShirtStore.Shirts[shirt.Id] = shirt;
            return Ok("shirt have sucessfully updated");
        }

    }
}
