using api.App.UseCases.PostUseCases;
using api.Infra;
using api.Infra.Repositories;
using api.Infra.Services;
using api.Interfaces.Repositories;
using api.Interfaces.Services;
using api.Interfaces.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>();

// builder.Services. AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICreateManyPostsUseCase, CreateManyPostsUseCase>();
builder.Services.AddScoped<IGetRandomPostUseCase, GetRandomPostUseCase>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostBrowser, PostBrowser>();
builder.Services.AddScoped<IBrowserAdapter, BrowserAdapter>();



var app = builder.Build();
app.UseCors(c => {
    c.AllowAnyOrigin();
});
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
