namespace Codingteam.Site.Controllers

open System
open System.Globalization

open Microsoft.AspNetCore.Mvc

type HomeController() =
    inherit Controller()

    let logUrlPrefix = "http://0xd34df00d.me/logs/chat/codingteam@conference.jabber.ru"
    let getLogUrl (date : DateTime) =
        let dateString = date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture)
        sprintf "%s/%s.html" logUrlPrefix dateString
    let logTimezone = TimeSpan.FromHours 4.0
    let getTodayLogUrl () = getLogUrl <| DateTime.UtcNow.Date + logTimezone

    member this.Index() =
        this.ViewData.["LogUrl"] <- getTodayLogUrl ()
        this.View()

    member this.Resources() =
        this.View()
