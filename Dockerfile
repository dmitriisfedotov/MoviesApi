FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
COPY /MoviesApi.zip /app/MoviesApiCopy
ENTRYPOINT ["dotnet", "YourApp.dll"]
