using Microsoft.AspNetCore.Mvc;
using MyNewApp.DataAccess.IRepository;
using MyNewApp.Models.Models;

namespace MyNewApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<CoverType> objList = _unitOfWork.CoverType.GetAll();
            return View(objList);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType coverType)
        {          
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(coverType);
                _unitOfWork.Save();
                TempData["Success"] = "Cover Type saved successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(coverType);
        }

        // GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var coverType = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }

        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(coverType);
                _unitOfWork.Save();
                TempData["Success"] = "Cover Type updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(coverType);
        }

    }
}
