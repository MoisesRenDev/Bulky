using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Product> products = _unitOfWork.Product.GetProductsWithCategories()
                .ToList();

            return View(products);
        }

        public IActionResult Create()
        {
            ProductVM productVM = new()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.Category
                    .GetAll().Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString(),
                    })
            };

            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(product);
                TempData["success"] = $"{product.Title} agregado éxitosamente";
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public IActionResult Edit(int id)
        {
            Product product = _unitOfWork.Product.Get(x => x.Id == id);

            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category
                    .GetAll().Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString(),
                    });

            ViewBag.CategoryList = CategoryList;

            if (product != null) return View(product);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(product);
                TempData["success"] = $"{product.Title} actualizado éxitosamente";
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}
