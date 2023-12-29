using EEducation.Core.Service;
using EEducation.Model.Entities;
using EEducation.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using static EEducation.WebUI.Models.ShoppingCart;

namespace EEducation.WebUI.Controllers
{
  
    public class CartController : Controller
    {
        // Sepetin içeriği göster
        public IActionResult Index( )
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


        // Sepete Ekle
        public IActionResult AddToCart(Product product, int quantity = 1)
        {
            var cartItems = GetCartItems(); // sessionda ekli olan ürünleri getir dedik
            AddProductToCart(cartItems, product, quantity); // Ekleme
            SaveCartItems(cartItems); // Session kayıt yap

            return RedirectToAction("Index");
        }

        // Sepete Ekleme için Private türde bir metod yaz
        private void AddProductToCart(List<ShoppingCartItem> cartItems, Product product, int Quantity)
        {
            var record = cartItems.FirstOrDefault(x => x.ID == product.ID);

            if (record != null)
            {
                record.Quantity += Quantity;
            }
            else
            {
                cartItems.Add(new ShoppingCartItem { ID = product.ID, ProductName = product.ProductName, Price = Convert.ToDecimal(product.ProductPrice), Quantity = Quantity });
            }
        }

        // Sepetten Sil
        public IActionResult RemoveToCart(int id, int quantity = 1)
        {
            var cartItems = GetCartItems();
            RemoveProductToCart(cartItems, id, quantity); // Sildik
            SaveCartItems(cartItems); // Session'ın son halini kaydettik

            return RedirectToAction("Index");
        }

        // Sepeten Silme işlemi için Private türde bir metod yaz
        private void RemoveProductToCart(List<ShoppingCartItem> cartItems, int productId, int quantity)
        {
            var existCartItems = cartItems.FirstOrDefault(x => x.ID == productId); // 1
            if (existCartItems != null)
            {
                if (existCartItems.Quantity > quantity)
                {
                    existCartItems.Quantity -= quantity;
                }
                else
                {
                    cartItems.Remove(existCartItems);
                }
            }
        }

        // Sepetin içerisini komple temizle
        public IActionResult ClearCart()
        {
            HttpContext.Session.Clear(); // Session içerisindeki öğeleri temizler
            return RedirectToAction("Index");
        }


        // Sepettekilerin session'a kayıt edilmesi (Set)
        public void SaveCartItems(List<ShoppingCartItem> cartItems)
        {
            // SerializeObject metodunu kullanarak json'a dönüşüm yaptık
            var cartItemsJson = JsonConvert.SerializeObject(cartItems);
            HttpContext.Session.SetString("CartItems", cartItemsJson);
        }


        // Sepetti ürünlerin neler olduğunu session'dan okuyarak elde etmek için metod yaz (Get)
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
