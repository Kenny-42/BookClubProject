# Book Club
Welcome to the **Book Club** application, a virtual platform where users can review and discuss books. Enjoy connecting with others through shared reading experiences.

---

## Project Status
This project is currently in **active development**.

### Sections
- [How to Get Started](#how-to-get-started)
- [Upcoming Features](#upcoming-features)
- [Technologies Used](#technologiesframeworks-used)

---

## How to get started
### Prerequisites:
To get started, make sure you have the following installed:

**Required**
- [`.NET 9 SDK`](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) 
- [`Microsoft SQL Server`](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

**Optional but recommended**
- [`Visual Studio 2022`](https://visualstudio.microsoft.com/)
- [`SQL Server Management Studio`](https://learn.microsoft.com/en-us/ssms/install/install)

### Clone or download the repository:
Click the button to download the ZIP of the repository or clone it via Git:

[![Download zip](https://custom-icon-badges.demolab.com/badge/-Download-blue?style=for-the-badge&logo=download&logoColor=white "Download zip")](https://github.com/Kenny-42/BookClubProject/archive/refs/heads/master.zip)

Alternatively, use Git to clone the repo:
```
git clone https://github.com/Kenny-42/BookClubProject
cd BookClub
```

## Build and run:
You can build and run the **BookClub** application either via **Visual Studio** or the **.NET CLI**.

### 1. Using Visual Studio:
- Open the solution file: [`BookClub.sln`](../master/BookClub.sln)
- Press **F5** to build and run the application

### 2. Using .NET CLI:
- Open a **Command Prompt**, **Powershell**, or **Bash** window.
- Navigate to project folder containing the project file: [`BookClub.csproj`](../master/BookClub/BookClub.csproj)
```bash
  cd BookClub
```
### 1. Restore dependencies
Make sure you have all required dependencies:
```bash
dotnet restore
```
### 2. Build
Run the following command to apply migrations and create the database:
```bash
dotnet build
```
### 3. Run
```bash
  dotnet run
```
---

## Upcoming Features
- [ ] Full CRUD (Create, Read, Update, Delete) functionalities
- [x] Database initialization using Entity Framework Core Migrations
   - [x] Accounts Table
   - [x] Books Table
   - [ ] Reviews Table (To be added)
   - [ ] Discussions Table (To be added)
   - [ ] Mock data generation
      - [x] Accounts
      - [x] Books
      - [ ] Reviews
      - [ ] Discussions
- [ ] Account System
   - [ ] Login
   - [ ] Registration
   - [ ] Modify account details
   - [ ] Account deletion
- [ ] Book System
   - [ ] Registering books
   - [ ] Book Reviews?
- [ ] Review System
   - [ ] Create reviews
   - [ ] Edit reviews
   - [ ] Delete reviews
- [ ] Discussion (To be added)

## Technologies/Frameworks Used
### Backend
- **.NET 9 SDK** - Core framework for building the application
- **Windows Forms (WinForms)** - UI framework for creating desktop applications
- **C#** - Main programming language
- 
### Database
- **Microsoft SQL Server** - Relational database system
- **Entity Framework Core 9** - ORM used for database modeling, migrations, and data access
  - `Microsoft.EntityFrameworkCore.SqlServer` - SQL Server provider for EF Core
  - `Microsoft.EntityFrameworkCore.Design` - Design-time tools for EF Core, including migrations, scaffolding

### Configuration & Hosting
- **Microsoft.Extensions.Configuration** – API for accessing configuration values  
- **Microsoft.Extensions.Configuration.Json** – Support for JSON-based app settings (e.g., `appsettings.json`)  
- **Microsoft.Extensions.Hosting** – Used to manage application lifetime, background services, and built-in Dependency Injection

### Tools & Development
 - **.NET CLI** - Command-line interface for building and running the project
 - **Visual Studio 2022** - IDE for building and debugging the project *(optional)*
 - **SQL Server Management Studio (SSMS)** - Tool for interacting with SQL Server *(optional)*
