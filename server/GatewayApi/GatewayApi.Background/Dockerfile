#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["GatewayApi.Background/GatewayApi.Background.csproj", "GatewayApi.Background/"]
RUN dotnet restore "GatewayApi.Background/GatewayApi.Background.csproj"
COPY . .
WORKDIR "/src/GatewayApi.Background"
RUN dotnet build "GatewayApi.Background.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GatewayApi.Background.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GatewayApi.Background.dll"]