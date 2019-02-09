namespace EFCore.DataAccess

open System
open Microsoft.EntityFrameworkCore
open Microsoft.EntityFrameworkCore.Storage.ValueConversion
open EFCore.Model
open System.Collections.ObjectModel

type CharityContext =
    inherit DbContext

    new() = { inherit DbContext() }
    new(options : DbContextOptions<CharityContext>) = { inherit DbContext(options) }

    override __.OnModelCreating modelBuilder =
        let expr = modelBuilder.Entity<UserAccount>().HasKey(fun acc -> (acc.id) :> obj)
        modelBuilder.Entity<UserAccount>().Property(fun e -> e.id).ValueGeneratedOnAdd() |> ignore



    [<DefaultValue>]
    val mutable UserAccount : DbSet<UserAccount>
    member x.useraccount
        with get () = x.UserAccount
        and set v = x.UserAccount <- v
