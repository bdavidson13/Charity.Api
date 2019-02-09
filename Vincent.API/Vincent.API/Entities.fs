namespace EFCore.Model

open System
open System.ComponentModel.DataAnnotations.Schema

[<CLIMutable>]
type UserAccount =
    {
        id: int
        username: string
        email: string
        password: string
        createdate: DateTime
    }
