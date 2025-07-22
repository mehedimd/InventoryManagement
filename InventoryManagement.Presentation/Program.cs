using InventoryManagement.Application.Interfaces;
using InventoryManagement.Application.Mapper;
using InventoryManagement.Application.Services;
using InventoryManagement.Infrastructure.ServiceExtension;

var builder = WebApplication.CreateBuilder(args);

// DbContext setup
builder.Services.AddDIServices(builder.Configuration);

// AutoMapper DI
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Add services to the container.
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ICustomerOrderService, CustomerOrderService>();

// enable cors
builder.Services.AddCors(option => option.AddPolicy("corsPolicy", policy => policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
