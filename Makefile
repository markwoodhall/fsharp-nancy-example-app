run:
	mono webserver/bin/Debug/webserver.exe

deploy:
	git push origin
	git push dokku
