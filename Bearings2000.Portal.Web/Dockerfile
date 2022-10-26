#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Bearings2000.Portal.Web.csproj", "."]
RUN dotnet restore "./Bearings2000.Portal.Web.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Bearings2000.Portal.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bearings2000.Portal.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bearings2000.Portal.Web.dll"]