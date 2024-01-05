FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080


FROM mcr.microsoft.com/dotnet/sdk:8.0-focal AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /source
COPY ["AdriansApp/AdriansApp.csproj", "AdriansApp/"]
RUN dotnet restore "./AdriansApp/./AdriansApp.csproj" --disable-parallel
COPY . .
WORKDIR "/src/AdriansApp"
RUN dotnet build "./AdriansApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AdriansApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdriansApp.dll"]