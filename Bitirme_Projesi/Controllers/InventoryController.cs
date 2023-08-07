using Bitirme_Business.Interfaces;
using Bitirme_Model.Entities;
using Bitirme_Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace Bitirme_Projesi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InventoryController : Controller
    {
        private readonly ICategoryBusiness _categoryBusiness;
        private readonly IProductBusiness _productBusiness;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InventoryController(ICategoryBusiness categoryBusiness, IProductBusiness productBusiness, IWebHostEnvironment webHostEnvironment)
        {
            _categoryBusiness = categoryBusiness;
            _productBusiness = productBusiness;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(int? pageCategories, int? pageProducts)
        {
            int pageCategorySize = 10;
            int pageProductSize = 4;

            ViewData["Title"] = "Envanter Yönetimi";

            var categories = _categoryBusiness.GetAllCategories();
            var products = _productBusiness.GetAllProducts();



            var pagedCategories = categories.ToPagedList(pageCategories ?? 1, pageCategorySize);
            var pagedProducts = products.ToPagedList(pageProducts ?? 1, pageProductSize);

            var inventoryViewModel = new InventoryViewModel
            {
                Categories = pagedCategories,
                Products = pagedProducts
            };

            return View(inventoryViewModel);
        }
        #region CATEGORY
        public IActionResult AddCategory()
        {
            ViewData["Title"] = "Kategori Ekle";
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                string categoryName = categoryViewModel.Name.Trim();

                if (_categoryBusiness.CategoryExists(categoryName))
                {
                    ModelState.AddModelError("Name", "Bu kategori adını zaten girdiniz");
                    return View(categoryViewModel);
                }
                var category = new Category
                {
                    Name = categoryViewModel.Name
                };

                _categoryBusiness.AddCategory(category);

                return RedirectToAction(nameof(Index));
            }
            return View(categoryViewModel);
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = _categoryBusiness.GetCategoryById(id);
            ViewData["Title"] = category.Name + " Güncelle";
            if (category == null)
            {
                return NotFound();
            }

            var categoryViewModel = new CategoryViewModel
            {
                Id = id,
                Name = category.Name
            };

            return View(categoryViewModel);
        }
        [HttpPost]
        public IActionResult UpdateCategory(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = _categoryBusiness.GetCategoryById(categoryViewModel.Id);
                if (category == null)
                {
                    return NotFound();
                }
                category.Name = categoryViewModel.Name;

                _categoryBusiness.UpdateCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View("UpdateCategory", categoryViewModel);
        }
        public IActionResult DeleteCategory(int id)
        {
            _categoryBusiness.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region PRODUCT
        public IActionResult AddProduct()
        {
            ViewData["Title"] = "Ürün Ekle";
            var categories = _categoryBusiness.GetAllCategories();
            var viewModel = new ProductViewModel
            {
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.CategoryID.ToString(),
                    Text = c.Name
                }).ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddProduct(ProductViewModel productViewModel, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string productName = productViewModel.Name.Trim();

                // ad kontrolü
                if (_productBusiness.ProductExists(productName))
                {
                    ModelState.AddModelError("Name", "Bu ürünü zaten eklediniz.");
                    return View(productViewModel);
                }

                // dosya yükleme
                if (file != null && file.Length > 0)
                {
                    var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                    var filePath = Path.Combine(uploads, file.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productViewModel.ImageFilePath = "/img/" + file.FileName;
                }


                // çalışan kod
                var product = new Product
                {
                    Name = productViewModel.Name,
                    Price = productViewModel.Price,
                    ImageFilePath = productViewModel.ImageFilePath,
                    CategoryID = productViewModel.CategoryId
                };

                _productBusiness.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var errors = ModelState.Values.SelectMany(e => e.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            var categories = _categoryBusiness.GetAllCategories();
            productViewModel.Categories = new SelectList(categories, "Id", "Name");
            return View(productViewModel);
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var categories = _categoryBusiness.GetAllCategories();
            var product = _productBusiness.GetProductWithCategory(id);
            ViewData["Title"] = product.Name + " Güncelle";
            var productViewModel = new ProductViewModel
            {
                Id = product.ProductID,
                Name = product.Name,
                Price = product.Price,
                ImageFilePath = product.ImageFilePath,
                CategoryId = product.CategoryID,
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.CategoryID.ToString(),
                    Text = c.Name
                }).ToList()
            };
            return View(productViewModel);
        }
        [HttpPost]
        public IActionResult UpdateProduct(ProductViewModel productViewModel, IFormFile file)
        {
            var product = _productBusiness.GetProductWithCategory(productViewModel.Id);

            // resim güncelleme
            if (file != null && file.Length > 0)
            {
                // Eski resmi silme
                if (!string.IsNullOrEmpty(product.ImageFilePath))
                {
                    var oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, product.ImageFilePath.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                // yeni resmi yükleme
                var upload = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var newFilePath = Path.Combine(upload, newFileName);
                using (var fileStream = new FileStream(newFilePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                productViewModel.ImageFilePath = "/img/" + newFileName;
            }
            else
            {
                productViewModel.ImageFilePath = product.ImageFilePath;
            }


            // çalışan
            if (product != null)
            {
                product.Name = productViewModel.Name;
                product.Price = productViewModel.Price;
                product.ImageFilePath = productViewModel.ImageFilePath;
                product.CategoryID = productViewModel.CategoryId;

                _productBusiness.UpdateProduct(product);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Ürün bulunamadı");
            }
            //}

            var categories = _categoryBusiness.GetAllCategories();
            productViewModel.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.CategoryID.ToString(),
                Text = c.Name
            }).ToList();
            return View(productViewModel);
        }
        public IActionResult DeleteProduct(int id)
        {
            _productBusiness.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
