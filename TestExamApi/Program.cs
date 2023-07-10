using TestExamApi.Data;
using System.Diagnostics.Metrics;
using deseaseId.Data;
using TestExamApi.Entites;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("posPolicy", policy =>
policy.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()));

builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddScoped<IRepository<DiseaseInformation>, Repository<DiseaseInformation>>();
builder.Services.AddScoped<IRepository<PatientInfo>, Repository<PatientInfo>>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                     options.UseSqlServer(builder.Configuration.GetConnectionString("DefultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseCors(ob => ob.WithOrigins("http://localhost:5235").AllowAnyHeader().AllowAnyMethod());
    app.UseCors("posPolicy");
    app.UseRouting();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
app.Run();
