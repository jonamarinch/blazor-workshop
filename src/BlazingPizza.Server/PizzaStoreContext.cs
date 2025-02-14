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

        // Configuración de relación muchos-a-muchos entre Pizza y Toppings
        modelBuilder.Entity<PizzaTopping>()
            .HasKey(pst => new { pst.PizzaId, pst.ToppingId });

        modelBuilder.Entity<PizzaTopping>()
            .HasOne<Pizza>()
            .WithMany(ps => ps.Toppings)
            .HasForeignKey(pst => pst.PizzaId)
            .OnDelete(DeleteBehavior.Cascade); // Elimina toppings al eliminar una pizza

        modelBuilder.Entity<PizzaTopping>()
            .HasOne(pst => pst.Topping)
            .WithMany()
            .HasForeignKey(pst => pst.ToppingId)
            .OnDelete(DeleteBehavior.Restrict); // Evita eliminar toppings si están en uso

        // Configuración de propiedad de localización en la orden
        modelBuilder.Entity<Order>()
            .OwnsOne(o => o.DeliveryLocation);

        // Configuración opcional para `Salad`
        modelBuilder.Entity<Salad>().ToTable("Salads");
    }
}