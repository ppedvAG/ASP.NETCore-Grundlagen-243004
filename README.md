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
	-	[x] Form Post & Validierung
	-	[x] ModelState

## M006 | FileServer erstellen

	-	[x] Static Files und Directory Browser
	-   [x] File Provider und Dateizugriff
	-	[x] [Hoppscotch](https://hoppscotch.io/) (Postman Alternative)
	-   [x] API mit [httpFile testen](https://learn.microsoft.com/de-de/aspnet/core/test/http-files?view=aspnetcore-8.0) 
	-   [x] Middleware

## M007 | HttpClient verwenden

	-   [x] Konfiguration auslesen
	-   [x] HttpClient verwenden
	-   [x] MultipartFormDataContent
	-   [x] HttpContext, Request, Response

## M008 | Entity Framework

	-   [x] O/R Mapping Framework EFCore
	-   [x] Code First Ansatz (Entites + DbContext)
	-   [x] DB Migration

```bash
// Package Manager Console aufrufen

Add-Migration InitMyModel -Context MyAppDbContext

Update-Database

```

	-   [ ] Controller mit Scaffolding erstellen (Microsoft.EntityFrameworkCore.Design)
	-   [ ] DB First Ansatz
	-   [ ] [Northwind DB](https://github.com/microsoft/sql-server-samples/blob/master/samples/databases/northwind-pubs/instnwnd.sql)
	-   [ ] LocalDB

## M009 | Entity Framework

	-   [ ] Unit Tests mit EntityFramework
	-   [ ] OrderService anhand von Tests entwickeln


## M010 | Benutzerverwaltung

	-   [ ] AspNetCore.Identity.EFCore
	-	[ ] CodeFirst & Migration
	-   [ ] UserManager & SignInManager
	-	[ ] Form Post & Validierung


## M011 | Weitere Themen

	-   [ ] Cookie Handling
	-   [ ] Server Caching