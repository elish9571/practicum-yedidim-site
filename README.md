# Employee Management System | Angular 17 & .NET

This project is an **Employee Management System** built with **Angular 17** for the client-side and **.NET** for the server-side. It provides a user-friendly interface for managing employee records, including adding, editing, logically deleting employees, and exporting data to Excel.

---

## Features

### Client-Side (Angular 17)
- **Employee List**: Displays a table of employees with the following details:
  - First Name, Last Name, ID, Start Date.
- **Add/Edit/Delete Employees**:
  - Add: Opens a form to register a new employee.
  - Edit: Opens a form pre-filled with employee details for updates.
  - Delete: Performs logical deletion (employees marked as inactive).
- **Dynamic Roles**: Assign multiple roles to employees with specific details:
  - Role Name (chosen from a list), Managerial Role (Yes/No), Entry Date (must be on or after Start Date).
  - Duplicate roles for the same employee are not allowed.
- **Search and Filter**: Real-time filtering of the employee list by typing in the search field.
- **Export to Excel**: Download the employee list in Excel format.
- **Validations**: All fields are required, with input validations for proper data entry.

### Server-Side (.NET)
- **RESTful API**: Handles employee data operations (CRUD).
- **Database Integration**: Uses SQL Server to store employee data.
- **Layered Architecture**: Implements a clean and modular multi-layered project structure.

---

## Installation

### 1. Clone the repository
```sh
git clone https://github.com/elish9571/practicum-yedidim-site.git
cd practicum-yedidim-site
```
### 2. Install dependencies

#### Server
```sh
cd server
dotnet restore
dotnet build
```
#### Client
```sh
cd ../client
npm install
```
### 3. Configure and run

- Update database settings in the server's `appsettings.json` file.

#### Start the server
```sh
cd ../server
dotnet run
```
#### Start the client
```sh
cd ../client
ng serve
```
### 4. Open the app in your browser
```sh
http://localhost:4200
```
## Technologies Used

- **Frontend**: Angular 17, Bootstrap
- **Backend**: .NET, SQL Server
- **Database**: SQL Server with logical deletion
- **Excel Export**: Built-in Angular service for exporting data

## License
This project is licensed under the MIT License.


##### Good Luck!  
Elish.

