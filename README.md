# Mossad HR application

## How to test

### Setting connection string

Please set the **database path** in the app.config connection string in **WinService** and **Tests\IntegrationTests** projects to an appropriate path.

### Creating database

Tests/IntegrationTests project contains a test called **CreateDb** which **creates the database** and adds test data to it.

### Accessing the API

The API can be accessed on the localhost:8080 port after starting the WinService process. It doesn't need IIS.

#### Starting the API server from Visual Studio IDE

1. Open the SLN in Visual Studio
2. Set the Api project as the startup project for the solution
3. Start the project with F5 (debug run)
4. Requests on localhost:8080 will be answered 

#### Starting the API server from command prompt

1. Execute StartProcess.bat in main project folder (The command window can be closed, the server will still work)
2. Requests on localhost:8080 will be answered 
3. To stop the server execute the StopProcess.bat in main project folder

#### Installing the API server as windows service

1. Build the solution
2. Start Developer Command prompt as administrator
3. Navigate to the main folder of the Mossad solution
4. Execute installService.bat
5. Start Services.msc
6. Start Mossad.HR.API service

## Implementation details

The BE solution uses Nancy FX a mature, well supported, lightweight framework for WEB API. See https://auth0.com/blog/meet-nancy-a-lightweight-web-framework-for-dot-net/
https://www.ben-morris.com/simplifying-net-rest-api-development-nancy-self-hosting-and-asp-net-core/

The solution is multi layered, so it is easy to convert ASP.NET WEB API if necessary.

This solution is based on my earlier hobby work.

## Known issues

1. The database is not optimized for speed. More indexes should be defined.
2. Recruiter password handling is not implemented
3. Recruiter security token handling is not implemented

## Task Description

Original task description moved to **Doc** folder
