# Use the official .NET 8.0 runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the .NET 8.0 SDK for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CarInfoApiApp.csproj", "."]
RUN dotnet restore "CarInfoApiApp.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "CarInfoApiApp.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "CarInfoApiApp.csproj" -c Release -o /app/publish

# Final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarInfoApiApp.dll"]
