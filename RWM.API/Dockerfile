FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RWM.API/RWM.API.csproj", "RWM.API/"]
COPY ["RWM.Data/RWM.Data.csproj", "RWM.Data/"]
COPY ["RWM.Services/RWM.Services.csproj", "RWM.Services/"]
RUN dotnet restore "RWM.API/RWM.API.csproj"
COPY . .
WORKDIR "/src/RWM.API"
RUN dotnet build "RWM.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RWM.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RWM.API.dll"]