using Bitirme_Business.Interfaces;
using Bitirme_Model.Entities;
using Bitirme_Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public IActionResult List(int id)
        {
            var shoppingList = _shoppingListBusiness.GetShoppingListById(id);
            if (shoppingList == null)
            {
                return NotFound();
            }

            var products = _productBusiness.GetAllProducts();
            var categories = _categoryBusiness.GetAllCategories();
            var categoriesToDic = categories.ToDictionary(c => c.CategoryID, c => c.Name);
            

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
            }).ToList();

            //ViewBag.Categories = new SelectList(categories.ToList(), "CategoryId", "CategoryName");

            return View(productViewModels);
        }
        [HttpPost]
        public IActionResult AddToList([FromBody] ShoppingListItemViewModel model)
        {
            if(ModelState.IsValid)
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
    }
}
