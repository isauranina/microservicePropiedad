#para descarcar el aspnet
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#mi directorio de trabajo 
WORKDIR /app

#exponiendo los puertos
EXPOSE 5050

#para que construya la imagen en tiempo de ejecución
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
#para que copie los archivos del proyecto y restaure las dependencias.
COPY ["Propiedad.WebAPI/Propiedad.WebAPI.csproj", "Propiedad.WebAPI/"]
COPY ["Propiedad.Infrastructure/Propiedad.Infrastructure.csproj", "Propiedad.Infrastructure/"]
COPY ["Propiedad.Application/Propiedad.Application.csproj", "Propiedad.Application/"]
COPY ["Propiedad.Domain/Propiedad.Domain.csproj", "Propiedad.Domain/"]
RUN dotnet restore "Propiedad.WebAPI/Propiedad.WebAPI.csproj"
#Copia los archivos restantes y cree la aplicación.
COPY . .
WORKDIR "/src/Propiedad.WebAPI"
RUN dotnet build "Propiedad.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Propiedad.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

#Creando la imagen
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#levantar ejecutable del proyecto
ENTRYPOINT ["dotnet", "Propiedad.WebAPI.dll"]
#para crear la imagen  ejecutar/ docker image build -t nombre_imagen:1.0 .
#para crear contenedor  ejecutar/ docker run -d -p 8082:5053 --name nombre_contenedor nombre_imagen