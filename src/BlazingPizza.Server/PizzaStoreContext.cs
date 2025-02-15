using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazingPizza.Server;

public class PizzaStoreContext : ApiAuthorizationDbContext<PizzaStoreUser>
{
    public PizzaStoreContext(
        DbContextOptions<PizzaStoreContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions
    ) : base(options, operationalStoreOptions)
    {
    }

    // Definición de las tablas en la base de datos
    public DbSet<Order> Orders { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<PizzaSpecial> Specials { get; set; }
    public DbSet<Topping> Toppings { get; set; }
    public DbSet<Salad> Salads { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<NotificationSubscription> NotificationSubscriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuring a many-to-many special -> topping relationship that is friendly for serialization
        modelBuilder.Entity<ProductTopping>().HasKey(pst => new { pst.ProductId, pst.ProductType, pst.ToppingId });
        modelBuilder.Entity<ProductTopping>().HasOne(pst => pst.Topping).WithMany();

        // Inline the Lat-Long pairs in Order rather than having a FK to another table
        modelBuilder.Entity<Order>().OwnsOne(o => o.DeliveryLocation);
    }
}