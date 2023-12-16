# A Blazor server app with Electron.Net


## Create a new Blazor app

1. Create a blazor app from template
```ps1
PM> dotnet new blazorserver
```

https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows


### Optional: Add a UI component library

Go to https://github.com/MudBlazor/MudBlazor/ and follow instructions, or use their new .Net 8 template 

```ps1
dotnet new mudblazor --host server --name MyApplication
```


https://github.com/MudBlazor/Templates

## Pack it as a desktop app using ElectronNet

1. Install nuget package
```ps1
PM> Install-Package ElectronNET.API
```

2. Modify Program.cs

```csharp	
using ElectronNET.API;
using ElectronNET.API.Entities;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseElectron(args);

// Is optional, but you can use the Electron.NET API-Classes directly with DI (relevant if you wont more encoupled code)
builder.Services.AddElectron();

var app = builder.Build();

...

await app.StartAsync();

// Open the Electron-Window here
await Electron.WindowManager.CreateWindowAsync();

app.WaitForShutdown();
```

3. Add Electron configuration files

```sh
dotnet tool install ElectronNET.CLI -g
```

At the first time, you need an Electron.NET project initialization. Type the following command in your ASP.NET Core folder:

```sh
electronize init
```


4. Publish

```sh
electronize build /target win
```


https://github.com/ElectronNET/Electron.NET