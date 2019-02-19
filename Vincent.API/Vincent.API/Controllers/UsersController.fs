namespace Vincent.API.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open EFCore.Model
open CompostionRoot
open Microsoft.AspNetCore.Mvc
open Newtonsoft.Json

[<Route("api/[controller]")>]
[<ApiController>]
type UsersController () =
    inherit ControllerBase()

    [<HttpGet>]
    member this.Get() = 
        let newUser = { username = "CMDUser"; email = "user@fSharp.com"; password = "test"; createdate = DateTime.Now}
        addUserAccount newUser
        ActionResult<string>("Successfully go to users controller")

    [<HttpGet("{id}")>]
    member this.Get(id:int) =
    //TODO need to put error handling in. What if id give doesn't exist
        let user = getUserAccount id
        ActionResult<string>(JsonConvert.SerializeObject user)
    
    [<HttpPost>]
    member this.Post([<FromBody>] user:UserAccount) =
        //let newUser = {id=1; username = "CMDUser"; email = "user@fSharp.com"; password = "test"; createdate = DateTime.Now}
        addUserAccount user
        ActionResult<string>("success")
    
    [<HttpPut("{id}")>]
    member this.Put(id:int, [<FromBody>] value:string ) =
        ()

    [<HttpDelete("{id}")>]
    member this.Delete(id:int) =
        ()