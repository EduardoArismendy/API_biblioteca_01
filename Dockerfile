# ============================
# ETAPA 1: Build
# ============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file
COPY ["API_Biblioteca_01/API_Biblioteca_01.csproj", "./"]
RUN dotnet restore

# Copy the rest of the source code
COPY ["API_Biblioteca_01/.", "./"]
RUN dotnet build -c Release -o /app/build

# Publish the application
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose the port and set the URL
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "API_Biblioteca_01.dll"]