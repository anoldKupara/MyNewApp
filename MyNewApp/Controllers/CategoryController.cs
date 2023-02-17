using Microsoft.AspNetCore.Mvc;
using MyNewApp.DataAccess.IRepository;
using MyNewApp.Models;
using MyNewApp.Models.Models;

namespace MyNewApp.Controllers
{
    public class CategoryController : Controller
    {
        //private readonly ICategoryRepository _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            //_dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _unitOfWork.Category.GetAll();
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
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["Success"] = "Category added successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }


        // GET - Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
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
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET - Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
