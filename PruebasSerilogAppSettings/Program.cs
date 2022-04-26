

using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Host.UseSerilog().ConfigureLogging((hostContext, services) =>
    {
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(hostContext.Configuration).CreateLogger();
    }
);

Log.Verbose("Verbose");
Log.Debug("Debug");
Log.Information("Information");
Log.Warning("Warning");
Log.Error("Error");
Log.Fatal("Fatal Error");
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
