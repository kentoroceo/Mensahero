# Mensahero

<!-- PROJECT LOGO -->
<br />
<p align="center">
  
<!-- ABOUT THE PROJECT -->
## About The Project

  Chat Application with basic CRUD functionalities. Planning to add more features and signalR for real time notifications.

### Built With

* [Bootstrap]
* [C#]
* [ASP.NET]
* [.NET CORE 5]

<!-- GETTING STARTED -->
## Getting Started

* Clone
* Setup Database 
* Manually add atleast one user to database
* Open Mensahero.sln (might need to set mensahero as start up project)
* Run using Microsoft Visual Studio


<!-- SQL DATABASE CREATE -->
## MSSSQL Database Script
 
```sh
  IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NULL,
    [Passowrd] nvarchar(max) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210616092302_addUserToDatabase', N'5.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Message] (
    [Id] int NOT NULL IDENTITY,
    [FromUserId] nvarchar(max) NULL,
    [ToUserId] nvarchar(max) NULL,
    [Text] nvarchar(max) NULL,
    [TimeStamp] datetime2 NOT NULL,
    CONSTRAINT [PK_Message] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210616225653_addMessageToDatabase', N'5.0.7');
GO

COMMIT;
GO


  ```

  <!-- USAGE EXAMPLES -->
## Usage

Login



<!-- CONTACT -->
## Contact

Kent Oroceo - [LinkedIn](https://www.linkedin.com/in/kentoroceo/) - kjoroceo@yahoo.com