# Catalog Management System

# VS Code Extension

## For API project

1. C# by Microsoft
2. C# Extensions by JosKreativ
3. Material Icon theme by Phillip Kief
4. NuGet Gallery by pcislo
5. SQLite by alexcvzz  

## For Client project

1. Angular Language Service by Angular
2. Angular Snippets by Angular
3. Bracket Pair Colorizer 2 by CoenraadS

# Basic Git Command

1. To clone project ``git clone https://github.com/tanvirIqbal/catalog-ms.git``
2. Update Project before woring the project or pushig the project ``git pull``
3. Add chenges for commiting ``git add *``
4. To commit ``git commit -m "commit message"``
5. To push to the GitHub ``git push``

# Install Required Software:

1. Postman
2. Git
3. .Net SDK (.Net 5 was used for the demos)

# Basic .net CLI commands

``mkdir skinet``  
``cd skinet``  
``dotnet new sln``  
``dotnet new webapi -o API``  
``dotnet sln add API``  
``dotnet new -l``  
``dotnet new classlib -o Core``  
``dotnet new classlib -o Infrastructure``  
``dotnet sln add Core``  
``dotnet sln add Infrastructure``  
``cd API``  
``dotnet add reference ../Infrastructure``  
``cd ..``  
``cd Infrastructure``  
``dotnet add reference ../Core``  
``dotnet dev-certs https --trust``


# How to run ptoject in VS Code after cloning
1. Open Terminal
2. Run this command ``dotnet restore``
3. Go to API folder ``cd .\API\``
4. Run this command ``dotnet watch run``
5. Test API in Postmen


# Database Commands
1. Install entity framework 'ef' tools globally  ``dotnet tool install --global dotnet-ef``
2. Drop database using 'ef' tools  ``dotnet ef database drop -p Infrastructure -s API``. Here ``-p`` means In which project ``StoreContext`` is located and ``-s`` means In which project ``Startup.cs``
3. Remove migration not appllied yet using 'ef' tools  ``dotnet ef migrations remove -p Infrastructure -s API``
4. Create new migration using 'ef' tools  ``dotnet ef migrations add InitialCreate -p Infrastructure -s API -o Data/Migrations``
5. Update the database with Migrations ``dotnet ef database update -p Infrastructure -s API``
6. Update the database to previous migrations ``dotnet ef database update PreviousMigrationName -p Infrastructure -s API``
7. Create full database script ``dotnet ef migrations script``
8. ``dotnet ef migrations add IdentityMigration -p Infrastructure -s API -c AppIdentityDbContext -o Identity/Migrations`` Create new migration with db context name if project has multiple DbContext

# How to create API

1. Entity Class in Core > Entities Folder
2. Database configuration with fluent API in Infrastructure > Data > Config folder
3. StoreCOntext.cs e DbSet add
4. Create Migration
5. Update Migration  

6. Create interface in Core > Interfaces folder
7. Create repository class in Infrastructure > Data folder
8. add reposity class and interface in ApplicationServicesExtensions class in API > Extensions folder.  

9. Create controller in API > Controllers folder.
10. Create methods using repository interface

11. Create DTO class in API > DTO folder
12. Map DTO with Entity in MappingProfile class in API > Helper folder
13. Apply AutoMapper in controller class  


# Setup Angular Project 

1. Install Node.js (check which version of node and npm is required for latest angular)
   1. ``nvm ls`` (check node version)
   2. ``nvm use version-number`` use other installed node version
   3. ``npm --version`` (check npm version)
2. Install Angular CLI ``npm install -g @angular/cli``
3. Create new project ``ng new client``
4. Create a component ``ng g c component-name``
5. Create a module ``ng g c module-name``
6. Create a service ``ng g s service-name``


# Publish API and CLient App

1. ``ng build `` For Angular
2. ``dotnet publish -c Release`` For .Net 5

