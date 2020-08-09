module Tests

open System
open System.Globalization
open Codingteam.Site.Controllers
open Microsoft.Extensions.Options
open Xunit

open Codingteam.Site
open Server

let options() =
    { new IOptions<CtorSettings> with
        member _.Value = CtorSettings(LogTimeZoneOffset = 3) }

[<Fact>]
let ``HomeController should properly determine the log url``(): unit =
    let clock = Clock(fun () -> DateTime.ParseExact(
                                    "2020-08-08T21:47:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture
                                )
                     )
    use controller = new HomeController(options(), clock)
    let result = controller.Index()
    Assert.Equal("/2020/08/09.html", result.ViewData.["LogUrl"] :?> string)
