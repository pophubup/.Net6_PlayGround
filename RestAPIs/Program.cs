
using RestAPIs.Hubs;
var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;
if (env.IsDevelopment())
{
    //Allen Home
    if (System.IO.File.Exists(@"C:\Users\Yohoo\Desktop\key.json"))
    {
        builder.Configuration.AddJsonFile(@"C:\Users\Yohoo\Desktop\key.json", optional: true, reloadOnChange: true);
    }
    //Allen company
    if (System.IO.File.Exists(@"C:\Users\Yohoo\OneDrive\桌面\key.json"))
    {
        builder.Configuration.AddJsonFile(@"C:\Users\Yohoo\OneDrive\桌面\key.json", optional: true, reloadOnChange: true);
    }

}
if (env.IsProduction())
{
    builder.Configuration.AddJsonFile(@"D:\home\key.json", optional: true, reloadOnChange: true);

}

// Add services to the container.
builder.Services.AddNpgsql(builder.Configuration["SQL:NpqSQLConn3"]);
#region work related
//builder.Services.AddWorkedRelatedClient(builder.Configuration);
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:8080/").AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed((host) => true);
        }));
#region 工作上研究

#endregion

for (int i = 0; i <    10000; i++)
{
    var cccc = Task.Run(() =>
    {
        Console.WriteLine($"{ Thread.CurrentThread.ManagedThreadId}");

    });
}
var app = builder.Build();
 //cccc.GetAwaiter().GetResult();
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("CorsPolicy");

app.MapHub<MyHub>("/myHub");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
