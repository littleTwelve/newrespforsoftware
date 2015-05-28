
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/27/2015 03:07:51
-- Generated from EDMX file: C:\Users\Administrator\documents\visual studio 2012\Projects\StudentGradeManagementSystem\StudentGradeManagementSystem\StudentGradeMS.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [StudentGradeMSDB3];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_GradeStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Grade集] DROP CONSTRAINT [FK_GradeStudent];
GO
IF OBJECT_ID(N'[dbo].[FK_GradeSubject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Grade集] DROP CONSTRAINT [FK_GradeSubject];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Grade集]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Grade集];
GO
IF OBJECT_ID(N'[dbo].[Student集]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Student集];
GO
IF OBJECT_ID(N'[dbo].[Subject集]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subject集];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Grade集'
CREATE TABLE [dbo].[Grade集] (
    [score] int IDENTITY(1,1) NOT NULL,
    [Student_studentID] int  NOT NULL,
    [Subject_subjectID] int  NOT NULL
);
GO

-- Creating table 'Student集'
CREATE TABLE [dbo].[Student集] (
    [studentID] int  NOT NULL,
    [studentName] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Subject集'
CREATE TABLE [dbo].[Subject集] (
    [subjectID] int  NOT NULL,
    [subjectName] nvarchar(max)  NOT NULL,
    [subjectType] nvarchar(max)  NOT NULL,
    [credit] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [score] in table 'Grade集'
ALTER TABLE [dbo].[Grade集]
ADD CONSTRAINT [PK_Grade集]
    PRIMARY KEY CLUSTERED ([score] ASC);
GO

-- Creating primary key on [studentID] in table 'Student集'
ALTER TABLE [dbo].[Student集]
ADD CONSTRAINT [PK_Student集]
    PRIMARY KEY CLUSTERED ([studentID] ASC);
GO

-- Creating primary key on [subjectID] in table 'Subject集'
ALTER TABLE [dbo].[Subject集]
ADD CONSTRAINT [PK_Subject集]
    PRIMARY KEY CLUSTERED ([subjectID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Student_studentID] in table 'Grade集'
ALTER TABLE [dbo].[Grade集]
ADD CONSTRAINT [FK_GradeStudent]
    FOREIGN KEY ([Student_studentID])
    REFERENCES [dbo].[Student集]
        ([studentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GradeStudent'
CREATE INDEX [IX_FK_GradeStudent]
ON [dbo].[Grade集]
    ([Student_studentID]);
GO

-- Creating foreign key on [Subject_subjectID] in table 'Grade集'
ALTER TABLE [dbo].[Grade集]
ADD CONSTRAINT [FK_GradeSubject]
    FOREIGN KEY ([Subject_subjectID])
    REFERENCES [dbo].[Subject集]
        ([subjectID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GradeSubject'
CREATE INDEX [IX_FK_GradeSubject]
ON [dbo].[Grade集]
    ([Subject_subjectID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------