using webapi.Context;
using webapi.Middlewares;
using webapi.Services;
using webapi.Services.ServiceImpl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString("cnTask"));
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITaskService, TaskService>();
//builder.Services.AddScoped(p => new HelloWorldService()); //--> Esta es otra manera de inyectar las dependecias, pero por solid es mejor usar la interfaces

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();

app.UseTimeMiddleware();

app.MapControllers();

app.Run();

