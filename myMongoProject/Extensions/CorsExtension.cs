using Microsoft.Extensions.DependencyInjection;

namespace myMongoProject.Extensions
{
    public static class CorsExtension
    {
        public static void AdicionarCors(
            this IServiceCollection sc)
        {
            //sc.AddCors(options =>
            //{
            //   options.AddDefaultPolicy(builder =>
            //        builder.SetIsOriginAllowed(_ => true)
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials());
            //});

            sc.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                   {
                        builder.WithOrigins(                       
                            "http://localhost:4201",
                            "http://localhost:5095/"                          
                            )
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .AllowAnyMethod();
                    });
            });

        }
    }
}
