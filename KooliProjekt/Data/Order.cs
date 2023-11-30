using KooliProjekt.Data;

namespace KooliProjekt
{
    public class Order
    {

        public int Id {get; set;}
        public int ProductId {get;set;}
        public Product Product {get;set;}
        
        public decimal EstimatedPrice {get; set;} //Calculated from DistancePrice and TimePrice in Product
        public string CustomerId {get;set;}
        public Customer Customer {get;set;}
        public List<OrderDetail> OrderDetails { get; set; } // This class might be needed if I start extend Order class
    }
}