namespace EEducation.WebUI.Models
{
    // Sepetin içerisinde bir ürüne ait satırın oluşturulduğu model sınıfıdır
    public class ShoppingCartItem
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total => Price * Quantity;
    }
}

