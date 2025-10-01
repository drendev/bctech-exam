
├── client/   # Frontend (Angular)
<br>├── server/   # Backend (ASP.NET)
<br>└── README.md # Project documentation

### Configure Database (MSSQL)

1. Create a local database in SQL Server Management Studio

2. Edit the Connection strings in server/ApiEndpoint/appsettings.json

### Running the Backend Server

1. Navigate to server folder
 
 cd server

2. Restore the dependencies

 dotnet restore

3. Run the Server

 dotnet run

4. Check if the the Web API is running on https://localhost:7097/


### Running the Frontend

1. Navigate to client server

 cd client

2. Install the dependencies

 npm install

3. Run the Client

 npm run dev
