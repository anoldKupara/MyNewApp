using Microsoft.AspNetCore.Mvc;
using MyNewApp.DbContexts;

namespace MyNewApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var categoryList = _dbContext.Categories.ToList();
            return View();
        }
    }
}
