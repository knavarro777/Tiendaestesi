## Project Description
This project is a web application built with **C# and .NET Blazor** to manage a record store database. It allows users to view, add, update, and delete information about customers, music records, and sales through a clean user interface connected to a relational database using Entity Framework Core.

---

## Features and Basic Functionalities

Here are the main features developed for this project:

### 1. Database Connection and Setup
* **Server Connection:** Connects successfully to the database using Entity Framework Core and connection strings configured in `appsettings.json`.
* **Migrations:** Uses EF Core migrations to automatically create and update the database structure (tables for clients, records, and sales).

### 2. Database and Table Management
* **Data Navigation:** Allows users to easily switch between different sections and tables of the store database (Clients, Discs, Sales).

### 3. Data View and Navigation
* **Grid View:** Displays records in clean tables within the Blazor pages (`ClientesIndex`, `DiscosIndex`, `VentasIndex`).
* **Data Presentation:** Loads and shows large sets of relational data efficiently inside the web components.

### 4. Basic CRUD Interface
* **Customer Management (Clientes):** Forms and index pages to view, create, and manage client details (`ClientesForm.razor`, `ClientesIndex.razor`).
* **Record Management (Discos):** Forms and index pages to manage music records (`DiscosForm.razor`, `DiscosIndex.razor`).
* **Sales Management (Ventas):** Forms and index pages to handle sales transactions linked to the store items (`VentasForm.razor`, `VentasIndex.razor`).
* **Repositories:** Uses repository patterns (`RepositorioClientes`, `RepositorioDiscos`, `RepositorioVentas`) to handle database logic cleanly.

---

## Technologies Used

* **Programming Language:** C# (.NET)
* **Framework:** Blazor (ASP.NET Core)
* **Database ORM:** Entity Framework Core (EF Core)
* **Database:** Relational Database (MySQL / SQL Server)
