using System.Text.Json.Serialization;

namespace BlazingPizza;

/// <summary>
///    /// Represents a customized pizza as part of an order
/// </summary>
public class Pizza
{
    public const int DefaultSize = 12;
    public const int MinimumSize = 9;
    public const int MaximumSize = 17;

    public int Id { get; set; }

    public String ProductType { get; set; } = "Pizza";

    public int OrderId { get; set; }

    public PizzaSpecial? Special { get; set; }

    public int SpecialId { get; set; }

    public int Size { get; set; }

    public List<ProductTopping> Toppings { get; set; } = new();

    /*
    public Pizza()
    {
        foreach (var topping in Toppings)
        {
            topping.ProductType = "Pizza";
        }
    }*/

    public decimal GetBasePrice()
    {
        if(Special == null) throw new NullReferenceException($"{nameof(Special)} was null when calculating Base Price.");
        return ((decimal)Size / (decimal)DefaultSize) * Special.BasePrice;
    }

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

[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(Pizza))]
public partial class PizzaContext : JsonSerializerContext { }