var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();                      //Registrar los servicios.

builder.Services.AddEndpointsApiExplorer();             //Configurar Swagger.
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())                    //Habilitar Swagger y su interfaz gráfica.
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();