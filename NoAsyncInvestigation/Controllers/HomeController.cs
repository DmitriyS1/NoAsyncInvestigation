using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace NoAsyncInvestigation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbDataGenerator _dbDataGenerator;

        public HomeController(ApplicationDbContext dbContext)
            => _dbContext = dbContext;

        public IActionResult Index()
        {
            if (!_dbContext.Models.Any())
            {
                _dbDataGenerator.SetData();
            }

            return View();
        }
    }
}
