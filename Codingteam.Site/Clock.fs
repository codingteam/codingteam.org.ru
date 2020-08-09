namespace Codingteam.Site

open System

type Clock(getter: unit -> DateTime) =
    member _.GetUtcDateTime(): DateTime = getter()
    static member Default: Clock = Clock(fun () -> DateTime.UtcNow)
