using Scalar.AspNetCore;
using Spam.Api.ML;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// ML Service
builder.Services.AddScoped<SpamPredictionService>();

var app = builder.Build();

// Train model once if missing
if (!File.Exists("ML/spam-model.zip"))
{
    Directory.CreateDirectory("ML");
    try
    {
        var trainer = new SpamTrainer();
        trainer.Train();
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"Error training model on startup: {ex}");
        throw;
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(opt =>
    {
        opt.RouteTemplate = "openapi/{documentName}.json";
    });

    app.MapScalarApiReference(opt =>
    {
        opt.Title = "Spam Detector API";
        opt.Theme = ScalarTheme.DeepSpace;
        opt.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Http11);
    });
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();