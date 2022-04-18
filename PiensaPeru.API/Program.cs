using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Persistence.Repositories.AdministratorBoundedContextRespositories;
using PiensaPeru.API.Domain.Persistence.Repositories.UserBoundedContextRepositories;
using PiensaPeru.API.Domain.Services;
using PiensaPeru.API.Domain.Services.AdministratorBoundedContextServices;
using PiensaPeru.API.Domain.Services.UserBoundedContextServices;
using PiensaPeru.API.Persistence.Repositories;
using PiensaPeru.API.Persistence.Repositories.AdministratorBoundedContextRepositories;
using PiensaPeru.API.Persistence.Repositories.UserBoundedContextRepositories;
using PiensaPeru.API.Services;
using PiensaPeru.API.Services.AdministratorBoundedContextServices;
using PiensaPeru.API.Services.UserBoundedContextServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//CORS
builder.Services.AddCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Connection Configuration

builder.Services.AddDbContext<AppDbContext>(options =>
{
    //options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Repositories
builder.Services.AddScoped<ISupervisorRepository, SupervisorRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IOptionRepository, OptionRepository>();
builder.Services.AddScoped<IParagraphRepository, ParagraphRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IContentRepository, ContentRepository>();
builder.Services.AddScoped<IPercentageDataRepository, PercentageDataRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IAdministratorRepository, AdministratorRepository>();
builder.Services.AddScoped<IManagementRepository, ManagementRepository>();
builder.Services.AddScoped<ICalificationRepository, CalificationRepository>();

// Services
builder.Services.AddScoped<ISupervisorService, SupervisorService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IOptionService, OptionService>();
builder.Services.AddScoped<IParagraphService, ParagraphService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IContentService, ContentService>();
builder.Services.AddScoped<IPercentageDataService, PercentageDataService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<IAdministratorService, AdministratorService>();
builder.Services.AddScoped<IManagementService, ManagementService>();
builder.Services.AddScoped<ICalificationService, CalificationService>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    // Ensure Database is created, including seed data
    context.Database.EnsureCreated();
}

app.Run();
