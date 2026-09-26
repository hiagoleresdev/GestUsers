# Estágio de Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["GestaoColaboradores.API/GestaoColaboradores.API.csproj", "GestaoColaboradores.API/"]
COPY ["GestaoColaboradores.Application/GestaoColaboradores.Application.csproj", "GestaoColaboradores.Application/"]
COPY ["GestaoColaboradores.Core/GestaoColaboradores.Core.csproj", "GestaoColaboradores.Core/"]
COPY ["GestaoColaboradores.Infraestructure/GestaoColaboradores.Infraestructure.csproj", "GestaoColaboradores.Infraestructure/"]

RUN dotnet restore "GestaoColaboradores.API/GestaoColaboradores.API.csproj"


COPY . .
WORKDIR "/src/GestaoColaboradores.API"
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://*:$PORT

ENTRYPOINT ["dotnet", "GestaoColaboradores.API.dll"]