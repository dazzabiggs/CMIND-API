#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim-arm32v7 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim-arm32v7 AS build
WORKDIR /src
COPY ["KB.CMIND.API.Incidents.csproj", "KB.CMIND.API.Incidents/"]
COPY ["nuget.config", "KB.CMIND.API.Incidents/"]
#COPY ./KB.CMIND.API.CMDetails/nuget.config ./
RUN dotnet restore "KB.CMIND.API.Incidents/KB.CMIND.API.Incidents.csproj" --configfile KB.CMIND.API.Incidents/nuget.config
WORKDIR "/src/KB.CMIND.API.Incidents"
COPY . .

RUN dotnet build "KB.CMIND.API.Incidents.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KB.CMIND.API.Incidents.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KB.CMIND.API.Incidents.dll"]