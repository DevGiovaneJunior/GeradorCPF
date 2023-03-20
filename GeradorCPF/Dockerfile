#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GeradorCPF/GeradorCPF.csproj", "GeradorCPF/"]
RUN dotnet restore "GeradorCPF/GeradorCPF.csproj"
COPY . .
WORKDIR "/src/GeradorCPF"
RUN dotnet build "GeradorCPF.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GeradorCPF.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeradorCPF.dll"]