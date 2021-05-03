using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frontend.Abstract;
using Frontend.Helpers;
using Frontend.Models;
using Frontend.Views.Models;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Models
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

        public Cart AddItem(Equipment toAdd, int numOfDays)
        {
            if (numOfDays <= 0)
            {
                numOfDays = 1;
            }
            CartItem cartItem = items.
                Where(item => item.equipment.id == toAdd.id).
                FirstOrDefault();
            if (cartItem == null)
            {
                items.Add(new CartItem { 
                    equipment = toAdd,
                    days = numOfDays
                });
            } else
            {
                cartItem.days = numOfDays;
            }
            return this;
        }

        public void RemoveItem(int id)
        {
            items.RemoveAll(item => item.equipment.id == id);
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
