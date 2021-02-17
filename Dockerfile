FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine as build
WORKDIR /src

EXPOSE 80

COPY *.sln .
COPY Docker.Domain/*.csproj ./Docker.Domain/
COPY Docker.Infra.Data/*.csproj ./Docker.Infra.Data/
COPY Docker.Application/*.csproj ./Docker.Application/
COPY Docker.Api/*.csproj ./Docker.Api/

RUN dotnet restore

COPY Docker.Domain/. ./Docker.Domain/
COPY Docker.Infra.Data/. ./Docker.Infra.Data/
COPY Docker.Application/. ./Docker.Application/
COPY Docker.Api/. ./Docker.Api/

WORKDIR /src/Docker.Api
RUN dotnet publish -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine
WORKDIR /app
COPY --from=build /src/Docker.Api/out ./

RUN apk add --no-cache tzdata
ENV TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

ENTRYPOINT [ "dotnet", "Docker.Api.dll" ]