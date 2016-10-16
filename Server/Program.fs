module Codingteam.Site.Program

open System.IO

open Microsoft.AspNetCore.Hosting

[<EntryPoint>]
let main _ =
    let root = Directory.GetCurrentDirectory()
    let host = WebHostBuilder().UseContentRoot(root).UseKestrel().UseStartup<Startup>().Build()
    host.Run()
    0
