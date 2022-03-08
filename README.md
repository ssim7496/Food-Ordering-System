# Food-Ordering-System
.NET Core 6 Minimal API and EF Core

Please follow the steps in order to ensure that you can run the solution correctly :)

Step 1: Open Visual Studio 2022
 Step 1.1: Open the terminal (Developer PowerShell) 
  Step 1.1.1 You can navigate to View -> Terminal or press CTRL + `
 Step 1.2: Type in "cd FOS"
 Step 1.3: In the solution, go to Data -> FOSDBContext.cs and update the connection string on line 15 should you need to 
 Step 1.4: Type in "dotnet ef migrations add Update23" to have the migration ready
 Step 1.5: Type in "dotnet ef database update" to generate the relevant tables and master data
 Step 1.6: Press F5 to begin debugging and starting the API on endpoint https://localhost:7034/index.html
Step 2: Navigate to the folder directory "/FOS/client/fos_client"
 Step 2.1: Edit the Folder path navigation pane at the top of Windows Explorer and type in "cmd"
 Step 2.2: In the command prompt window, type in "code ." which will open up Visual Studio Code
 Step 2.3: In the command prompt window, type in "npm start" which will open up the app in the browser in a new tab next to the API endpoint. The endpoint should be http://localhost:3000/.
Step 3: Endpoint issues
 Step 3.1: Should the API endpoint in step 1.6 have changed, you can update the Constants.js (FOS/client/fos_client/src/utilities/Constants.js) file in Visual Studio Code and update the API_BASE_URL 
 Step 3.2: Should the client app endpoint in step 2.3 have changed, you can update the Program.cs file on line 17 with the new app endpoint to update the CORS policy
Step 4: Usability
 Step 4.1: To register as a customer, click on the Register button with your Windows credentials which will authenticate and register you upon successful authentication
 Step 4.2: To view all orders and manage master data, you may enter the follow details to log in as admin
  Domain: admin
  Username: admin
  Password: admin
 Step 4.3: To log in as the admin to view orders send to admin, you can sign in on Gmail using the below as well as view them on appsettings.json:
  Email: fosderivco@gmail.com
  Password: FOS#2022

Thank you :) 
I hope to hear back from you soon

Siyo :)
