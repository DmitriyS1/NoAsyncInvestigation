using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        public IActionResult Index()
        {
            if (!_dbContext.Models.Any())
            {
                DbDataGenerator.SetData(_dbContext);
            }

            var count = _dbContext.Models.Count();

            return Ok(count);
        }

        [HttpGet("range")]
        public IActionResult Range([FromQuery] int start, [FromQuery] int end)
        {
            var models = _dbContext.Models.Where(m => m.Id >= start && m.Id < end).ToList();

            return Ok(models);
        }

        [HttpPost("update")]
        public IActionResult Update([FromQuery] int id, [FromQuery] int newPrice)
        {
            var model = _dbContext.Models.FirstOrDefault(m => m.Id == id);
            if (model is null)
            {
                return StatusCode(422, "Not found entity");
            }

            model.Price = newPrice;
            _dbContext.Models.Update(model);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
