module viewfiles.Main

open System
open Nancy.Hosting

type DemoApp () =
    inherit Nancy.NancyModule()
    do
        let Get = base.Get
        Get.["/"] <- fun parameters -> "Hello from F#/Nancy on Dokku-Alt!" :> obj

[<EntryPoint>]
let main args =
    let env_port = Environment.GetEnvironmentVariable("PORT")
    let port = if env_port = null then "5000" else env_port
    let uri = "0.0.0.0" + port
    let nancy_host = new Nancy.Hosting.Self.NancyHost(new Uri(uri))
    nancy_host.Start()
    printfn "listening on %s" uri
    while true do Console.ReadLine() |> ignore
    0
