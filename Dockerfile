#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build

WORKDIR /src

COPY . .

RUN dotnet restore

RUN dotnet build --no-restore -c Release

FROM build AS publish

RUN dotnet publish /src/src/App.Api --no-restore --no-build -c Release -o /app

FROM base AS final

ARG Version

EXPOSE 7030

WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "App.Api.dll"]