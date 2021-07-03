using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace NoAsyncInvestigation.Controllers
{
    [ApiController]
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController(
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            if (!await _dbContext.Models.AnyAsync())
            {
                await DbDataGenerator.SetData(_dbContext);
            }

            var count = await _dbContext.Models.CountAsync();

            return Ok(count);
        }

        [HttpGet("range")]
        public async Task<IActionResult> Range([FromQuery] int start, [FromQuery] int end)
        {
            var models = await _dbContext
                .Models
                .Where(m => m.Id >= start && m.Id < end)
                .ToListAsync();

            return Ok(models);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromQuery] int newPrice)
        {
            var model = await _dbContext
                .Models
                .FirstOrDefaultAsync(m => m.Id == id);

            if (model is null)
            {
                return StatusCode(422, "Not found entity");
            }

            model.Price = newPrice;

            _dbContext.Models.Update(model);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
