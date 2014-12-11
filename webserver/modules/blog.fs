namespace webserver

type BlogApp () =
    inherit Nancy.NancyModule()
    do
        let Get = base.Get
        Get.["/blog"] <- fun parameters -> "My Blog" :> obj

