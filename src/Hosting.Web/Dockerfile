﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Hosting.Web/*.csproj", "Hosting.Web/"]
COPY ["src/Domain.Entities/*.csproj", "Domain.Entities/"]
COPY ["src/Domain.Abstraction/*.csproj", "Domain.Abstraction/"]
COPY ["src/Application.Abstraction/*.csproj", "Application.Abstraction/"]
COPY ["src/Application.UseCases/*.csproj", "Application.UseCases/"]
COPY ["src/Application.Common/*.csproj", "Application.Common/"]
COPY ["src/Infrastructure/*.csproj", "Infrastructure/"]
COPY ["src/Infrastructure.Services/*.csproj", "Infrastructure.Services/"]
COPY ["src/Infrastructure.Repositories/*.csproj", "Infrastructure.Repositories/"]
COPY ["src/Infrastructure.Parser/*.csproj", "Infrastructure.Parser/"]
COPY ["src/Infrastructure.Scraper/*.csproj", "Infrastructure.Scraper/"]
COPY ["src/Infrastructure.Persistence/*.csproj", "Infrastructure.Persistence/"]
COPY ["src/Migrations/*.csproj", "Migrations/"]
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
