using Microsoft.Extensions.Configuration;
using SimulationDriver;
using webapi;
using webapi.Repositories;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ScadaDBContext>();
// Register repositories
builder.Services.AddScoped<IDigitalInputRepository, DigitalInputRepository>();
builder.Services.AddScoped<IDigitalOutputRepository, DigitalOutputRepository>();
builder.Services.AddScoped<IAnalogInputRepository, AnalogInputRepository>();
builder.Services.AddScoped<IAnalogOutputRepository, AnalogOutputRepository>();
builder.Services.AddScoped<IIOAddressRepository, IOAddressRepository>();
builder.Services.AddScoped<ITagValueRepository, TagValueRepository>();
builder.Services.AddScoped<IAlarmRepository, AlarmRepository>();


// Register services
builder.Services.AddScoped<IDigitalInputService, DigitalInputService>();
builder.Services.AddScoped<IDigitalOutputService, DigitalOutputService>();
builder.Services.AddScoped<IAnalogInputService, AnalogInputService>();
builder.Services.AddScoped<IAnalogOutputService, AnalogOutputService>();
builder.Services.AddScoped<ITagValueService, TagValueService>();
builder.Services.AddScoped<IAlarmService, AlarmService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var db = new ScadaDBContext())
{
    db.Database.EnsureCreated();
    db.SaveChanges();
}
SimulationDriver.SimulationDriver simulationDriver = new SimulationDriver.SimulationDriver(new object());
simulationDriver.StartSimulation();
RealTimeDriver realTimeDriver = new RealTimeDriver(new object());
simulationDriver.StartSimulation();
realTimeDriver.StartSimulation();
app.Run();
