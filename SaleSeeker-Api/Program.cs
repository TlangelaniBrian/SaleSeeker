using Microsoft.AspNetCore.Mvc;
using SaleSeeker_Api.Configurations;
using SaleSeeker_Api.Utils.Response;
using SaleSeeker_DAL.Configurations;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
LoggingConfigInstaller.InstallServices(builder, config);
RepositoryConfigInstaller.InstallServices(builder, config);
FacebookAuthConfigInstaller.InstallServices(builder, config);
RateLimitConfigInstaller.InstallServices(builder, config);

builder.Services.AddControllers();
builder.Services.AddHealthChecks();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc()
                    .ConfigureApiBehaviorOptions(options =>
                    {
                        options.InvalidModelStateResponseFactory = context =>
                        {
                            var response = ResponseCreation.CreateInvalidModelStateResponse(context);

                            return new ObjectResult(response)
                            {
                                StatusCode = response.StatusCode
                            };
                        };
                    });


var app = builder.Build();
MigrationsManager.MigrateDatabase(app);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


