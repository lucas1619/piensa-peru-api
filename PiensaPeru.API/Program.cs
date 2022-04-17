using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PiensaPeru.API.Domain.Persistence.Contexts;
using PiensaPeru.API.Domain.Persistence.Repositories;
using PiensaPeru.API.Domain.Persistence.Repositories.ContentBoundedContextIRepositories;
using PiensaPeru.API.Domain.Services;
using PiensaPeru.API.Domain.Services.ContentBoundedContextIServices;
using PiensaPeru.API.Persistence.Repositories;
using PiensaPeru.API.Persistence.Repositories.ContentBoundedContextRepositories;
using PiensaPeru.API.Services;
using PiensaPeru.API.Services.ContentBoundedContextServices;

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
builder.Services.AddScoped<IPostTypeRepository, PostTypeRepository>();
builder.Services.AddScoped<IContentRepository, ContentRepository>();
builder.Services.AddScoped<IPercentageDataRepository, PercentageDataRepository>();
builder.Services.AddScoped<IDataTypeRepository, DataTypeRepository>();
builder.Services.AddScoped<IMilitantRepository, MilitantRepository>();
builder.Services.AddScoped<IMilitantContentRepository, MilitantContentRepository>();
builder.Services.AddScoped<IPeriodRepository, PeriodRepository>();
builder.Services.AddScoped<IPoliticalPartyRepository, PoliticalPartyRepository>();

// Services
builder.Services.AddScoped<ISupervisorService, SupervisorService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IOptionService, OptionService>();
builder.Services.AddScoped<IParagraphService, ParagraphService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IPostTypeService, PostTypeService>();
builder.Services.AddScoped<IContentService, ContentService>();
builder.Services.AddScoped<IPercentageDataService, PercentageDataService>();
builder.Services.AddScoped<IDataTypeService, DataTypeService>();
builder.Services.AddScoped<IMilitantService, MilitantService>();
builder.Services.AddScoped<IMilitantContentService, MilitantContentService>();
builder.Services.AddScoped<IPeriodService, PeriodService>();
builder.Services.AddScoped<IPoliticalPartyService, PoliticalPartyService>();


builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Piensa Perú", Version = "v1" });
    c.EnableAnnotations();
});

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
