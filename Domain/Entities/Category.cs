using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IList<Product> Products { get; set; }
    }
}