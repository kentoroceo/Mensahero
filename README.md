# Mensahero

<!-- PROJECT LOGO -->
<br />
<p align="center">
  <h3 align="center">Best-README-Template</h3>

  <p align="center">
    An awesome README template to jumpstart your projects!
    <br />
    <a href="https://github.com/othneildrew/Best-README-Template"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/othneildrew/Best-README-Template">View Demo</a>
    ·
    <a href="https://github.com/othneildrew/Best-README-Template/issues">Report Bug</a>
    ·
    <a href="https://github.com/othneildrew/Best-README-Template/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>



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

Just clone and run using Microsoft Visual Studio 


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



<!-- CONTACT -->
## Contact

Kent Oroceo - [LinkedIn](https://www.linkedin.com/in/kentoroceo/) - kjoroceo@yahoo.com
