using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Model.ViewModels
{
    public class ShoppingListViewModel
    {
        public int ShoppingListID { get; set; }
        public string Name { get; set; }
        public bool GoShopping { get; set; }
        public List<ShoppingListItemViewModel>? ShoppingListItems { get; set; }
    }
}
