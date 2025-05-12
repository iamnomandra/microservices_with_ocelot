namespace ProductsServices.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
    }

    public static class ProductList
    {
        public static List<ProductModel> Products()
        {
            var productList = new List<ProductModel>
            {
                new ProductModel { Id = 1, ProductName = "Pillows" },
                new ProductModel { Id = 2, ProductName = "Chairs" },
                new ProductModel { Id = 3, ProductName = "Sofa" },
            };
            return productList;
        }
    }
}
