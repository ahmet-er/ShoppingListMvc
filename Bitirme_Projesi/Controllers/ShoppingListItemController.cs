using Bitirme_Business.Interfaces;
using Bitirme_Model.Entities;
using Bitirme_Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace Bitirme_Projesi.Controllers
{
    public class ShoppingListItemController : Controller
    {
        private readonly IShoppingListBusiness _shoppingListBusiness;
        private readonly IProductBusiness _productBusiness;
        private readonly ICategoryBusiness _categoryBusiness;
        private readonly IShoppingListItemBusiness _shoppingListItemBusiness;
        public ShoppingListItemController(IShoppingListBusiness shoppingListBusiness, IProductBusiness productBusiness, ICategoryBusiness categoryBusiness, IShoppingListItemBusiness shoppingListItemBusiness)
        {
            _shoppingListBusiness = shoppingListBusiness;
            _productBusiness = productBusiness;
            _categoryBusiness = categoryBusiness;
            _shoppingListItemBusiness = shoppingListItemBusiness;

        }
        public IActionResult List(int id, int page = 1, string search = "", int? category = null)
        {
            ViewData["Title"] = "Liste'ye Ürün Ekle";

            int pageProductSize = 8;
            var shoppingList = _shoppingListBusiness.GetShoppingListById(id);
            if (shoppingList == null)
            {
                return NotFound();
            }

            var products = _productBusiness.GetAllProducts();
            var categories = _categoryBusiness.GetAllCategories();
            var categoriesToDic = categories.ToDictionary(c => c.CategoryID, c => c.Name);


            // Search 
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            // Category filtre
            if (category.HasValue && category > 0)
            {
                products = products.Where(p => p.CategoryID == category).ToList();
            }

            var productViewModels = products.Select(p => new ShoppingListProductViewModel
            {
                ProductId = p.ProductID,
                Name = p.Name,
                Price = p.Price,
                ImageFilePath = p.ImageFilePath,
                CategoryId = p.CategoryID,
                CategoryName = categoriesToDic.ContainsKey(p.CategoryID) ? categoriesToDic[p.CategoryID] : "N/A",
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.CategoryID.ToString(),
                    Text = c.Name
                }).ToList()
            }).ToPagedList(page, pageProductSize);

            return View(productViewModels);
        }


        [HttpPost]
        public IActionResult AddToList([FromBody] ShoppingListItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                ShoppingListItem newItem = new ShoppingListItem
                {
                    ShoppingListId = model.ShoppingListId,
                    ProductId = model.ProductId,
                    Amount = model.Amount
                };

                try
                {
                    _shoppingListItemBusiness.AddShoppingListItem(newItem);
                    return Json(new { success = true, message = "Ürün başarıyla listenize eklendi." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = true, message = "Hata oluştu: " + ex.Message });
                }
            }
            var errorMessages = ModelState.Values.SelectMany(a => a.Errors.Select(e => e.ErrorMessage));
            return Json(new { success = false, message = "Hata oluştu: " + string.Join(" | ", errorMessages) });
        }

        [HttpGet]
        public IActionResult EditShoppingListItem(int shoppingListId, int productId)
        {
            var shoppingListItem = _shoppingListItemBusiness.GetShoppingListItemByShoppingListIdAndProductId(shoppingListId, productId);
            var shoppingList = _shoppingListBusiness.GetShoppingListById(shoppingListId);
            var product = _productBusiness.GetProductWithCategory(productId);

            if (shoppingListItem == null)
            {
                return NotFound();
            }

            var viewModel = new ShoppingListItemViewModel
            {
                ShoppingListId = shoppingListId,
                ProductId = shoppingListItem.ProductId,
                ProductName = shoppingListItem.Product.Name,
                ImageFilePath = shoppingListItem.Product.ImageFilePath,
                Amount = shoppingListItem.Amount,
                Description = shoppingListItem.Description,
                Aldimi = false
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditShoppingListItem(ShoppingListItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var shoppingListItem = _shoppingListItemBusiness.GetShoppingListItemByShoppingListIdAndProductId(model.ShoppingListId, model.ProductId);

                if (shoppingListItem != null)
                {
                    shoppingListItem.Amount = model.Amount;
                    shoppingListItem.Description = model.Description;

                    _shoppingListItemBusiness.UpdateShoppingListItem(shoppingListItem);

                    return RedirectToAction("ListItem", "ShoppingList", new { id = model.ShoppingListId });
                }
                else
                {
                    ModelState.AddModelError("NotFound", "Belirtilen ürün bulunamadı.");
                }
            }
            return View(model);
        }

        public IActionResult DeleteShoppingListItem(int shoppingListId, int productId)
        {
            var shoppingListItem = _shoppingListItemBusiness.GetShoppingListItemByShoppingListIdAndProductId(shoppingListId, productId);

            if (shoppingListItem != null)
            {
                _shoppingListItemBusiness.DeleteShoppingListItem(shoppingListItem);

                return RedirectToAction("ListItem", "ShoppingList", new { id = shoppingListId });
            }
            else
            {
                return NotFound("Seçili ürün bulunamadı.");
            }
        }
    }
}
