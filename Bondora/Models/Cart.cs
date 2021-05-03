using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bondora.Models
{
    public class CartItem
    {
        public Equipment equipment { get; set; }
        public int days { get; set; }
    }
    public class Cart
    {
        private List<CartItem> items;
        public Cart()
        {
            items = new List<CartItem>();
        }
        public Cart(List<CartItem> cartItems)
        {
            items = cartItems;
        }
        public void setCartItems(List<CartItem> cartItems)
        {
            this.items = cartItems;
        }
        public void Clear()
        {
            items.Clear();
        }
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public List<CartItem> getCartItems()
        {
            return items;
        }
    }
}
