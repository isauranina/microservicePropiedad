#para descarcar el SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base


#mi directorio de trabajo
WORKDIR /app

#EXPOSE 8082
#EXPOSE 5003

#para que copie los archivos del proyecto y restaure las dependencias.
COPY *.csproj ./
RUN dotnet restore

#Copia los archivos restantes y cree la aplicación.
COPY . ./
RUN dotnet publish -c Release -o out

#para que construya la imagen en tiempo de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime-env

WORKDIR /app
COPY --from=base /app/out .

#estableciendo punto de entrada
ENTRYPOINT ["dotnet", "MicroservicePropiedad.dll"]

#para crear la imagen del contenedor ejecutar/ docker image build -t dotnet/demoServive .