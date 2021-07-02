using Microsoft.AspNetCore.Mvc;

namespace NoAsyncInvestigation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext)
            => _dbContext = dbContext;

        public IActionResult Index()
        {
            var db = _dbContext.Database;

            return View();
        }
    }
}
