#
dotnet new webapp -o WebApp

-------------------------
dotnet tool install -g dotnet-aspnet-codegenerator

dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Identity.UI
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools


dotnet aspnet-codegenerator identity -h
//dotnet aspnet-codegenerator identity --useDefaultUI
dotnet aspnet-codegenerator identity -dc WebApp.Data.AppDbContext --files "Account.Register;Account.Login"
dotnet aspnet-codegenerator identity -dc WebApp.Data.AppDbContext --files "Account.ConfirmEmail"

dotnet new gitignore