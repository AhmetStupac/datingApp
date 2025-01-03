using API.ApplicationServiceExtensions;
using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
//.AllowAnyOrigin());
//WithOrigins("http://localhost:4200", "https://localhost:4200"));
app.UseCors();

app.UseAuthentication();//bitan je redosljed
app.UseAuthorization();// ovo mora ici prije mapcontrollers

app.MapControllers();

app.Run();
