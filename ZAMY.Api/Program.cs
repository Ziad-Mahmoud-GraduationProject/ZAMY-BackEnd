using ZAMY.Api;
using ZAMY.Api.Mapping;
using ZAMY.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplicationServices()
    .AddMappingServices()
    .AddInfrastructureServices(builder.Configuration);


builder.Services.AddTransient<GlobalExeptionHandlingMiddleware>();

//builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.AddMappingServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExeptionHandlingMiddleware>();

app.MapControllers();

app.Run();
