using Financial_Stock.Hubs;
using Financial_Stock.Model;
using Financial_Stock.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*
 void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<Context>(options =>
    {
        options.UseSqlServer("Data Source=.;Initial catalog=Ecommrec Stock;Integrated Security=true");
    });
}

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
*/





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<Context>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders()
    .AddSignInManager<SignInManager<ApplicationUser>>();

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddScoped<IOrderReposatry, OrderReposatry>();
builder.Services.AddScoped<IOrderLogsReposatry, OrderLogsReposatry>();
builder.Services.AddScoped<IOrderstatusReposatry, OrderStatusReposatry>();
builder.Services.AddScoped<IStockReposatry, StockReposatry>();


builder.Services.AddSignalR();



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

//app.MapHub<ChatHub>("/Chat"); //لو عمدي 3 هب يبقا اعمل 3 تاني تحتو بنفس الطريقه

app.MapControllers();

app.MapHub<ChatHub>("/Chat");


app.Run();
