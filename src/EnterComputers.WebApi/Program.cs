using EnterComputers.DataAcces.Interfaces.Categories;
using EnterComputers.DataAcces.Interfaces.Companies;
using EnterComputers.DataAcces.Interfaces.Users;
using EnterComputers.DataAcces.Repositories.Categories;
using EnterComputers.DataAcces.Repositories.Companies;
using EnterComputers.DataAcces.Repositories.Users;
using EnterComputers.Service.Interfaces.Auth;
using EnterComputers.Service.Interfaces.Categories;
using EnterComputers.Service.Interfaces.Common;
using EnterComputers.Service.Interfaces.Companies;
using EnterComputers.Service.Services.Auth;
using EnterComputers.Service.Services.Categories;
using EnterComputers.Service.Services.Common;
using EnterComputers.Service.Services.Companies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

//-> DI containers, IoC containers
// AddSingelton, AddScoped, AddTransient
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IFileService, FileServic>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IcompanyService, CompaniService>();
builder.Services.AddScoped<IAuthService, AuthService>();




/*builder.Services.AddSingleton<IShortStorageService, ShortStorageService>();
builder.Services.AddScoped<IShortStorageService, ShortStorageService>();
builder.Services.AddTransient<IShortStorageService, ShortStorageService>();
*/



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();
