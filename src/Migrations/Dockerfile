FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Migrations/Migrations.csproj", "Migrations/"]
RUN dotnet restore "src/Migrations/Migrations.csproj"
COPY . .
WORKDIR "/src/Migrations"
RUN dotnet build "Migrations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Migrations.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Migrations.dll"]
