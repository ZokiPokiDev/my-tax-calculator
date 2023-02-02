using TaxCalculatorAPI;

var builder = WebApplication.CreateBuilder(args);
var startUp = new Startup(builder.Configuration, builder.Environment);

startUp.AddDependencies(builder.Services);

var app = builder.Build();

startUp.AddConfiguration(app, app.Environment);
app.MapControllers();

app.Run();
