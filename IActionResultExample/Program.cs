var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();       //its meaning is to add the controller service to the service container to use the controller in the application
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();   //this is done so that we can enable the routing in action controller menthods

app.Run();
