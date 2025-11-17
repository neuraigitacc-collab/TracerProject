using Tracer.Application.Service;
using Tracer.Application.Service.Contracts;
using Tracer.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSignalR();

builder.Services.AddScoped<IValidationService, ValidationService>();
builder.Services.AddScoped<IDevicesService, DevicesService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()   // ?? ???? ???? Origin ????
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");


app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
//app.MapHub<ValidationHub>("/hubs/Validation");
app.Run();