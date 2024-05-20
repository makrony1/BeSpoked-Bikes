# BeSpoked-Bikes
### Configure the database.
 To run this project create a database with name `BeSpokedBikes` grab the `script.sql` from the location `src/script.sql` once you run the script it will create the required schemas and insert few stub data there.
If you face any issue to run this script that might be the MSSQL version.

Note: This script is generated using the Microsoft SQL Server 2019 (RTM) - 15.0.2000.5 (X64).

### To Run the client application 
This client application present in `src/Client/be-spokeed-bike` [opes just noticeed the typo here]
You need to have node version at least 14.17.3 install on machine.
Open the terminal at `src/Client/be-spokeed-bike` and run the command `npm install` to install the dependency after that run the command `npm start` it will start the application on port `3000`

### To run the Backend/API 
Locate the sln file present at `sre/Server/BeSpokedBikes.sln` and open it in visual studio set the `BSB` as startup project if not setup. This project uses the .NET 6, so in your machine need to have the same.
once projects are open in visual studio build and run the project at IISExpress from the Visual studio.

Now open your browser and go to `http://localhost:3000/`