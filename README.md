# Book Club
This is a virtual book club app.

---

## Project Status
This project is currently in **active development**.

 ### Sections
  - [Upcoming Features](#upcoming-features)
  - [How to Get Started](#how-to-get-started)
  - [Technologies Used](#technologiesframeworks-used)

---

## How to get started
### Prerequisites:
   - **Required**
      - [`.NET 9 SDK`](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) 
      - [`Microsoft SQL Server`](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
   - **Optional but recommended**
      - [`Visual Studio 2022`](https://visualstudio.microsoft.com/)
      - [`SQL Server Management Studio`](https://learn.microsoft.com/en-us/ssms/install/install)
### Clone or download the repository:
[![Download zip](https://custom-icon-badges.demolab.com/badge/-Download-blue?style=for-the-badge&logo=download&logoColor=white "Download zip")](https://github.com/Kenny-42/BookClubProject/archive/refs/heads/master.zip)
```
git clone https://github.com/Kenny-42/BookClub.git
cd BookClub
```

### Build and run:
 - Using Visual Studio:
    - Open [`BookClub.sln`](../master/BookClub.sln) and press F5 to build
 - Using .NET Cli:
   ```
      dotnet restore
      dotnet build
      dotnet run
   ```
---

## Upcoming Features
- [ ] CRUD (Create, Read, Update, Delete) functionalities
- [x] SQL Database creation script
   - [ ] Tables
      - [x] Accounts
      - [x] Books
      - [x] Reviews
      - [ ] Discussions
   - [ ] Mock data generation
      - [x] Accounts
      - [x] Books
      - [x] Reviews
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
- [ ] Discussion System?
   - To be determined

## Technologies/Frameworks Used
### Backend
- **.NET 9 SDK** - Core framework for building the application
- **Windows Forms (WinForms)** - UI framework for creating desktop applications
- **C#** - Main programming language
### Database
- **Microsoft SQL Server** - Relational database system
- **T-SQL Database(Transact-SQL)** - SQL Server's procedural extension of SQL used for querying and scripts
### Tools & Development
 - **.NET CLI** - Command-line interface for building and running the project
 - **Visual Studio 2022** - IDE for building and debugging the project *(optional)*
 - **SQL Server Management Studio (SSMS)** - Tool for interacting with SQL Server *(optional)*
