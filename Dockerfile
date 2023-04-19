FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

COPY . ./
ENV ASPNETCORE_ENVIRONMENT Development
RUN dotnet restore

RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /out
COPY --from=build-env /out .

EXPOSE 80
ENTRYPOINT ["dotnet", "geo-service.dll", "--environment=Development"]