namespace Codingteam.Site

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection

type Startup(env: IWebHostEnvironment) =
    let configuration =
        ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile(
            "appsettings.json",
            optional = false,
            reloadOnChange = true).Build()

    member __.Configure(app: IApplicationBuilder): unit =
        app.UseStaticFiles() |> ignore

        app.UseMvc (fun routes ->
            routes.MapRoute("default", "{controller=Home}/{action=Index}")
            |> ignore)
        |> ignore

    member __.ConfigureServices(services : IServiceCollection) : unit =
        services
            .AddOptions()
            .Configure<CtorSettings>(configuration.GetSection "CtorSettings")
            .AddSingleton(Clock.Default)
            .AddMvc(fun options -> options.EnableEndpointRouting <- false)
        |> ignore
        services.AddControllersWithViews().AddRazorRuntimeCompilation()
        |> ignore
