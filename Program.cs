namespace _8_aspnetcore_configuration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.Map("/", async context => {
                    await context.Response.WriteAsync(app.Configuration["mYkEY"] + "\n");

                    await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey"));

                    await context.Response.WriteAsync(app.Configuration.GetValue<int>("x", 10) + "\n" ); //10 è value fallback


                });  //MyKey la trovi in appsettings.json
            });

            app.MapControllers();

            app.Run();
        }
    }
}
