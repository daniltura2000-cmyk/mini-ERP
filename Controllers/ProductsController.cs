namespace WebApplication3.DTO;


using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
   private static readonly List<Product> _products = new()
   {
      new Product(1, 500, "sommeawmeas", "somedescription"),
      new Product(2, 100, "some", "somedescription"),
   };
   
   
   public List<Product> GetAllProducts()
   {
      return _products;
   }

   // 3. Метод поиска по ID
   public Product? GetProductById(int id)
   {
      return _products.FirstOrDefault(p => p.Id == id);
   }

   // 4. Метод создания нового товара
   public Product CreateProduct(CreateProductDto dto)
   {
      int newId = _products.Count + 1;
      var newProduct = new Product(newId, dto.Price, dto.Name, dto.Description);
        
      _products.Add(newProduct);
        
      return newProduct;
   }
}