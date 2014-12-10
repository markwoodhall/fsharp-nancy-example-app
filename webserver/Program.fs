module viewfiles.Main

open System
open Nancy.Hosting

type DemoApp () =
    inherit Nancy.NancyModule()
    do
        let Get = base.Get
        Get.["/"] <- fun parameters -> "Hello from F#/Nancy on Heroku!" :> obj

[<EntryPoint>]
let main args = 
    let env_port = Environment.GetEnvironmentVariable("PORT")
    let port = if env_port = null then "5000" else env_port

    let nancy_host = new Nancy.Hosting.Self.NancyHost(new Uri("http://localhost:" + port))
    nancy_host.Start()
    while true do Console.ReadLine() |> ignore
    0    