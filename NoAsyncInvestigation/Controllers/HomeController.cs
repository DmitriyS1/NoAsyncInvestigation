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
    }
}
