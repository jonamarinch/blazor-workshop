namespace BlazingPizza;

public class ProductTopping
{
    public Topping? Topping { get; set; }

    public int ToppingId { get; set; }

    public int ProductId { get; set; }

    public string ProductType { get; set; } = string.Empty; // "Pizza" o "Salad"

}