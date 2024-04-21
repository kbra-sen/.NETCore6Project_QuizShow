using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using QuizShow.Context;
using QuizShow.Models;
using QuizShow.RepositoryPattern.Base;
using QuizShow.RepositoryPattern.Concrate;
using QuizShow.RepositoryPattern.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>()); // 1.iþlem

var conn = builder.Configuration["ConnectionStrings:Mssql"];
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(conn));
builder.Services.AddScoped<IQuestionsRepository, QuestionRepository>();
builder.Services.AddScoped<IRepository<Points>, Repository<Points>>();
builder.Services.AddScoped<IAnswersRepository, AnswersRepository>();
builder.Services.AddScoped<IGameQuestionsRepository, GameQuestionsRepository>();
builder.Services.AddScoped<IGameAnswersRepository, GameAnswersRepository>();
var app = builder.Build();
using (var scope = app.Services.CreateScope()) // projeyi baþka yerde açarken dbde gelsin diye
{
    var db = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    db.Database.Migrate();
}
app.UseStaticFiles();
app.UseRouting();


/*app.MapControllerRoute(name: "default", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}/{name?}");*/
 app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "defaultArea", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
   endpoints.MapControllerRoute(
        name:"default", pattern:"{controller=Home}/{action=Index}/{id?}" );
    
});


app.Run();
