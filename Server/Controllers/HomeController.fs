namespace Codingteam.Site.Controllers

open Microsoft.AspNetCore.Mvc

type HomeController() =
    inherit Controller()

    member this.Index() =
        this.View()
