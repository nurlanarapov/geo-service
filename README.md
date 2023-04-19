# geo-service

## run steps

1. set settings appsettings.json
   set token to line access_token in file settings appsettings.json
   token from https://dadata.ru
2. run docker container
   docker build -t geo-service .
   docker run -p 81:80 -d geo-service

Swagger
http://localhost:81/swagger/index.html