namespace _8_aspnetcore_configuration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.Configure<WeatherApiOptions>

                //supply an obj of WeatherApiOptions (w 'weatherapi' section) as a service
              (builder.Configuration.GetSection("myweatherapi")); //added for IOptions<WeatherApiOptions> injection

            //load custom config file
            builder.Host.ConfigureAppConfiguration((hostingContext, config) => {
                config.AddJsonFile("CustomConfigFile.json", optional:true, reloadOnChange:true);
            });


            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.Map("/config", async context => {
                    await context.Response.WriteAsync(app.Configuration["mYkEY"] + "\n");

                    await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey"));

                    await context.Response.WriteAsync(app.Configuration.GetValue<int>("x", 10) + "\n" ); //10 è value fallback


                });  //MyKey la trovi in appsettings.json
            });

            app.MapControllers();

            app.Run();

            /*
             - terminal: 
                dotnet user-secrets init
                dotnet user-secrets set "myweatherapi:ClientID" "ClientiD from user secrets" 
                dotnet user-secrets set "myweatherapi:ClientSecret" "ClientSecret from user secrets"
                info: click dx su solution>manage user secrets
                $Env: myweatherapi__ClientID "ClientID from environment vars"
                $Env: myweatherapi__ClientSecret "ClientSecret from environment vars"
                dotnet run --no-launch-profile
                $Env: myweatherapi__ClientSecret "ClientSecret from environment vars UPDATED"
                dotnet run --no-launch-profile
             */
        }
    }
}
