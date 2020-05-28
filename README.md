# Acme Corporation's Winning System
Acme Corporation's Winning System for drawing prizes to our lovely customers! (Project for internship application)

## How to get startede
- Clone the project.
- Run dotnet restore.
- Install a local MSSQL server or use an existring database and adjust the connection string in appsettings.json in the ACWS-WebApp accordingly, or on Windows set to use localdb.
- Run dotnet ef database update with ACWS-WebApp as the startup project and ACWS-Data as the target project to make sure the database is setup.
- Run the ACWS-WebApp project with dotnet run.
