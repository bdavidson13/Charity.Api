module CompostionRoot

open EFCore.DataAccess
open Microsoft.EntityFrameworkCore

let configurePostgresServerContext =
    (fun() ->
        let optionBuilder = new DbContextOptionsBuilder<CharityContext>();
        optionBuilder.UseNpgsql("User ID=root;Password=sudo;Server=localhost;Port=5432;Database=charity;Pooling=true;") |>ignore
        new CharityContext(optionBuilder.Options)
    )

let getContext = configurePostgresServerContext()
let getUserAccount  = UserAccountsRepository.getUserAccount getContext
let addUserAccount = UserAccountsRepository.addUserAccount getContext
let getNextUserId = UserAccountsRepository.getNewUserId getContext
let addUserAccountAsync = UserAccountsRepository.addUserAccountAsync getContext
let updateUserAccount = UserAccountsRepository.updateUserAccount getContext
let deleteUserAccount = UserAccountsRepository.deleteUserAccount getContext