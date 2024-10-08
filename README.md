# ASP.NET Core Grundkurs

Kurs Repository zum Kurs ASP.NET Core Grundkurs der ppedv AG.

## M001 | ASP.NET Überblick

	-   [x] Historie
	-   [x] Projekte und Projektmappen
	-   [x] ASP.Net Core Empty: Hello, World

## M002 | Konfiguration

	-   [x] IOC mittels Dependency Injection
	-   [x] Aufbau appsettings.json
	-   [x] Logging in ASP.NET Core

## M003 | Model View Controller (MVC)

	-	[x] Overview
	-	[x] Links setzen
	-	[x] Details

## M004 | Razor Pages

	-	[x] Overview
	-	[x] Links setzen
	-	[x] Details

## M005 | Forms und Validierung

	-	[x] ViewModel Mapping
	-	[x] Form Post
	-	[x] ModelState

## M006 | FileServer erstellen

	-	[x] Static Files und Directory Browser
	-   [x] File Provider und Dateizugriff
	-   [ ] Middleware

## M006 | HttpClient verwenden

	-   [ ] Konfiguration auslesen
	-   [ ] HttpClient verwenden

## M008 | Weitere Themen

	-   [ ] HttpContext
	-   [ ] Cookie Handling
	-   [ ] Server Caching

## M010 | Entity Framework

<!--
    - Microsoft.EntityFrameworkCore.SqlServer
    - Microsoft.EntityFrameworkCore.Tools
-->

	-   [ ] O/R Mapping Framework EFCore
	-   [ ] Code First Ansatz (Entites + DbContext)
	-   [ ] DB Migration

```bash
	dotnet tool install --global dotnet-ef
	dotnet ef migrations add <script-name> --project <BusinessLogic>
	dotnet ef database update --project <BusinessLogic>
	dotnet watch run
```

-   [ ] Controller mit Scaffolding erstellen (Microsoft.EntityFrameworkCore.Design)
<!--
	```bash
	dotnet tool install -g dotnet-aspnet-codegenerator

	dotnet-aspnet-codegenerator controller -name YourModelController -m YourModel -dc NorthwindDbContext -outDir Controllers -udl
	```
-->

	-   [ ] DB First Ansatz
	-   [ ] [Northwind DB](https://github.com/microsoft/sql-server-samples/blob/master/samples/databases/northwind-pubs/instnwnd.sql)
	-   [ ] LocalDB

<!--
	```bash
		SqlLocalDB create <InstanceName>
		SqlLocalDB start <InstanceName>
		SqlLocalDB info <InstanceName>

		-- Datenbank erstellen
		sqlcmd -S "(localdb)\mssqllocaldb" -Q "CREATE DATABASE NORTHWND;"

		-- Script ausführen
		sqlcmd -S "(localdb)\mssqllocaldb" -d NORTHWND -i instnwnd.sql

		-- Ausführung überprüfen
		sqlcmd -S "(localdb)\mssqllocaldb" -d NORTHWND -Q "SELECT * FROM sys.tables;"
	```
-->
