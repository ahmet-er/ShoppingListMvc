using Bitirme_Business.Interfaces;
using Bitirme_Model.Entities;
using Bitirme_Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Security.Claims;
using X.PagedList;

namespace Bitirme_Projesi.Controllers
{
    public class ShoppingListController : Controller
    {
        private readonly IShoppingListBusiness _shoppingListBusiness;
        private readonly IShoppingListItemBusiness _shoppingListItemBusiness;
        private readonly IProductBusiness _productBusiness;

        public ShoppingListController(IShoppingListBusiness shoppingListBusiness, IShoppingListItemBusiness shoppingListItemBusiness, IProductBusiness productBusiness)
        {
            _shoppingListBusiness = shoppingListBusiness;
            _shoppingListItemBusiness = shoppingListItemBusiness;
            _productBusiness = productBusiness;
        }
        public IActionResult Index(int page = 1)
        {
            ViewData["Title"] = "Listeler";
            int pageListSize = 3;

            var currentUser = HttpContext.User;
            var userIdClaim = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if(userIdClaim != null)
            {
                var userId = userIdClaim.Value;

                var shoppingLists = _shoppingListBusiness.GetShoppingListsByUserId(userId);

                var pagedShoppingList = shoppingLists.ToPagedList(page, pageListSize);

                return View(pagedShoppingList);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateList()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateList(ShoppingListViewModel shoppingListViewModel)
        {
            if(ModelState.IsValid)
            {
                var currentUser = HttpContext.User;

                var userIdClaim = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    var userId = userIdClaim.Value;

                    var shoppingList = new ShoppingList
                    {
                        ShoppingListID = shoppingListViewModel.ShoppingListID,
                        Name = shoppingListViewModel.Name,
                        UserID = userId
                    };

                    _shoppingListBusiness.AddShoppingList(shoppingList);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(shoppingListViewModel);
        }
        [HttpGet]
        public IActionResult EditList(int id)
        {
            var shoppingList = _shoppingListBusiness.GetShoppingListById(id);
            if(shoppingList == null)
            {
                return NotFound();
            }

            var shoppingListViewModel = new ShoppingListViewModel
            {
                ShoppingListID = id,
                Name = shoppingList.Name
            };
            return View(shoppingListViewModel);
        }
        [HttpPost]
        public IActionResult EditList(ShoppingListViewModel shoppingListViewModel)
        {
            if(ModelState.IsValid)
            {
                var shoppingList = _shoppingListBusiness.GetShoppingListById(shoppingListViewModel.ShoppingListID);
                if(shoppingList == null)
                {
                    return NotFound();
                }   
                shoppingList.Name = shoppingListViewModel.Name;

                _shoppingListBusiness.UpdateShoppingList(shoppingList);
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingListViewModel);
        }
        public IActionResult DeleteList(int id)
        {
            _shoppingListBusiness.DeleteShoppingList(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ListItem(int id)
        {
            var shoppingList = _shoppingListBusiness.GetShoppingListById(id);
            ViewData["Title"] = shoppingList.Name;
            var shoppingListItems = _shoppingListItemBusiness.GetItemsByShoppingListId(id);

            foreach(var shoppingListItem in shoppingListItems)
            {
                shoppingListItem.Product = _productBusiness.GetProductWithCategory(shoppingListItem.ProductId);
            }

            if (shoppingListItems == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var shoppingListViewModel = new ShoppingListViewModel
            {
                ShoppingListID = shoppingList.ShoppingListID,
                Name = shoppingList.Name,
                GoShopping = shoppingList.AlisveriseCikildiMi,
                ShoppingListItems = shoppingListItems.Select(sli => new ShoppingListItemViewModel
                {
                    ShoppingListId = sli.ShoppingListId,
                    ProductId = sli.ProductId,
                    ProductName = sli.Product.Name,
                    Description = sli.Description,
                    ImageFilePath = sli.Product.ImageFilePath,
                    Aldimi = sli.Aldimi,
                    Amount = sli.Amount
                }).ToList()
            };
            return View(shoppingListViewModel);
        }

        [HttpPost]
        public IActionResult GoShopping(int shoppingListId)
        { 
            var shoppingList = _shoppingListBusiness.GetShoppingListById(shoppingListId);

            if (shoppingList != null)
            {
                shoppingList.AlisveriseCikildiMi = true;
                _shoppingListBusiness.UpdateShoppingList(shoppingList);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult ShoppingDone(int shoppingListId, List<int> selectedProductIds)
        {
            var shoppingList = _shoppingListBusiness.GetShoppingListById(shoppingListId);

            if (shoppingList != null)
            {
                shoppingList.AlisveriseCikildiMi = false;
                _shoppingListBusiness.UpdateShoppingList(shoppingList);

                if (selectedProductIds.Count != 0)
                {
                    foreach (var item in selectedProductIds)
                    {
                        var shoppingListItem = _shoppingListItemBusiness.GetShoppingListItemByShoppingListIdAndProductId(shoppingListId, item);

                        if (shoppingListItem != null)
                        {
                            _shoppingListItemBusiness.DeleteShoppingListItem(shoppingListItem);
                        }
                        else
                        {
                            return NotFound("Seçili ürün bulunamadı.");
                        }
                    }
                }

                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
