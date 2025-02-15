using System.Text.Json.Serialization;

namespace BlazingPizza;

public class Order
{
    public int OrderId { get; set; }

    // Set by the server during POST
    public string? UserId { get; set; }

    public DateTime CreatedTime { get; set; }

    public Address DeliveryAddress { get; set; } = new Address();

    // Set by server during POST
    public LatLong? DeliveryLocation { get; set; } = new LatLong(40.4165, -3.70256);

    public List<Pizza> Pizzas { get; set; } = new List<Pizza>();

    public List<Salad> Salads { get; set; } = new List<Salad>();

    public decimal GetTotalPrice()
    {
        return Pizzas.Sum(p => p.GetTotalPrice()) + Salads.Sum(s => s.GetTotalPrice());
    }

    public string GetFormattedTotalPrice()
    {
        return GetTotalPrice().ToString("0.00");
    }
}

[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default, PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(Order))]
[JsonSerializable(typeof(OrderWithStatus))]
[JsonSerializable(typeof(List<OrderWithStatus>))]
[JsonSerializable(typeof(Pizza))]
[JsonSerializable(typeof(List<PizzaSpecial>))]
[JsonSerializable(typeof(List<Topping>))]
[JsonSerializable(typeof(Topping))]
[JsonSerializable(typeof(Salad))]                // ✅ Añadido
[JsonSerializable(typeof(List<Salad>))]         // ✅ Añadido
[JsonSerializable(typeof(Dictionary<string, string>))]
public partial class OrderContext : JsonSerializerContext { }