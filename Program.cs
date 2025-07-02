using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using NetWares.Extensions;
using NetWares.Interfaces.Repository;
using NetWares.Interfaces.Service;
using NetWares.Models;
using NetWares.Seeders;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDependencyInjection(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors("AllowAny");
app.UseHttpsRedirection();

app.UseExceptionHandler(handler =>
{
    handler.Run(async context =>
    {
        var exceptionHandler = context.RequestServices.GetRequiredService<IExceptionHandler>();
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (exception != null && !context.Response.HasStarted)
        {
            context.Response.Clear();
            await exceptionHandler.TryHandleAsync(context, exception, context.RequestAborted);
        }
        else if (context.Response.HasStarted)
        {
            // Log that response has started
            var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogWarning("Response already started, skipping exception handling");
        }
    });
});
app.MapGet("/", () => "NetWares is working bitchessssss!");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// using (var scope = app.Services.CreateScope())
// {
//     var serviceProvider = scope.ServiceProvider;
//     var subsidyService = serviceProvider.GetRequiredService<ITrainingParticipantRepository>();
//     await Seed.SeedTrainingParticipate(subsidyService);
// }
app.Run();
