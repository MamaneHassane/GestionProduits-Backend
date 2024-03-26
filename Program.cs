using TP_SOMEI.Datas;
using TP_SOMEI.Model.Entities;
using TP_SOMEI.Repositories.Implementations;
using TP_SOMEI.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Mettre IServiceCollection dans une variable
var dependencyContainer = builder.Services;

// Ajouter les endpoints de .NET Identity
dependencyContainer.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<ApplicationDbContext>();

// Mettre les configurations du builder dans une variable
var configurations = builder.Configuration;

// Retrouver la chaîne de connexion depuis "appSettings.json"
var connectionString = configurations.GetConnectionString("MySqlServerDefaultConnection");

// Ajouter SQL Server, avec notre contexte de base de données depuis "Datas/ApplicationDbContext" et notre chaîne de connexion
dependencyContainer.AddSqlServer<ApplicationDbContext>(connectionString);

// Configurer l'inversion des dépendances pour les repositories
dependencyContainer.AddScoped<IProductRepository, ProductRepository>();

// Ajouter les controlleurs
dependencyContainer.AddControllers();

// Construire l'application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseStaticFiles(); 
app.UseRouting();

// Politique des origines
app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
});


// Mapper les contrôleurs
app.MapControllers();

// Mapper les endpoints de .NET Identity
app.MapIdentityApi<User>();

app.UseHttpsRedirection();

app.Run();
