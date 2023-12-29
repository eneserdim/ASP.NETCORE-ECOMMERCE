using EEducation.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using EEducation.Model.Entities;
using Newtonsoft.Json;


namespace EEducation.WebUI.ViewComponents
{
    public class ShopCart : ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
            decimal total = 0;
            foreach (var item in GetCartItems())
            {
                total += item.Price * item.Quantity;
            }

            var cart = new ShoppingCart()
            {
                CartItems = GetCartItems(),
                TotalAmount = total,
            };

            return View(cart);
        }

        public List<ShoppingCartItem> GetCartItems()
        {
            var cartItems = HttpContext.Session.GetString("CartItems"); // Session üzerinde CartItems key'ine sahip değerleri  getirir.

            if (cartItems == null)
            {
                return new List<ShoppingCartItem>();
            }

            // cartItems ifadesinin json içeriğini DeserializeObject metodunu kullanarak List<ShoppingCartItem> türüne dönüştür dedik
            return JsonConvert.DeserializeObject<List<ShoppingCartItem>>(cartItems);
        }
    }
}
