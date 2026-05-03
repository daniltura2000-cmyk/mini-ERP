using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers;

// [ApiController] говорит фреймворку, что этот класс обрабатывает HTTP-запросы
// и автоматически включает некоторые полезные фишки (например, базовую валидацию).
[ApiController] 
// [Route] задает базовый адрес. "[controller]" подставит имя класса без слова Controller. 
// Получится адрес: /api/products
[Route("api/[controller]")] 
public class ProductsController : ControllerBase
{
    // Пока у нас нет базы данных, сымитируем ее с помощью статического списка
    private static readonly List<Product> _products = new()
    {
        new Product(1, 1500.50m, "Ноутбук", "Хороший рабочий ноутбук"),
        new Product(2, 300.00m, "Мышка", "Беспроводная мышь")
    };

    // Метод для получения ВСЕХ товаров
    // Обрабатывает запрос: GET /api/products
    [HttpGet]
    public IActionResult GetAllProducts()
    {
        // Возвращаем статус 200 (OK) и список товаров
        return Ok(_products); 
    }

    // Метод для получения ОДНОГО товара по его Id
    // Обрабатывает запрос: GET /api/products/1
    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        // Ищем товар с помощью LINQ
        var product = _products.FirstOrDefault(p => p.Id == id);

        // Если товар не найден — возвращаем статус 404 (Not Found)
        if (product == null)
        {
            return NotFound(new { Message = $"Товар с ID {id} не найден" });
        }

        // Если нашли — возвращаем 200 (OK) и сам товар
        return Ok(product);
    }
}