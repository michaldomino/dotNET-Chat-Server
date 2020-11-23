FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["dotNET-Chat-Server.csproj", ""]
RUN dotnet restore "./dotNET-Chat-Server.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "dotNET-Chat-Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotNET-Chat-Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotNET-Chat-Server.dll"]