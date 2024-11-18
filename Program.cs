
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TasksApi.Models;
using TasksApi.Repository;
using TasksApi.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TasksDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"))
);

builder.Services.AddScoped<ITaskRepository, TasksRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped(typeof(GenericRepository<>));

builder.Services.AddControllers();

// Add Swagger services to the container.
builder.Services.AddEndpointsApiExplorer(); // For exposing endpoints
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Books API",
        Description = "A simple example ASP.NET Core API to manage books",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com",
            Url = new Uri("https://yourwebsite.com"),
        }
    });
});

var app = builder.Build();

// Configure request pipeline
if (app.Environment.IsDevelopment())
{ 

    app.UseDeveloperExceptionPage(); // Detailed error page in Development
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Error handling for Production
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Enable middleware to serve generated Swagger as a JSON    endpoint.
    app.UseSwagger();

    // Enable middleware to serve Swagger UI (HTML, JS, CSS, etc.)
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Books API V1");
        c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
    });
}

app.UseRouting();


app.MapControllers(); // Maps attribute-routed controllers

// Start the app
app.Run();
