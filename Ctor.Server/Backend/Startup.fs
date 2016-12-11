namespace Codingteam.Site

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.EntityFrameworkCore
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging

open Ctor.Database

type Startup(env : IHostingEnvironment) =
    let configuration =
        ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile(
            "appsettings.json",
            optional = false,
            reloadOnChange = true).Build()

    member __.Configure(app : IApplicationBuilder, loggerFactory : ILoggerFactory) : unit =
        let migrateDb() =
            use context = app.ApplicationServices.GetService<Context>()
            ignore <| context.Database.EnsureCreated()
            context.Database.Migrate()

        ignore <| loggerFactory.AddConsole(configuration.GetSection "Logging")
            .AddDebug()

        ignore <| app.UseStaticFiles()
            .UseMvc (fun routes ->
                ignore <| routes.MapRoute("default", "{controller=Home}/{action=Index}"))

        migrateDb()

    member __.ConfigureServices(services : IServiceCollection) : unit =
        let configureDb (db : DbContextOptionsBuilder) =
            ignore <| db.UseSqlite(
                configuration.GetConnectionString("Ctor.Database"),
                fun b -> ignore <| b.MigrationsAssembly("Ctor.Database.Migrations"))

        ignore <| services.AddOptions()
            .Configure<CtorSettings>(configuration.GetSection "CtorSettings")
            .AddDbContext<Context>(configureDb)
            .AddMvc()
