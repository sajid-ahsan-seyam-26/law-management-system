# law-management-system-c#
# LawConnect

LawConnect is a **C# Windows Forms desktop application** built for connecting **clients, lawyers, and admins** in one legal service platform.  
It includes separate login flows for each user type, lawyer discovery, appointment scheduling, payment simulation, profile management, and admin monitoring tools.

## Features

### Client side
- Client sign up and login
- View and update profile
- Search lawyers
- Sort lawyers by name, rating, and fee
- View lawyer details
- Schedule appointments
- Check appointment status
- Simulate payment through:
  - Mobile banking: **bKash, Nagad, Rocket, UPay**
  - Bank/card: **DBBL, City Bank, Islami Bank, First Security Bank**
- Give ratings to lawyers
- Access legal forms and books

### Lawyer side
- Lawyer sign up and login
- View and update profile
- View searchable lawyer list
- Check appointment requests
- Accept or reject appointments
- Forgot password flow

### Admin side
- Admin sign up and login
- View dashboard summary
- Monitor number of clients and lawyers
- View lawyer records
- View client records
- View admin records
- Search and sort records
- Update admin profile
- Delete profile / account-related actions
- Forgot password flow

## Tech Stack

- **Language:** C#
- **Framework:** .NET Framework 4.7.2
- **UI:** Windows Forms
- **Database:** Microsoft SQL Server / SQL Server Express
- **Data Access:** `System.Data.SqlClient`
- **IDE:** Visual Studio

## Project Structure

```text
WindowsFormsApp1/
├── Program.cs
├── Welcome.cs
├── LawConnect*.cs        # Client-side forms
├── Lawyer*.cs            # Lawyer-side forms
├── Admin*.cs             # Admin-side forms
├── Properties/
├── bin/
└── obj/
```

## Application Flow

The app starts from the **Welcome** screen and provides three entry points:
- **Login as Client**
- **Login as Lawyer**
- **Login as Admin**

Each role has its own forms and actions.

## Database Tables Used

From the source code, this project uses at least these tables:

- `Client`
- `_Lawyer`
- `Admin`
- `Schedule`

### Example responsibilities of tables
- **Client**: stores client account, phone number, age, password, pin
- **_Lawyer**: stores lawyer profile, fee, rating, type, password
- **Admin**: stores admin profile and login details
- **Schedule**: stores appointment requests, lawyer ID, client ID, date, and status

## Requirements

Before running the project, make sure you have:

- **Visual Studio** with Windows Forms support
- **.NET Framework 4.7.2 Developer Pack**
- **SQL Server / SQL Server Express**
- A database named **`Project`**

## Setup Instructions

### 1. Clone the repository
https://github.com/sajid-ahsan-seyam-26/law-management-system.git
```

### 2. Open the solution / project
Open the project in **Visual Studio**.

### 3. Create the database
Create a SQL Server database named:

```sql
Project
```

### 4. Create required tables
You will need to create the tables used by the code:
- `Client`
- `_Lawyer`
- `Admin`
- `Schedule`

If you have a SQL backup or `.sql` script for the database, import it before running the project.

### 5. Update the connection string
The source code currently uses a **hardcoded local SQL Server connection string** like this:

```csharp
string connectionString = "data source=DESKTOP-4QU6BBP\\SQLEXPRESS; database=Project; integrated security=SSPI";
```

Replace `DESKTOP-4QU6BBP\\SQLEXPRESS` with your own SQL Server instance name.

Example:

```csharp
string connectionString = "data source=YOUR_PC_NAME\\SQLEXPRESS; database=Project; integrated security=SSPI";
```

### 6. Run the application
Press **F5** in Visual Studio.

## Important Notes

- This project is built as a **desktop application**, not a web app.
- Connection strings are repeated in multiple forms, so they should ideally be moved to **App.config** for easier maintenance.
- Some Visual Studio generated folders are included in the project package, such as:
  - `.vs/`
  - `bin/`
  - `obj/`

For a cleaner GitHub repository, these should normally be excluded with a `.gitignore` file.

## Possible Improvements

- Move all database connection strings to `App.config`
- Add input validation in more forms
- Add exception handling consistently across all modules
- Store passwords securely instead of plain text
- Add proper database scripts to the repository
- Add screenshots and sample data
- Refactor repeated code into reusable helper methods

## Known Issues

- The project depends on a local SQL Server setup
- The database script is not included in the uploaded package
- Some generated Visual Studio files are included in the archive
- Rating logic appears to need refinement if rating count is not stored separately in the database

## Learning Purpose

This project is a good practice example for:
- Windows Forms UI design
- SQL Server database connectivity
- Multi-role login systems
- CRUD operations
- Search and sorting in `DataGridView`
- Appointment management logic

## Author

Add your name here.

## License

This project is for educational purposes unless you add your own license.
