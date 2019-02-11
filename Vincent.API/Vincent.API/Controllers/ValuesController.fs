namespace Vincent.API.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open EFCore.Model
open CompostionRoot
open Microsoft.AspNetCore.Mvc

[<Route("api/[controller]")>]
[<ApiController>]
type ValuesController () =
    inherit ControllerBase()

    [<HttpGet>]
    member this.Get() =
        let values = [|"value1"; "value2"|]
        ActionResult<string[]>(values)

    [<HttpGet("{id}")>]
    member this.Get(id:int) =
        let value = "value"
        //let newUser = {id=1; username = "CMDUser"; email = "user@fSharp.com"; password = "test"; createdate = DateTime.Now}
        //addUserAccount newUser
        ActionResult<string>(value)

    [<HttpPost>]
    [<Route("api/values/test")>]
    member this.Post([<FromBody>] user:UserAccount) =
        addUserAccount user
        ActionResult<string>("success")

    [<HttpPut("{id}")>]
    member this.Put(id:int, [<FromBody>] value:string ) =
        ()

    [<HttpDelete("{id}")>]
    member this.Delete(id:int) =
        ()
