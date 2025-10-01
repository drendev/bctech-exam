
├── client/   # Frontend (Angular)
<br>├── server/   # Backend (ASP.NET)
<br>└── README.md # Project documentation

# Configure Server Side

1. Open VSCode

2. Open Project Solution (server.sln)

3. Create a new database in SQL Server Management

4. Configure Connection Strings at (ApiEndPoint/appsettings.json)

5. Update the database with developer powershell or terminal.
    #### dotnet ef database update --project Infrastructure --startup-project ApiEndpoint

6. Restore the dependencies
    #### dotnet restore

7. Run the Server and check if its running on https://localhost:7097/
    #### dotnet run


# Configure Client Side

1. Navigate to client server

    #### cd client

2. Install the dependencies

    #### npm install

3. Run the Client

    #### ng serve

# NOTE:

### Please add a department first before adding an employee since its a relational database. But you can still test the add employee without a department first :)