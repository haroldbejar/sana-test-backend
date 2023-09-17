using Appllication.Services;
using Appllication.Services.Services.ProductService;
using Domain;
using Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
{
    var constring = builder.Configuration.GetConnectionString("defaultConnection");

    builder.Services.AddData(constring);
    //builder.Services.AddAllGenericTypes();
    builder.Services.AddInfrastructure();
    builder.Services.AddApplication();

    builder.Services.AddControllers().AddJsonOptions(x => 
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddCors();
}
var app = builder.Build();
{ 
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("*"));
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}