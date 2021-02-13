# How history was written in Formula 1.
This repository contains an embedded web application that interacts with the MS SQL database
# Getting Started

### 1.Edit WebAPI config
Settings are located in appsettings.json.

* In file [appsettings.json](https://github.com/trueStape/testTask/blob/master/TestTaskForScience/appsettings.json) file, change the connection to the Server DataBase(variable "Server=").
```
For example : "TestTaskDb": "Server=DESKTOP-0000000;Database=TestTask;Trusted_Connection=True;MultipleActiveResultSets=true"
```

* In the wwwroot folder, modify the Site.js. file.You need to add the web path to the path variable.
```
For example : var path = "https://localhost:0000";
```
### 2.Code-first database migration
In Pacet Magager console generate database ```add-migration InitialMigration``` then ```update-database```

### 3.Run project

# Built With
* ASP.NET Core 3.0 WebAPI
* MS SQL

# Authors
* Yegor Oshlakov - [trueStape](https://github.com/trueStape)
