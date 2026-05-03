using WebApplication3.Models;
using WebApplication3.DTO;

namespace WebApplication3.Services;

public interface IProductService
{
    List<Product> GetAllProducts();
    Product? GetProductById(int id);
    Product CreateProduct(CreateProductDto dto);
}