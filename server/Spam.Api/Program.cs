using Scalar.AspNetCore;
using Spam.Api.ML;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

// ML Service
builder.Services.AddScoped<SpamPredictionService>();

var app = builder.Build();

// Train model once if missing
if (!File.Exists("ML/spam-model.zip"))
{
    Directory.CreateDirectory("ML");
    var trainer = new SpamTrainer();
    trainer.Train();
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

app.UseAuthorization();

app.UseCors(policy => 
    policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.MapControllers();

app.Run();