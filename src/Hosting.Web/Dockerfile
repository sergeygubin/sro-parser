FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Hosting.Web/*.csproj", "Hosting.Web/"]
COPY ["src/Application.Abstraction/*.csproj", "Application.Abstraction/"]
COPY ["src/Application.UseCases/*.csproj", "Application.UseCases/"]
COPY ["src/Application.Common/*.csproj", "Application.Common/"]
COPY ["src/Domain.Entities/*.csproj", "Domain.Entities/"]
COPY ["src/Infrastructure/*.csproj", "Infrastructure/"]
COPY ["src/Infrastructure.Services/*.csproj", "Infrastructure.Services/"]
COPY ["src/Infrastructure.Parser/*.csproj", "Infrastructure.Parser/"]
COPY ["src/Infrastructure.Scraper/*.csproj", "Infrastructure.Scraper/"]
RUN dotnet restore "Hosting.Web/Hosting.Web.csproj"
COPY src/ .

WORKDIR Hosting.Web
RUN dotnet build "Hosting.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hosting.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hosting.Web.dll"]
