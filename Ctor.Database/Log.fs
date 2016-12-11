namespace Ctor.Database

open System

type Log() =
    member val Id = 0L with get, set
    member val Conference : string = null  with get, set
    member val Sender : string = null with get, set
    member val DateTime = Unchecked.defaultof<DateTime> with get, set
    member val Text : string = null with get, set
