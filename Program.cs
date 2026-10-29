
using GestionDeProductosAPI.Repositories;
using GestionDeProductosAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Registrar los controladores.
builder.Services.AddControllers();                                                          //AddControllers(): Habilita los controladores de la API.

// Configurar Swagger.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();                                                           //AddSwaggerGen(): Permite generar la documentación de Swagger.

// Registrar las dependencias de la aplicación.
builder.Services.AddScoped<IProductoRepository, ProductoRepositoryInMemory>();
builder.Services.AddScoped<IProductoService, ProductoService>();                          

var app = builder.Build();

// Habilitar Swagger y su interfaz gráfica en desarrollo.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();                                                                       //Registra las rutas definidas en ProductosController.

app.Run();