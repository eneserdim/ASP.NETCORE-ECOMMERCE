namespace EEducation.WebUI.Models
{
    // Sepetin tamamını temsil eden sınıftır
    public class ShoppingCart
    {
        public List<ShoppingCartItem> CartItems { get; set; }
        public decimal TotalAmount { get; set; }
    }
}