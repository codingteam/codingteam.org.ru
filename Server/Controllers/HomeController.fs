namespace Codingteam.Site.Controllers

open System
open System.Globalization

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Options

open Codingteam.Site
open Server

type HomeController(options: IOptions<CtorSettings>, clock: Clock) =
    inherit Controller()

    let config = options.Value
    let getLogUrl (date : DateTime) =
        let dateString = date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture)
        sprintf "%s/%s.html" config.LogUrlPrefix dateString
    let logTimezone = TimeSpan.FromHours <| double config.LogTimeZoneOffset
    let getTodayLogUrl () = getLogUrl <| clock.GetUtcDateTime() + logTimezone

    member this.Index() =
        this.ViewData.["LogUrl"] <- getTodayLogUrl ()
        this.View()

    [<Route("resources")>]
    member this.Resources() =
        this.View()
