using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSales.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> shoppingCarts { set; get; }
        public ShoppingCart()
        {
            shoppingCarts = new List<ShoppingCartItem>();
        }
        public void Add(ShoppingCartItem shoppingCartItem, int Quantity)
        {
            var exitingItem = shoppingCarts.FirstOrDefault(x => x.ProductId == shoppingCartItem.ProductId);
            if (exitingItem != null)
            {
                exitingItem.Quantity = Quantity;
                exitingItem.TotalAmount = exitingItem.Price * Quantity;
            }
            else
            {
                shoppingCartItem.Quantity = Quantity;
                shoppingCarts.Add(shoppingCartItem);
            }
        }
        public void Remove(int ProductId)
        {
            var exitingItem = shoppingCarts.FirstOrDefault(x => x.ProductId == ProductId);
            shoppingCarts.Remove(exitingItem);
        }
        public void Update(int ProductId, int Quantity)
        {
            var exitingItem = shoppingCarts.FirstOrDefault(x => x.ProductId == ProductId);
            if (exitingItem != null)
            {
                exitingItem.Quantity = Quantity;
                exitingItem.TotalAmount = exitingItem.Price * Quantity;
            }
        }
        public decimal GetTotalAmount()
        {
            return shoppingCarts.Sum(x => x.TotalAmount);
        }
        public decimal GetTotalQuantity()
        {
            return shoppingCarts.Sum(x => x.Quantity);
        }
        public void Clear()
        {
            shoppingCarts.Clear();
        }

    }

    public class ShoppingCartItem
    {
        public int ProductId { set; get; }
        public string ProductName { set; get; }
        public string ProductImage { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public decimal PriceSale { set; get; }
        public decimal TotalAmount { set; get; }
    }
}