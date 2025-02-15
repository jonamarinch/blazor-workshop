namespace BlazingPizza.Client;

public class OrderState
{
    public bool ShowingConfigureDialog { get; private set; }

    public Pizza? ConfiguringPizza { get; private set; }

    // Se añade la pizza en estado de configuración
    public Salad? ConfiguringSalad { get; private set; }

    public Order Order { get; private set; } = new Order();

    public void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        ConfiguringPizza = new Pizza()
        {
            Special = special,
            SpecialId = special.Id,
            Size = Pizza.DefaultSize,
            Toppings = new List<ProductTopping>(),
        };

        ShowingConfigureDialog = true;
    }

    public void CancelConfigurePizzaDialog()
    {
        ConfiguringPizza = null;
        ShowingConfigureDialog = false;
    }

    public void ConfirmConfigurePizzaDialog()
    {
        if (ConfiguringPizza is not null)
        {
            Order.Pizzas.Add(ConfiguringPizza);
            ConfiguringPizza = null;
        }

        ShowingConfigureDialog = false;
    }

    public void RemoveConfiguredPizza(Pizza pizza)
    {
        Order.Pizzas.Remove(pizza);
    }

    public void ShowConfigureSaladDialog(Salad salad)
    {
        ConfiguringSalad = new Salad()
        {
            Name = salad.Name,
            Description = salad.Description,
            BasePrice = salad.BasePrice,
            Id = salad.Id,
            Size = 10,
            Toppings = new List<ProductTopping>(),
        };

        ShowingConfigureDialog = true;
    }

    public void CancelConfigureSaladDialog()
    {
        ConfiguringSalad = null;
        ShowingConfigureDialog = false;
    }

    public void ConfirmConfigureSaladDialog()
    {
        if (ConfiguringSalad is not null)
        {
            Order.Salads.Add(ConfiguringSalad);
            ConfiguringSalad = null;
        }

        ShowingConfigureDialog = false;
    }

    public void RemoveConfiguredSalad(Salad salad)
    {
        Order.Salads.Remove(salad);
    }


    public void ResetOrder()
    {
        Order = new Order();
    }

    public void ReplaceOrder(Order order)
    {
        Order = order;
    }
}
