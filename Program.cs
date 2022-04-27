using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using PhotoGalleryMail.Services;
using Blazored.SessionStorage;

namespace PhotoGalleryMail
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddBlazoredSessionStorage();
            

            builder.Services.AddOidcAuthentication(options =>
            {
                // Configure your authentication provider options here.
                // For more information, see https://aka.ms/blazor-standalone-auth
                // builder.Configuration.Bind("oidc_google", options.ProviderOptions); 
#if DEBUG
                builder.Configuration.Bind("oidc_localhost", options.ProviderOptions);
                options.UserOptions.RoleClaim = "role";  //in order to read the role claim and applie the AutorizeView Roles atribute 

#else
                 builder.Configuration.Bind("oidc_PhotoGalleryMailIdentityServer", options.ProviderOptions);
                  options.UserOptions.RoleClaim = "role";
#endif



            });


            if (builder.HostEnvironment.IsStaging())
            {
                
            };

            builder.Services.AddHttpClient();

#if DEBUG
            // Register a named HttpClient here for the API
            builder.Services.AddHttpClient("PhotoGalleryMailCoreAPI", o =>
            {
                o.BaseAddress = new Uri("https://localhost:6001");
               

            }).AddHttpMessageHandler(sp =>
            {
               
                var handler = sp.GetService<AuthorizationMessageHandler>()
                    .ConfigureHandler(
                        authorizedUrls: new[] { "https://localhost:6001" },
                        scopes: new[] { "PhotoGalleryMail_api" }
                        );
                
                return handler;
            });


#else
            builder.Services.AddHttpClient("PhotoGalleryMailCoreAPI", o => {
                o.BaseAddress = new Uri("https://api.PhotoGalleryMail.photography");

            }).AddHttpMessageHandler(sp =>
            {
                var handler = sp.GetService<AuthorizationMessageHandler>()
                    .ConfigureHandler(
                        authorizedUrls: new[] { "https://api.PhotoGalleryMail.photography" },
                        scopes: new[] { "PhotoGalleryMail_api" }
                        );
                return handler;
            });
#endif


            builder.Services.AddScoped<ApiCalls>();
            builder.Services.AddScoped<EmailSender>();
            builder.Services.AddScoped<GlobalComponentValues>();

       

            //builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("PhotoGalleryMailCoreAPI"));

            await builder.Build().RunAsync();
        }
    }
}
