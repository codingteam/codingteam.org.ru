namespace Codingteam.Site

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging

type Startup(env : IHostingEnvironment) =
    let configuration =
        ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile(
            "appsettings.json",
            optional = false,
            reloadOnChange = true).Build()

    member __.Configure(app : IApplicationBuilder, loggerFactory : ILoggerFactory) : unit =
        loggerFactory.AddConsole(configuration.GetSection "Logging") |> ignore
        loggerFactory.AddDebug() |> ignore

        app.UseStaticFiles() |> ignore

        app.UseMvc (fun routes ->
            routes.MapRoute("default", "{controller=Home}/{action=Index}")
            |> ignore)
        |> ignore

    member __.ConfigureServices(services : IServiceCollection) : unit =
        services.AddMvc()
        |> ignore
