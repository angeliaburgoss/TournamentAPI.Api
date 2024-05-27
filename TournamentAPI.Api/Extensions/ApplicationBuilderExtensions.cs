using TournamentAPI.Data;

namespace TournamentAPI.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task SeedDataAsync(this IApplicationBuilder app)
        {
           using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<TournamentApiContext>();

                try
                {
                    SeedData.Initialize(serviceProvider);
                }

                catch (Exception ex)
                {

                }
            } 

         
        }
    }
}
