namespace WebApplication3.Models;

public class Product
{
    public int Id { get; private set; }
    public decimal Price { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public Product(int id, decimal price, string name, string description)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Имя не может быть пустым");
        }

        if (price <= 0)
        {
            throw new ArgumentException("Цена не может быть меньше нуля");
        }

        Id = id;
        Price = price;
        Name = name;
        Description = description;
    }

    protected Product() { }
    }
