namespace Codingteam.Site

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection

type Startup(env : IHostingEnvironment) =
    member __.Configure (app : IApplicationBuilder) = ()
    member __.ConfigureServices (services : IServiceCollection) = ()
