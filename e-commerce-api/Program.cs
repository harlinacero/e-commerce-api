using e_commerce_api.Controllers;
using e_commerce_domain.observer.contracts;
using e_commerce_domain.repositories;
using e_commerce_infraestructure.Reposotory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IInventoryManager>(provider => new PhysicalInventoryManager(new List<IInventoryObserver>()));
builder.Services.AddSingleton<IInventoryManager>(provider => new DigitalInventoryManager(new List<IInventoryObserver>()));

builder.Services.AddTransient<ProductController>(provider =>
{
    var physicalInventoryManager = provider.GetServices<IInventoryManager>().First(m => m is PhysicalInventoryManager);
    var digitalInventoryManager = provider.GetServices<IInventoryManager>().First(m => m is DigitalInventoryManager);
    return new ProductController(physicalInventoryManager, digitalInventoryManager);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
