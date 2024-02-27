using Serilog;
using Web_Api;
using Web_Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("credentials.json", optional: true, reloadOnChange: true);

builder.Host.AddSerilog();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontEnd", builder =>
    {
        builder.WithOrigins("https://localhost:7284")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddAntiforgery();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddProject(builder.Configuration);

// builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontEnd");

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseAntiforgery();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// app.UseMiddleware<RequestLogContextMiddleware>();
//
app.UseSerilogRequestLogging();



// app.MapCarter();


app.Run();

