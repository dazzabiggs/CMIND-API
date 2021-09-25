#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim-arm32v7 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim-arm32v7 AS build
#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["KB.CMIND.API.CMDetails.csproj", "KB.CMIND.API.CMDetails/"]
COPY ["nuget.config", "KB.CMIND.API.CMDetails/"]
#COPY ./KB.CMIND.API.CMDetails/nuget.config ./
RUN dotnet restore "KB.CMIND.API.CMDetails/KB.CMIND.API.CMDetails.csproj" --configfile KB.CMIND.API.CMDetails/nuget.config
WORKDIR "/src/KB.CMIND.API.CMDetails"
COPY . .
RUN dotnet build "KB.CMIND.API.CMDetails.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KB.CMIND.API.CMDetails.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KB.CMIND.API.CMDetails.dll"]