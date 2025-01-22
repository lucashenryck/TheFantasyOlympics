# The Fantasy Olympics
A project that simulates an API to manage "The Fantasy Olympics".


DEVELOPMENT TOOLS:
- IDE: I used Visual Studio 2022 because it has complete integration with the .NET (8.0) Framework, which I used for this project.
- DATABASE: I used SQL Server because of my familiarity with it and its DBMS (Database Management System). The server is local and I used the Windows Credentials.
- SWAGGER: I used Swagger as the main documentation and for testing the endpoints.


PROJECT PATTERNS: 
CLEAN ARCHITECTURE: I created this project based on Clean Architecture, organizing it into layers with their respective logic and dependencies, always keeping the business logic at the core of the project.
REPOSITORY PATTERN: I used the Repository Pattern to mediate and decouple the Domain Model (Entities), from the persistence operations for each of those objects.
CQRS: I used CQRS to separate the responsibilities of writing and reading my data.
API VERSIONING: I used it because I worked at a place that developed many systems and APIs. Some systems made use of more than 8 APIs, and the developers had the routine habit of changing something related to them out of necessity or improvement, whether it was a DTO, a parameter, or a simple Nullable notation. Therefore, it was common to have problems with the APIs that kept changing, and no one knew who had made the changes (we knew by the git history, though).


SETUP:
1. Download Visual Studio 2022 with the following packages:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- MediatR 
- AutoMapper
- Asp.Versioning.Mvc
- Asp.Versioning.Mvc.ApiExplorer

2. Open my project (Solution) with the Visual Studio.

3. Run the main project (Web API) on HTTPS to open the Swagger documentation as a web page.

4. If you prefer to use a tool like Insomnia, simply enter the local address (https://localhost:XXXX) followed by the rest of the endpoint defined in the controllers.


MY DIAGNOSIS:
- It was a challenging project for me because I had never used any architecture patterns before, and with CQRS, I had only learned the minimum necessary to handle my tasks in an already created and production-ready API.
- The front-end is missing, but I'm already envisioning it.
- I noticed there is a lot of code repetition in the application layer, so I'm already studying how to implement similar methods more efficiently.
- Tests in progress.
- Terrible commits (too heavy, lacking specific details, and without branches).
- I'm going to push the project in the right format soon.


TESTING THE ENDPOINTS:

Athletes
- Register: just insert the base athlete data in the body for creating an athlete in the database, where their identifier is created at the end. The athlete needs to be linked to a sport and a modality, so use an ID from both for this.
- Edit: insert the athlete's ID that you want to edit as a parameter, followed by the information you wish to change in the body. To keep something, simply leave it unchanged.
- Delete: just insert the athlete's ID that you want to delete as a parameter.
- Find by Id: just insert the athlete's ID that you want to find as a parameter.
- List All: just perform the query to fetch all athletes from the database.
- List by Country: insert the name of the country you want to filter athletes by as a parameter.
- List by Sport: insert the sport's ID you want to filter athletes by as a parameter.
- List by Team: insert the team's name you want to filter athletes by as a parameter.

Sports
- Register: just insert the sport's name in the body for creating a sport in the database, where their identifier is created at the end. You don't need to create the modalities while creating the sport.
- Edit: insert the sport's ID that you want to edit as a parameter, followed by the information you wish to change in the body. To keep something, simply leave it empty.
- Delete: just insert the sport's ID that you want to delete as a parameter.

Modality
- Register: insert the base modality data in the body for creating a modality and the identifier will be created at the end. The modality needs to be linked to a sport, so use some sport ID for this.
- ListByFilter: insert the ID of some sport to filter the modalities in the database. You can also use the optional filters (Genre and Type)

Medal
- Get Medal Table: just perform the query to get an overall medal table.
- List Medals by Country: insert the name of a country to see its medal list, along with their respective sports and modalities.
- List Medals by Sport: insert the ID of a sport to see the list of medals won in it.
- Find Modality Podium: insert the ID of a modality to see who won the gold, silver, and bronze medals in it.
- Register Modality Podium: insert the country, sport ID, and modality ID that won the gold, silver, and bronze medals.


