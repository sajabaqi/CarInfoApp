To run the application locally, please make sure you have the following installed:
.NET 8 SDK
Node.js v20+ and npm
Visual Studio or Visual Studio Code

#clone the repository
git clone https://github.com/sajabaqi/CarInfoApp.git
#navigate to the API project folder first in terminal
cd CarInfoApp/CarInfoApiApp
dotnet restore
dotnet run
//will work in http://localhost:5000
#then navigate angular (frontend) folder in terminal
cd CarInfoApp/CarInfoFrontend
npm install
npm start
// will work in http://localhost:4200

# make sure to run the api first then frontend project
