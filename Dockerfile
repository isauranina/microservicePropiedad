#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Propiedad.WebAPI/Propiedad.WebAPI.csproj", "Propiedad.WebAPI/"]
COPY ["Propiedad.Infrastructure/Propiedad.Infrastructure.csproj", "Propiedad.Infrastructure/"]
COPY ["Propiedad.Application/Propiedad.Application.csproj", "Propiedad.Application/"]
COPY ["Propiedad.Domain/Propiedad.Domain.csproj", "Propiedad.Domain/"]
RUN dotnet restore "Propiedad.WebAPI/Propiedad.WebAPI.csproj"
COPY . .
WORKDIR "/src/Propiedad.WebAPI"
RUN dotnet build "Propiedad.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Propiedad.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Propiedad.WebAPI.dll"]