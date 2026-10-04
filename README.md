# Courier Management System 🚚📦

## Description

A full-stack web application designed for efficient courier management and real-time tracking. This system streamlines operations for courier businesses by providing tools for managing couriers, shipments, and generating reports.

## Table of Contents

- [About the Project](#about-the-project)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)
- [Footer](#footer)

## About the Project 💡

This project is a comprehensive Courier Management System developed using ASP.NET Core MVC, Entity Framework Core, and MSSQL. It aims to provide a robust platform for businesses to manage their courier operations, from shipment creation to final delivery, with integrated tracking capabilities.

## Features ✨

- **Courier Management:** Add, view, edit, and delete courier information.
- **Shipment Tracking:** Monitor the status and location of shipments.
- **Reporting:** Generate reports on courier performance and shipment details.
- **User Authentication:** Secure login system for accessing the application.
- **Data Persistence:** Utilizes MSSQL database for storing all operational data.
- **Web Interface:** Intuitive MVC-based web interface for seamless user interaction.

## Tech Stack 🛠️

- **Backend:** ASP.NET Core MVC
- **Database:** MSSQL
- **ORM:** Entity Framework Core
- **Frontend:** HTML, CSS, JavaScript
- **Development Tools:** Visual Studio

## Installation ⚙️

To set up and run this project locally, follow these steps:

1.  **Prerequisites:**
    *   .NET SDK (version compatible with ASP.NET Core MVC)
    *   SQL Server Management Studio (SSMS) or an equivalent SQL Server client.

2.  **Clone the Repository:**
    ```bash
    git clone https://github.com/asif-ahmed-asif/CourierManagementSystem.git
    cd CourierManagementSystem
    ```

3.  **Database Setup:**
    *   Open `CourierManagementSystem/appsettings.json`.
    *   Configure the `ConnectionStrings` section with your MSSQL server details. For example:
        ```json
        "ConnectionStrings": {
          "DefaultConnection": "Server=your_server_name;Database=CourierManagementDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"
        }
        ```
    *   Ensure you have created the `CourierManagementDB` database on your MSSQL server, or update the connection string to use an existing database name.

4.  **Database Migration:**
    *   Navigate to the project directory in your terminal.
    *   Run the following commands to apply the database migrations:
        ```bash
        dotnet tool install --global dotnet-ef
        dotnet ef migrations add initial_create
        dotnet ef database update
        ```
        (Note: If you encounter issues, ensure the `CourierManagementSystem` project is set as the startup project in your IDE or use `dotnet ef` commands with the project path).

5.  **Run the Application:**
    *   Open the solution file (`CourierManagementSystem.sln`) in Visual Studio or use the .NET CLI.
    *   Run the application using:
        ```bash
        dotnet run
        ```
    *   The application will typically be accessible at `http://localhost:5000` or `http://localhost:5001` (check `CourierManagementSystem/Properties/launchSettings.json` for exact URLs).

## Usage 🚀

This application provides a web-based interface for managing courier operations:

1.  **Login:** Access the login page (`/Logins/Login`) to authenticate. (Note: User credentials are not specified in the analyzed files, assuming default or initial setup might be required).
2.  **Courier Management:** Navigate to the `/Couriers` section to manage courier details (create, view, edit, delete).
3.  **Shipment Management:** Use the designated sections (likely within `/Couriers` or a dedicated `/Shipments` controller if present) to manage shipments.
4.  **Reporting:** Access the `/Report` controller to view generated reports.

### Example Scenario:

- A new courier joins the company. An administrator logs in and adds the courier's details (name, contact info, vehicle, etc.) via the Courier Management interface.
- A package needs to be sent. The system allows for the creation of a new shipment record, assigning it to a courier and specifying details like sender, receiver, and destination.
- The status of a shipment can be updated throughout its journey, allowing for real-time tracking.

## Project Structure 📁

The project follows a standard ASP.NET Core MVC structure:

```
CourierManagementSystem/
├── Controllers/
│   ├── CouriersController.cs
│   ├── HomeController.cs
│   ├── LoginsController.cs
│   └── ReportController.cs
├── Data/
│   └── DataContext.cs
├── Migrations/
│   ├── 20231028072157_db_created.cs
│   └── DataContextModelSnapshot.cs
├── Models/
│   ├── Courier.cs
│   ├── ErrorViewModel.cs
│   ├── Login.cs
│   └── Status.cs
├── Properties/
│   └── launchSettings.json
├── Services/
│   └── CourierServices/
│       ├── CourierService.cs
│       └── ICourierService.cs
├── Views/
│   ├── Couriers/
│   │   ├── Create.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
│   │   ├── Edit.cshtml
│   │   └── Index.cshtml
│   ├── Home/
│   │   ├── Details.cshtml
│   │   └── Index.cshtml
│   ├── Logins/
│   │   └── Login.cshtml
│   ├── Shared/
│   │   ├── Error.cshtml
│   │   ├── _Layout.cshtml
│   │   └── _ValidationScriptsPartial.cshtml
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml
├── wwwroot/
│   ├── css/
│   │   └── site.css
│   ├── js/
│   │   └── site.js
│   ├── lib/
│   │   ├── bootstrap/
│   │   └── jquery-validation-unobtrusive/
│   └── Reports/
│       └── Receipt.rdlc
├── .vs/
├── CourierManagementSystem.csproj
├── CourierManagementSystem.sln
├── Program.cs
├── appsettings.Development.json
└── appsettings.json
```

## Contributing 

Contributions are welcome! If you have suggestions for improving this project, please:

1.  Fork the Project
2.  Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3.  Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4.  Push to the Branch (`git push origin feature/AmazingFeature`)
5.  Open a Pull Request

## License 

This project is not currently under any specified license. Please check the repository for updates.

## Footer 

--- 

© 2023 [asif-ahmed-asif](https://github.com/asif-ahmed-asif). All rights reserved.

Built with ❤️ by [asif-ahmed-asif](https://github.com/asif-ahmed-asif).

[Back to Top](#courier-management-system 🚚📦)

[![GitHub stars](https://img.shields.io/github/stars/asif-ahmed-asif/CourierManagementSystem?style=social)](https://github.com/asif-ahmed-asif/CourierManagementSystem/stargazers)
[![GitHub forks](https://img.shields.io/github/forks/asif-ahmed-asif/CourierManagementSystem?style=social)](https://github.com/asif-ahmed-asif/CourierManagementSystem/forks)
[![GitHub issues](https://img.shields.io/github/issues/asif-ahmed-asif/CourierManagementSystem)](https://github.com/asif-ahmed-asif/CourierManagementSystem/issues)


---
**<p align="center">Generated by [ReadmeCodeGen](https://www.readmecodegen.com/)</p>**