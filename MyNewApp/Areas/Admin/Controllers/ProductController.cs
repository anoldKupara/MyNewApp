using Microsoft.AspNetCore.Mvc;
using MyNewApp.DataAccess.IRepository;
using MyNewApp.Models.Models;

namespace MyNewApp.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll();
            return View(productList);
        }

        // GET - Edit
        public IActionResult Upsert(int? id)
        {
            Product product = new();
            if (id == null || id == 0)
            {
                //create product
                return View(product);
            }
            else
            {
                //update prduct
            }
            return View();
        }

        // POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                TempData["Success"] = "Product updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET - Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();
            TempData["Success"] = "Product deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
