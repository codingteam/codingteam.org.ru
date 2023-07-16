FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app

COPY Codingteam.Site/*.fsproj ./Codingteam.Site/
RUN dotnet restore Codingteam.Site

COPY Codingteam.Site ./Codingteam.Site/
RUN dotnet build --no-restore --configuration Release Codingteam.Site
RUN dotnet publish --no-build --configuration Release --output publish Codingteam.Site

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app

COPY --from=build-env /app/publish .

ENTRYPOINT ["dotnet", "Codingteam.Site.dll"]
EXPOSE 80
