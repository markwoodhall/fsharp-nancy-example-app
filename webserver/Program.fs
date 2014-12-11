module webserver.main

open System
open Nancy.Hosting

let getUrl port = 
    let env_port = Environment.GetEnvironmentVariable("PORT")
    let port = if env_port = null then "5000" else env_port
    "http://localhost:" + port

let createLocalHost url =
    let uri = Uri url
    new Nancy.Hosting.Self.NancyHost(uri)

[<EntryPoint>]
let main args =
    let url = getUrl()
    let host = url |> createLocalHost 
    host.Start()
    printfn "Listening on %s" url
    while true do Console.ReadLine() |> ignore
    0
