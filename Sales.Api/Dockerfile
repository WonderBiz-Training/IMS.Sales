#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Sales.Api/Sales.Api.csproj", "Sales.Api/"]
COPY ["Sales.Application/Sales.Application.csproj", "Sales.Application/"]
COPY ["Sales.Domain/Sales.Domain.csproj", "Sales.Domain/"]
COPY ["Sales.Infrastructure/Sales.Infrastructure.csproj", "Sales.Infrastructure/"]
RUN dotnet restore "./Sales.Api/Sales.Api.csproj"
COPY . .
WORKDIR "/src/Sales.Api"
RUN dotnet build "./Sales.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Sales.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sales.Api.dll"]