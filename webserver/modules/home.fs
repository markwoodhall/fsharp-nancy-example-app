namespace webserver

type HomeApp () =
    inherit Nancy.NancyModule()
    do
        let Get = base.Get
        Get.["/"] <- fun parameters -> "Hello from F#/Nancy on Dokku-Alt!" :> obj

