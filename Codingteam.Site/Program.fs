module Codingteam.Site.Program

open System.IO

open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Logging

[<EntryPoint>]
let main _ =
    let root = Directory.GetCurrentDirectory()
    let host = WebHostBuilder()
                   .UseContentRoot(root)
                   .UseKestrel()
                   .ConfigureLogging(fun loggingBuilder ->
                       loggingBuilder.AddConsole().AddDebug()
                       |> ignore)
                   .UseStartup<Startup>().Build()
    host.Run()
    0
