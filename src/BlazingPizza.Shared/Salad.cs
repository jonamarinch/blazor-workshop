using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingPizza;

// Clase para la ensalada
public class Salad
{
    public int Id { get; set; }
    public String ProductType { get; set; } = "Salad";
    public string Name { get; set; } = string.Empty;
    public decimal BasePrice { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = "img/salads/default.jpg";
    public int Size { get; set; } = 10;
    public int DefaultSize { get; set; } = 10;
    public List<ProductTopping> Toppings { get; set; } = new();

    public Salad()
    {
        foreach (var topping in Toppings)
        {
            topping.ProductType = "Salad";
        }
    }

    // El precio base toma en cuenta el tamaño seleccionado
    public decimal GetBasePrice()
    {
        return ((decimal)Size / (decimal)DefaultSize) * BasePrice;
    }

    // El precio total toma en cuenta además los extras
    public decimal GetTotalPrice()
    {
        if (Toppings.Any(t => t.Topping is null)) throw new NullReferenceException($"{nameof(Toppings)} contained null when calculating the Total Price.");
        return GetBasePrice() + Toppings.Sum(t => t.Topping!.Price);
    }

    public string GetFormattedTotalPrice()
    {
        return GetTotalPrice().ToString("0.00");
    }
}

