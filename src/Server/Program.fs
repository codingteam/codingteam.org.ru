module Codingteam.Site.Program

open Microsoft.AspNetCore.Hosting

[<EntryPoint>]
let main _ =
    let host = WebHostBuilder().UseKestrel().UseStartup<Startup>().Build()
    host.Run()
    0
