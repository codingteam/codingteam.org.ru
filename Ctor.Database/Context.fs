namespace Ctor.Database

open System

open Microsoft.EntityFrameworkCore
open System.Collections.Generic

type Log = {
    Conference : string
    Sender : string
    DateTime : DateTime
    Text : string
}

type Context() =
    inherit DbContext()

    member val Logs : DbSet<Log> = null with get, set

    override __.OnConfiguring(optionsBuilder : DbContextOptionsBuilder) : unit =
        ignore <| optionsBuilder.UseSqlite("Filename=./database.db")
