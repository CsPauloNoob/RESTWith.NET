using RESTWithDotNet.Models.Services;
using RESTWithDotNet.Models.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//Injeção de dependencia
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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