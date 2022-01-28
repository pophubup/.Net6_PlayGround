using zNpgsqlClient;

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
    if (System.IO.File.Exists(@"C:\Users\Yohoo\OneDrive\орн▒\key.json"))
    {
        builder.Configuration.AddJsonFile(@"C:\Users\Yohoo\OneDrive\орн▒\key.json", optional: true, reloadOnChange: true);
    }

}
if (env.IsProduction())
{
    builder.Configuration.AddJsonFile(@"D:\home\key.json", optional: true, reloadOnChange: true);

}
// Add services to the container.
builder.Services.AddPostgreSQLClient(@"Host=ls-4d67eb0d3e5a4593522a60644a188bea651c79ed.cwdxwfoovuek.ap-northeast-2.rds.amazonaws.com; Port=5432; Database=Test3; User Id=dbmasteruser; Password=Home7996;");
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

app.Run();
