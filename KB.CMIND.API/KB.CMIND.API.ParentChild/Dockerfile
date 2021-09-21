#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["KB.CMIND.API.ParentChild/KB.CMIND.API.ParentChild.csproj", "KB.CMIND.API.ParentChild/"]
COPY ./KB.CMIND.API.CMDetails/nuget.config ./
RUN dotnet restore "KB.CMIND.API.ParentChild/KB.CMIND.API.ParentChild.csproj" --configfile ./nuget.config
COPY . .
WORKDIR "/src/KB.CMIND.API.ParentChild"
RUN dotnet build "KB.CMIND.API.ParentChild.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KB.CMIND.API.ParentChild.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KB.CMIND.API.ParentChild.dll"]