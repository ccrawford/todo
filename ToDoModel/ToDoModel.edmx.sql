
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/09/2014 16:37:15
-- Generated from EDMX file: C:\Users\c.crawford\documents\visual studio 2013\Projects\ToDoModel\ToDoModel\ToDoModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserToDo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ToDos] DROP CONSTRAINT [FK_UserToDo];
GO
IF OBJECT_ID(N'[dbo].[FK_ToDoToDoEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ToDoEvents] DROP CONSTRAINT [FK_ToDoToDoEvent];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[ToDos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ToDos];
GO
IF OBJECT_ID(N'[dbo].[ToDoEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ToDoEvents];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [JoinDate] datetime  NOT NULL
);
GO

-- Creating table 'ToDos'
CREATE TABLE [dbo].[ToDos] (
    [ToDoId] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'ToDoEvents'
CREATE TABLE [dbo].[ToDoEvents] (
    [ToDoEventId] int IDENTITY(1,1) NOT NULL,
    [OccurredDttm] datetime  NOT NULL,
    [Rating] nvarchar(max)  NULL,
    [Comment] nvarchar(max)  NULL,
    [ToDoId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [ToDoId] in table 'ToDos'
ALTER TABLE [dbo].[ToDos]
ADD CONSTRAINT [PK_ToDos]
    PRIMARY KEY CLUSTERED ([ToDoId] ASC);
GO

-- Creating primary key on [ToDoEventId] in table 'ToDoEvents'
ALTER TABLE [dbo].[ToDoEvents]
ADD CONSTRAINT [PK_ToDoEvents]
    PRIMARY KEY CLUSTERED ([ToDoEventId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'ToDos'
ALTER TABLE [dbo].[ToDos]
ADD CONSTRAINT [FK_UserToDo]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserToDo'
CREATE INDEX [IX_FK_UserToDo]
ON [dbo].[ToDos]
    ([UserId]);
GO

-- Creating foreign key on [ToDoId] in table 'ToDoEvents'
ALTER TABLE [dbo].[ToDoEvents]
ADD CONSTRAINT [FK_ToDoToDoEvent]
    FOREIGN KEY ([ToDoId])
    REFERENCES [dbo].[ToDos]
        ([ToDoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ToDoToDoEvent'
CREATE INDEX [IX_FK_ToDoToDoEvent]
ON [dbo].[ToDoEvents]
    ([ToDoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------