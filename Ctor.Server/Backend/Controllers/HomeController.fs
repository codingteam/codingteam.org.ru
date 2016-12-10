namespace Codingteam.Site.Controllers

open System
open System.Globalization

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Options

open Codingteam.Site

type HomeController(options : IOptions<CtorSettings>) =
    inherit Controller()

    let config = options.Value
    let getLogUrl (date : DateTime) =
        let dateString = date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture)
        sprintf "%s/%s.html" config.LogUrlPrefix dateString
    let logTimezone = TimeSpan.FromHours <| double config.LogTimeZoneOffset
    let getTodayLogUrl () = getLogUrl <| DateTime.UtcNow.Date + logTimezone

    member this.Index() =
        this.ViewData.["LogUrl"] <- getTodayLogUrl ()
        this.View()

    [<Route("resources")>]
    member this.Resources() =
        this.View()
