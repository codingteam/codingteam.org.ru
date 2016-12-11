namespace Ctor.Database

open System

open Microsoft.EntityFrameworkCore
open System.Collections.Generic

type Log() =
    member val Id = 0L with get, set
    member val Conference : string = null  with get, set
    member val Sender : string = null with get, set
    member val DateTime = Unchecked.defaultof<DateTime> with get, set
    member val Text : string = null with get, set

type Context() =
    inherit DbContext()

    member val Logs : DbSet<Log> = null with get, set

    override __.OnConfiguring(optionsBuilder : DbContextOptionsBuilder) : unit =
        ignore <| optionsBuilder.UseSqlite(
            "Filename=./database.db",
            (fun b -> ignore <| b.MigrationsAssembly("Ctor.Database.Migrations")))
