# Fantasy Wealth
A Fantasy Online Stock Trading Web application for Buying and Selling Stocks, coded from scratch with C# ASP.NET Core 2.1 framework that is a cross-platform framework for building cloud-based, Internet-connected application. 

Visit the app live at [here](https://fantasywealth.azureapp.net)

## Step by Step and Helpful Tips for Development

### Prerequisites
- .NET Core 2.1 SDK or later
- Visual Studio Code
- Azure CLI 2.0

### Creating the ASP.NET Core MVC web app by .NET Core CLI
-	Create a folder in VS Code Command Prompt named FantasyWealth
```
> mkdir FantasyWaelth
```
-	In Command Prompt change Directory to the FantasyWealth folder.
``` 
> cd FantasyWeelth
```
-	Run below dotnet command from .NET Core CLI Tools to create a new ASP.NET Core C# MVC application project in the current directory 
   ``` 
  FantasyWeelth> dotnet new mvc -au None -lang C# -f  netcoreapp2.1 
   ```
##### Note: - ```>dotnet new mvc``` also works because in ```dotnet new``` the default language is C#, default framework is the latest version installed on the machine unless specified and The type of authentication is None. When running the Scaffold identity into the application it adds login functionality to the application for adding custom user data to Identity and other modification.
- To test the application project is created correctly run below command and browse  http://localhost:5000  or   https://localhost:5001
```
FantasyWeelth> dotnet run
```
- Adding ```.gitignore, README.md``` files.
##### Note:  Before adding User Identity for login and Entity Framework let's change layout.cshtml and  update Bootstrap and jQuery of the MVC template. Using Bower but deprecated.
#### Manage client-side packages with Bower 
- Adding ```bower.json and .bowerrc``` files to add "bootstrap" , "jquery" to the dependencies.
- Run ```>bower install```
- Configure bundling and minification by adding ```bundleconfig.json``` at the root of the project. 
- ```dotnet add package BuildBundlerMinifier```
- ```dotnet build```
- adding ```font-awesome & popper.js``` by ```bower.json``` to run ```>bower install```.
- adding the font-awesome CSS popper.js files to the environment Tag Helper for Development and Production in ```_Layout.cshtml``` file.
- new looks by modifying _Layout.cshtml

### Hosting the ASP.NET Core MVC web app on Azure
Follow the below steps to push the application into Azure by  Azure CLI 2.0 & git
- ```> az login```
- ```> az webapp create --name "FantasyWealth" --resource-group "xxxxxxxxxxxxGroup" --plan "xxxxxxxxxxxxxPlan"```
- ```> az webapp deployment user set --user-name "xxxxxuser" --password "xxxxxxxpassword"```
