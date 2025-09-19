# MiniPIM - Gestor de Tiendas

Este proyecto es un gestor de tiendas desarrollado en **C# .NET Framework 4.8**, utilizando **Entity Framework** y **Microsoft SQL Server 2014** como base de datos.

---

## Requisitos previos

- [Docker](https://docs.docker.com/get-docker/)  
- [Docker Compose](https://docs.docker.com/compose/install/)  
- Microsoft SQL Server no es necesario instalar localmente, ya que se despliega mediante Docker.
- Opcional: **C# .NET Framework 4.8** y **Visual Studio** con **Entity Framework** si deseas ejecutar el proyecto directamente desde el IDE.


---

## Levantar la base de datos con Docker Compose

1. Navega a la carpeta del proyecto donde se encuentra el archivo **docker-compose.yml**.
2. Ejecuta el comando para levantar los contenedores:  

`docker compose up --build`

Esto creará y levantará un contenedor con **SQL Server** y cargará la base de datos inicial del proyecto.

> ⚠️ Si el puerto 1433 ya está en uso en tu máquina, cambia el puerto externo en **docker-compose.yml**.

---

## Ejecutar la aplicación

### Opción 1: Ejecutable

1. Una vez que la base de datos esté levantada y lista, navega a:  

`bin\Release\MiniPIM.exe`

2. Ejecuta el archivo **MiniPIM.exe**.  
3. Podrás acceder a la aplicación y gestionar los datos de las tiendas.

### Opción 2: Desde Visual Studio

1. Abre el proyecto usando el archivo **MiniPIM.sln**.  
2. Asegúrate de tener instalado **.NET Framework 4.8** y **Entity Framework**.  
3. Ejecuta el proyecto desde Visual Studio directamente.  

> Nota: La base de datos debe estar levantada (ya sea mediante Docker o instalada localmente) antes de ejecutar la aplicación.


---

## Nota

- La aplicación **requiere que la base de datos esté levantada** antes de ejecutarse.  
- El contenedor de SQL Server contiene la base de datos inicial con todos los datos necesarios.