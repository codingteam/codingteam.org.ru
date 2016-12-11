namespace Ctor.Database

open Microsoft.EntityFrameworkCore

type Context(options: DbContextOptions<Context>) =
    inherit DbContext(options)

    member val Logs : DbSet<Log> = null with get, set
