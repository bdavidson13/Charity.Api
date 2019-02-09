namespace EFCore.DataAccess

open EFCore.DataAccess
open EFCore.Model
open System.Linq
open Microsoft.EntityFrameworkCore

module UserAccountsRepository =
    let getUserAccount (context: CharityContext) id =
        query {
            for userAccount in context.UserAccount do
                where (userAccount.id = id)
                select userAccount 
                exactlyOne
        } |> (fun x -> if box x = null then None else Some x)

    let addUserAccountAsync (context: CharityContext) (entity: UserAccount) =
        async {
            context.UserAccount.AddAsync(entity) |> Async.AwaitTask |> ignore
            let! _ = context.SaveChangesAsync true |> Async.AwaitTask
            return entity
        }    

    let addUserAccount (context: CharityContext) (entity: UserAccount) =
        context.UserAccount.Add(entity) |> ignore
        context.SaveChanges true |> ignore

    let updateUserAccount (context: CharityContext) (entity: UserAccount) = 
        let currentEntry = context.UserAccount.Find(entity.id)
        context.Entry(currentEntry).CurrentValues.SetValues(entity)
        context.SaveChanges true |> ignore

    let deleteUserAccount (context: CharityContext) (entity: UserAccount) = 
        context.UserAccount.Remove entity |> ignore
        context.SaveChanges true |> ignore
