using Microsoft.AspNetCore.Mvc;
using MyNewApp.DbContexts;
using MyNewApp.Models;

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
            IEnumerable<Category> categoryList = _dbContext.Categories;
            return View(categoryList);
        }   

        // GET - Create
        public IActionResult Create()
        {
            return View();
        }

        //POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display Order cannot be the same");
            }

            if (category.Name == null)
            {
                ModelState.AddModelError("Name", "Name cannot be null");
            }

            if (category.Name.Length > 100)
            {
                ModelState.AddModelError("Name", "Name cannot be longer than 100 characters");
            }

            if (category.Name.Length < 3)
            {
                ModelState.AddModelError("Name", "Name cannot be shorter than 3 characters");
            }
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
