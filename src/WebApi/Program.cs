using Application;
using Azure.Storage.Blobs;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RentalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), 
        s => { s.MigrationsAssembly("WebApi");
            s.UseNetTopologySuite();
        }));
builder.Services.AddSingleton( x => new BlobServiceClient( builder.Configuration.GetValue<string>("BlobConnectionString")));
builder.Services.RegisterServices();
builder.Services.AddMemoryCache();
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
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<RentalContext>();    
    var cache = services.GetRequiredService<IMemoryCache>();    
    context.Database.Migrate();
    var property = context.Properties.OrderBy( c => c.CreatedOn).FirstOrDefault();
    
    if (property == null)
    {
        cache.Set("PropertyRef", 245015);
    }
    else
    {
        cache.Set("PropertyRef", property.Reference);
    }
    
    
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
