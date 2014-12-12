module webserver.main

open System
open Nancy.Hosting

let getUrl port = 
    let env_port = Environment.GetEnvironmentVariable("PORT")
    "http://localhost:" + if env_port = null then string port else env_port

let createLocalHost url =
    let uri = Uri url
    new Nancy.Hosting.Self.NancyHost(uri)

[<EntryPoint>]
let main args =
    let url = getUrl 5000
    let host = url |> createLocalHost 
    host.Start()
    printfn "Listening on %s" url
    while true do Console.ReadLine() |> ignore
    0
