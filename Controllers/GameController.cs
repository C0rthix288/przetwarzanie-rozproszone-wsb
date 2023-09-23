using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Models;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        private readonly AppDbContextGame db;

        public GameController(AppDbContextGame db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetNumbers()
        {
            var result = await db.Numbers.ToListAsync();

            if(result.Count == 0)
            {
                return StatusCode(StatusCodes.Status204NoContent, "no values in db");
            }

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost]
        public async Task<ActionResult<NumberModel>> AddNumber(NumberModel number)
        {
            try
            {
                await db.Numbers.AddAsync(number);
                await db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, "add number success");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.ToString());
            }
        }

        [HttpPut("id")]
        public async Task<ActionResult> UpdateNumber(NumberModel number)
        {
            try
            {
                db.Entry(number).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, "update number success");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.ToString());
            }
        }


    }
}
