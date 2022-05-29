### Proyecto Newsan
- Projecto - Todo

## Instalar
- Net Core 6
- SQL Server

## Configuracion
- editar con appsettings.json con las credenciales de la db. Por defecto esta la mia.
- actualizar la conexion en el archivo Startup.cs
- importar la base de dato Newsan_todo ubicada en db 

## Correr Servidor
Desde la consola de comandos, posicionarse en la carpeta TodoApi.
Esta carpeta tiene todo el proyecto de la API.
Compilar: dotnet build
Levantar Servidor: dotnet run
Parar Servidor: cntrl + c

## Servidor levantado
url: https://localhost:7168
(Levanta el index.html) -- Aca esta la vista creada con html, css, javascript, bootstrap.

url: https://localhost:7168/api/tareas API

## Testeo
- Con postman, levantas la api y podes probarla.

Tener en cuenta los parametros

-Para que traiga todos el listado 
    description: nada
    state: nada

-Para que filtre, poner datos en los parametros. Ej: 

    description: hola (filtra todas las tareas donde en el campo description este el string "hola")

    state: pendiente (filtra todas las tareas que el state tenga pendiente.)

    
