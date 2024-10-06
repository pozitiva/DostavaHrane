**DostavaHrane**

This is the backend for a food delivery application, handling restaurant management, order processing, and data persistence. The backend also features an admin panel for managing restaurant data and orders.

**Demo**

Check out a demo of the app on YouTube: https://www.youtube.com/watch?v=FRvawmbNSvo&ab_channel=Iva

**Features**

* Manage restaurants and menus.
* Handle customer orders and update statuses.
* Relational database management with MS SQL Server.
  
**Technologies Used**
* ASP.NET Core: For building RESTful APIs.
* Entity Framework Core: For database interaction.
* C#: Primary backend programming language.
* MS SQL Server: Relational database.
  
**Getting Started**

**Prerequisites**
* .NET SDK
* MS SQL Server
  
**Installation**

1. Clone the repository:

    git clone https://github.com/pozitiva/DostavaHrane.git

2. Navigate to the project directory:

    cd DostavaHrane

3. Open the solution file DostavaHrane.sln in Visual Studio.
   
**Running the Application**

1. Set up the database connection string in appsettings.json.
2. Run database migrations:

    dotnet ef database update
   
3. Build and run the application:
   
    dotnet run
   
