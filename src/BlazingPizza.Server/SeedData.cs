namespace BlazingPizza.Server;

public static class SeedData
{
    public static void Initialize(PizzaStoreContext db)
    {  

        var toppings = new Topping[]
        {
            // BEBIDAS
            new Topping()
            {
                    Name = "Agua mineral (botella)",
                    Price = 2.50m,
            },
            new Topping()
            {
                    Name = "Coca-Cola",
                    Price = 2.99m,
            },
            new Topping()
            {
                    Name = "Fanta naranja",
                    Price = 2.99m,
            },
            new Topping()
            {
                    Name = "Fanta limón",
                    Price = 2.99m,
            },
            new Topping()
            {
                    Name = "Fuze Tea",
                    Price = 2.99m,
            },
            // OTROS 'EXTRAS'
            new Topping()
            {
                    Name = "Queso Extra",
                    Price = 2.50m,
            },
            new Topping()
            {
                    Name = "Bacon americano",
                    Price = 2.99m,
            },
            new Topping()
            {
                    Name = "Bacon inglés",
                    Price = 2.99m,
            },
            new Topping()
            {
                    Name = "Bacon canadiense",
                    Price = 2.99m,
            },
            new Topping()
            {
                    Name = "Té y bollitos",
                    Price = 5.00m
            },
            new Topping()
            {
                    Name = "Scones del horno",
                    Price = 4.50m,
            },
            new Topping()
            {
                    Name = "Pimientos dulces",
                    Price = 1.00m,
            },
            new Topping()
            {
                    Name = "Cebolla",
                    Price = 1.00m,
            },
            new Topping()
            {
                    Name = "Champiñones",
                    Price = 1.00m,
            },
            new Topping()
            {
                    Name = "Pepperoni",
                    Price = 1.00m,
            },
            new Topping()
            {
                    Name = "Salchicha de pato",
                    Price = 3.20m,
            },
            new Topping()
            {
                    Name = "Albóndigas de venado",
                    Price = 2.50m,
            },
            new Topping()
            {
                    Name = "Servido en fuente de plata",
                    Price = 250.99m,
            },
            new Topping()
            {
                    Name = "Coronado con langosta",
                    Price = 64.50m,
            },
            new Topping()
            {
                    Name = "Caviar de esturión",
                    Price = 101.75m,
            },
            new Topping()
            {
                    Name = "Corazones de alcachofa",
                    Price = 3.40m,
            },
            new Topping()
            {
                    Name = "Tomates frescos",
                    Price = 1.50m,
            },
            new Topping()
            {
                    Name = "Albahaca",
                    Price = 1.50m,
            },
            new Topping()
            {
                    Name = "Filete especial",
                    Price = 8.50m,
            },
            new Topping()
            {
                    Name = "Pimientos súper picantes",
                    Price = 4.20m,
            },
            new Topping()
            {
                    Name = "Pollo búfalo",
                    Price = 5.00m,
            },
            new Topping()
            {
                    Name = "Queso azul",
                    Price = 2.50m,
            },
        };

        var specials = new PizzaSpecial[]
        {
            new PizzaSpecial()
            {
                    Name = "Pizza de queso básica",
                    Description = "De toda la vida.",
                    BasePrice = 9.99m,
                    ImageUrl = "img/pizzas/cheese.jpg",
            },
            new PizzaSpecial()
            {
                    Id = 2,
                    Name = "El baconizador",
                    Description = "Con todos los tipos de bacon.",
                    BasePrice = 11.99m,
                    ImageUrl = "img/pizzas/bacon.jpg",
            },
            new PizzaSpecial()
            {
                    Id = 3,
                    Name = "Pepperoni clásica",
                    Description = "La pizza de tu infancia.",
                    BasePrice = 10.50m,
                    ImageUrl = "img/pizzas/pepperoni.jpg",
            },
            new PizzaSpecial()
            {
                    Id = 4,
                    Name = "Pollo búfalo",
                    Description = "Pollo picante.",
                    BasePrice = 12.75m,
                    ImageUrl = "img/pizzas/meaty.jpg",
            },
            new PizzaSpecial()
            {
                    Id = 5,
                    Name = "Champiñónica",
                    Description = "Tiene champiñones.",
                    BasePrice = 11.00m,
                    ImageUrl = "img/pizzas/mushroom.jpg",
            },
            new PizzaSpecial()
            {
                    Id = 6,
                    Name = "El Guiri",
                    Description = "Estando en Alicante...",
                    BasePrice = 10.25m,
                    ImageUrl = "img/pizzas/brit.jpg",
            },
            new PizzaSpecial()
            {
                    Id = 7,
                    Name = "Vegetariana",
                    Description = "Como una ensalada sobre una pizza.",
                    BasePrice = 11.50m,
                    ImageUrl = "img/pizzas/salad.jpg",
            },
            new PizzaSpecial()
            {
                    Id = 8,
                    Name = "Margarita",
                    Description = "Tradicional Italiana.",
                    BasePrice = 9.99m,
                    ImageUrl = "img/pizzas/margherita.jpg",
            },
        };

        var salads = new Salad[]
        {
            new Salad()
            {
                Id = 9,
                Name = "Ensalada César",
                Description = "Crujiente lechuga romana con aderezo César, crutones y queso parmesano.",
                BasePrice = 10.99m,
                ImageUrl = "img/salads/cesar.jpg",
            },
            new Salad()
            {
                Id = 10,
                Name = "Ensalada Mediterránea",
                Description = "Mezcla de lechugas con tomate cherry, aceitunas negras, queso feta y aderezo de limón.",
                BasePrice = 11.49m,
                ImageUrl = "img/salads/mediterranea.jpg",
            },
            new Salad()
            {
                Id = 11,
                Name = "Ensalada de Pollo a la Parrilla",
                Description = "Pollo a la parrilla sobre una cama de espinacas y rúcula, con nueces y aderezo balsámico.",
                BasePrice = 12.99m,
                ImageUrl = "img/salads/pollo.jpg",
            }
        };

        // Código para añadir registros especificados

        /*
        db.Toppings.AddRange(toppings);
        db.Specials.AddRange(specials);
        db.Salads.AddRange(salads);
        db.SaveChanges();
        */
    }
}