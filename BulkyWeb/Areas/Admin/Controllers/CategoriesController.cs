using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using BulkyWeb.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Category> categories = _unitOfWork.Category.GetAll()
                .OrderBy(x => x.DisplayOrder)
                .ToList();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                TempData["success"] = $"{category.Name} creado exitosamente";
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public IActionResult Edit(int id)
        {
            Category category = _unitOfWork.Category.Get(x => x.Id == id);
            if (category != null) return View(category);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                category.Updated = DateTime.Now;
                _unitOfWork.Category.Update(category);
                TempData["success"] = $"{category.Name} editado exitosamente";
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public IActionResult Delete(int id)
        {
            Category category = _unitOfWork.Category.Get(x => x.Id == id);

            if (category != null) return View(category);

            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            Category category = _unitOfWork.Category.Get(x => x.Id == id);
            if (category != null)
            {
                TempData["success"] = $"{category.Name} eliminado exitosamente";
                _unitOfWork.Category.Remove(category);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(category);
        }
    }
}
