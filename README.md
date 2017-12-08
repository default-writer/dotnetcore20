# dotnetcore20

# Getting Started with EF Core on ASP.NET Core with an Existing Database (PostgreSQL)

> [!IMPORTANT]  
> The [.NET Core SDK](https://www.microsoft.com/net/download/core) no longer supports `project.json` or Visual Studio 2015. Everyone doing .NET Core development is encouraged to [migrate from project.json to csproj](https://docs.microsoft.com/dotnet/articles/core/migration/) and [Visual Studio 2017](https://www.visualstudio.com/downloads/).

In this walkthrough, you will build an ASP.NET Core MVC application that performs basic data access using Entity Framework. You will use reverse engineering to create an Entity Framework model based on an existing database.

> [!TIP]  
> You can view this article's [sample](https://github.com/hack2root/dotnetcore20/tree/master/dotnetcoremvc) on GitHub.

## Prerequisites

The following prerequisites are needed to complete this walkthrough:

* [Visual Studio 2017 15.3](https://www.visualstudio.com/downloads/) with these workloads:
  * **ASP.NET and web development** (under **Web & Cloud**)
  * **.NET Core cross-platform development** (under **Other Toolsets**)
* [.NET Core 2.0 SDK](https://www.microsoft.com/net/download/core).
* [PostrgeSQL 10.1](https://www.postgresql.org/)
* [PostgreSQL Northwind database install scripts](#northwind-database)
* [Npgsql](http://www.npgsql.org/doc/ddex.html)
* [Npgsql Visual Studio extension (VSIX)](https://marketplace.visualstudio.com/items?itemName=RojanskyS.NpgsqlPostgreSQLIntegration)
### Northwind database

This tutorial uses a **Northwind** database on your PostgreSQL instance as the existing database.

> [!TIP]  
> If you have already created the **Northwind** database as part of another tutorial, you can skip these steps.
* Install PostgreSQL Northwind database
  * Open solution folder dbnpgsql
  * Set PostgreSQL system environment variables PGUSER, PGPASSWORD
  * Run install.cmd as administrator
* Open Visual Studio
* **Tools -> Connect to Database...**
* Select **Postgre SQL Database** and click **Continue**
* Enter **localhost** as the **Server Name**
* Enter **northwind** as the **Database Name** and click **OK**
* Enter **northwind_user** as the *User Name*
* Enter **thewindisblowing** as the *Password*
* The Northwind database is now displayed under **Data Connections** in **Server Explorer**

[!code-sql[Main](dbnpgsql/northwind.sql)]

## Create a new project

* Open Visual Studio 2017
* **File -> New -> Project...**
* From the left menu select **Installed -> Templates -> Visual C# -> Web**
* Select the **ASP.NET Core Web Application (.NET Core)** project template
* Enter **EFGetStarted.AspNetCore.ExistingDb** as the name and click **OK**
* Wait for the **New ASP.NET Core Web Application** dialog to appear
* Under **ASP.NET Core Templates 2.0** select the **Web Application (Model-View-Controller)**
* Ensure that **Authentication** is set to **No Authentication**
* Click **OK**

## Install Entity Framework

To use EF Core, install the package for the database provider(s) you want to target. This walkthrough uses PostgreSQL Server.

* **Tools > NuGet Package Manager > Package Manager Console**

* Run `Install-Package Microsoft.EntityFrameworkCore.SqlServer`

We will be using some Entity Framework Tools to create a model from the database. So we will install the tools package as well:

* Run `Install-Package Microsoft.EntityFrameworkCore.Tools`

We will be using some ASP.NET Core Scaffolding tools to create controllers and views later on. So we will install this design package as well:

* Run `Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design`

## Reverse engineer your model

Now it's time to create the EF model based on your existing database.

*Before you start, make shure you added some sections to *.cspoj file:
* [Add autogenerate binding redirects](https://blogs.msdn.microsoft.com/dotnet/2017/08/14/announcing-entity-framework-core-2-0)
* Set AutoGenerateBindingRedirects flag to true in PropertyGroup
* [Add Microsoft.EntityFrameworkCore and dependencies](https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/existing-db#blogging-database)
* Install-Package Npgsql.EntityFrameworkCore.PostgreSQL
* Install-Package Microsoft.EntityFrameworkCore
* Install-Package Microsoft.EntityFrameworkCore
* Install-Package Microsoft.EntityFrameworkCore.Relational
* Install-Package Microsoft.EntityFrameworkCore.SqlServer
* Install-Package Microsoft.EntityFrameworkCore.Tools

* **Tools –> NuGet Package Manager –> Package Manager Console**
* Run the following command to create a model from the existing database:

``` powershell
Scaffold-DbContext "Database=northwind;Username=northwind_user;Password=thewindisblowing;Host=localhost;Persist Security Info=True" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Models -Verbose
```

If you receive an error stating `The term 'Scaffold-DbContext' is not recognized as the name of a cmdlet`, then close and reopen Visual Studio.

> [!TIP]  
> You can specify which tables you want to generate entities for by adding the `-Tables` argument to the command above. E.g. `-Tables Blog,Post`.
