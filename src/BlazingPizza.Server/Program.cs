using BlazingPizza.Server;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios de la aplicación
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.AddContext<BlazingPizza.OrderContext>();
    });

builder.Services.AddRazorPages();

// Configurar la base de datos SQLite
builder.Services.AddDbContext<PizzaStoreContext>(options =>
    options.UseSqlite("Data Source=pizza.db"));

builder.Services.AddDefaultIdentity<PizzaStoreUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<PizzaStoreContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<PizzaStoreUser, PizzaStoreContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

var app = builder.Build();

// ✅ Inicialización de la base de datos correctamente
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();

    // Aplica migraciones automáticamente
    db.Database.Migrate();

    // Poblar la base de datos con datos de prueba
    SeedData.Initialize(db);
}

// Configuración del pipeline de middleware
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();

// Configurar API y páginas
app.MapPizzaApi();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();