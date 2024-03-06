using Sprencia_Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
ConfigureSwagger.AddSwagger(builder.Services);
ConfigureDBContext.AddDBContext(builder.Services, builder.Configuration);
ConfigureCustomServices.AddCustomServices(builder.Services);
ConfigureRepositories.AddRepositories(builder.Services);
ConfigureAuthentication.AddAuthentication(builder.Services, builder.Configuration);
ConfigureCors.AllowOrigins(builder.Services, builder.Configuration);

var app = builder.Build();

await InitDatabase.Init(app);

ConfigureApp.Configure(app);

app.Run();

// dotnet ef --startup-project ../Sprencia_Api migrations add ¿Test?
// dotnet ef --startup-project ../Sprencia_Api database update

