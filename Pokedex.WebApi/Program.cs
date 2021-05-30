using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Unity.Microsoft.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.IO;

namespace Pokedex.WebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityDiContainerProvider().GetContainer();

            WebHost
                .CreateDefaultBuilder()
                .UseUnityServiceProvider(container)
                .ConfigureServices(services =>
                {
                    services.AddMvc();
                    services.AddSwaggerGen(SwaggerDocsConfig);

                })
                .Configure(app =>
                {
                    app.UseRouting();
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });
                    app.UseCors();
                    app.UseSwagger();
                    app.UseSwaggerUI(c =>
                    {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pokedex_V1");
                    c.RoutePrefix = string.Empty;
                    });

                })
                .UseUrls("http://*:10500")
                .Build()
                .Run();
        }

        private static void SwaggerDocsConfig(SwaggerGenOptions genOptions)
        {
            genOptions.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Version = "v1",
                    Title = "PokedexApp",
                    Description = "A simple application that provides endpoints to manage pokemons",
                    //TermsOfService = new Uri("https://webapiexamples.project.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Sylwia Ignerowicz",
                        Email = "sylwiaignerowicz@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/sylwia-ignerowicz-2b3aa8129/")
                    },
                    //License = new OpenApiLicense
                    //{
                    //    Name = "Use some license",
                    //    Url = new Uri("https://webapiexamples.project.com/license")
                    //}
                });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            genOptions.IncludeXmlComments(xmlPath);
        }
    }
}
