
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/04/2013 11:00:58
-- Generated from EDMX file: C:\Users\Lynart\Documents\Project LimitBreaker\App_Code\Layer2.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [bts530_123a01];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_LoggedExerciseSetAttributes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SetAttributes] DROP CONSTRAINT [FK_LoggedExerciseSetAttributes];
GO
IF OBJECT_ID(N'[dbo].[FK_ScheduledExerciseExercise]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduledExercises] DROP CONSTRAINT [FK_ScheduledExerciseExercise];
GO
IF OBJECT_ID(N'[dbo].[FK_ScheduledRoutineRoutine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduledRoutines] DROP CONSTRAINT [FK_ScheduledRoutineRoutine];
GO
IF OBJECT_ID(N'[dbo].[FK_ScheduledExerciseLimitBreaker]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduledExercises] DROP CONSTRAINT [FK_ScheduledExerciseLimitBreaker];
GO
IF OBJECT_ID(N'[dbo].[FK_LimitBreakerStatistics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LimitBreakers] DROP CONSTRAINT [FK_LimitBreakerStatistics];
GO
IF OBJECT_ID(N'[dbo].[FK_LimitBreakerRoutine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Routines] DROP CONSTRAINT [FK_LimitBreakerRoutine];
GO
IF OBJECT_ID(N'[dbo].[FK_LimitBreakerScheduledRoutine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduledRoutines] DROP CONSTRAINT [FK_LimitBreakerScheduledRoutine];
GO
IF OBJECT_ID(N'[dbo].[FK_LimitBreakerLoggedExercise]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LoggedExercises] DROP CONSTRAINT [FK_LimitBreakerLoggedExercise];
GO
IF OBJECT_ID(N'[dbo].[FK_ExerciseLoggedExercise]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LoggedExercises] DROP CONSTRAINT [FK_ExerciseLoggedExercise];
GO
IF OBJECT_ID(N'[dbo].[FK_ExerciseExerciseExp]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExerciseExps] DROP CONSTRAINT [FK_ExerciseExerciseExp];
GO
IF OBJECT_ID(N'[dbo].[FK_NotificationLimitBreaker]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notifications] DROP CONSTRAINT [FK_NotificationLimitBreaker];
GO
IF OBJECT_ID(N'[dbo].[FK_ExerciseGoalLimitBreaker]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExerciseGoals] DROP CONSTRAINT [FK_ExerciseGoalLimitBreaker];
GO
IF OBJECT_ID(N'[dbo].[FK_ExerciseGoalExercise]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExerciseGoals] DROP CONSTRAINT [FK_ExerciseGoalExercise];
GO
IF OBJECT_ID(N'[dbo].[FK_ExerciseRoutine_Exercise]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExerciseRoutine] DROP CONSTRAINT [FK_ExerciseRoutine_Exercise];
GO
IF OBJECT_ID(N'[dbo].[FK_ExerciseRoutine_Routine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExerciseRoutine] DROP CONSTRAINT [FK_ExerciseRoutine_Routine];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Exercises]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Exercises];
GO
IF OBJECT_ID(N'[dbo].[ScheduledExercises]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScheduledExercises];
GO
IF OBJECT_ID(N'[dbo].[LoggedExercises]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoggedExercises];
GO
IF OBJECT_ID(N'[dbo].[SetAttributes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SetAttributes];
GO
IF OBJECT_ID(N'[dbo].[ExerciseGoals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExerciseGoals];
GO
IF OBJECT_ID(N'[dbo].[Routines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Routines];
GO
IF OBJECT_ID(N'[dbo].[ScheduledRoutines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScheduledRoutines];
GO
IF OBJECT_ID(N'[dbo].[LevelFormulas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LevelFormulas];
GO
IF OBJECT_ID(N'[dbo].[ExperienceAtrophies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExperienceAtrophies];
GO
IF OBJECT_ID(N'[dbo].[Notifications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Notifications];
GO
IF OBJECT_ID(N'[dbo].[LimitBreakers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LimitBreakers];
GO
IF OBJECT_ID(N'[dbo].[Statistics]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Statistics];
GO
IF OBJECT_ID(N'[dbo].[ExerciseExps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExerciseExps];
GO
IF OBJECT_ID(N'[dbo].[ExerciseRoutine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExerciseRoutine];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Exercises'
CREATE TABLE [dbo].[Exercises] (
    [name] nvarchar(max)  NOT NULL,
    [equipment] nvarchar(max)  NULL,
    [videoLink] nvarchar(max)  NULL,
    [rep] bit  NOT NULL,
    [weight] bit  NOT NULL,
    [distance] bit  NOT NULL,
    [time] bit  NOT NULL,
    [enabled] bit  NOT NULL,
    [id] int IDENTITY(1,1) NOT NULL,
    [muscleGroups] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ScheduledExercises'
CREATE TABLE [dbo].[ScheduledExercises] (
    [startTime] datetime  NOT NULL,
    [needEmailNotification] bit  NOT NULL,
    [id] int IDENTITY(1,1) NOT NULL,
    [Exercise_id] int  NOT NULL,
    [LimitBreakers_id] int  NOT NULL
);
GO

-- Creating table 'LoggedExercises'
CREATE TABLE [dbo].[LoggedExercises] (
    [sets] int  NOT NULL,
    [timeLogged] datetime  NOT NULL,
    [note] nvarchar(max)  NULL,
    [id] bigint IDENTITY(1,1) NOT NULL,
    [LimitBreaker_id] int  NOT NULL,
    [Exercise_id] int  NOT NULL
);
GO

-- Creating table 'SetAttributes'
CREATE TABLE [dbo].[SetAttributes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [weight] int  NULL,
    [distance] float  NULL,
    [time] int  NULL,
    [reps] int  NULL,
    [LoggedExercise_id] bigint  NOT NULL
);
GO

-- Creating table 'ExerciseGoals'
CREATE TABLE [dbo].[ExerciseGoals] (
    [id] int IDENTITY(1,1) NOT NULL,
    [weight] int  NOT NULL,
    [distance] float  NOT NULL,
    [time] int  NOT NULL,
    [reps] int  NOT NULL,
    [achieved] bit  NOT NULL,
    [LimitBreaker_id] int  NOT NULL,
    [Exercise_id] int  NOT NULL
);
GO

-- Creating table 'Routines'
CREATE TABLE [dbo].[Routines] (
    [id] int IDENTITY(1,1) NOT NULL,
    [lastModified] datetime  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [LimitBreaker_id] int  NOT NULL
);
GO

-- Creating table 'ScheduledRoutines'
CREATE TABLE [dbo].[ScheduledRoutines] (
    [id] int IDENTITY(1,1) NOT NULL,
    [needEmailNotification] bit  NOT NULL,
    [startTime] datetime  NOT NULL,
    [Routine_id] int  NOT NULL,
    [LimitBreaker_id] int  NOT NULL
);
GO

-- Creating table 'LevelFormulas'
CREATE TABLE [dbo].[LevelFormulas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [maxLevel] int  NOT NULL,
    [expModifier] float  NOT NULL,
    [baseRequired] float  NOT NULL
);
GO

-- Creating table 'ExperienceAtrophies'
CREATE TABLE [dbo].[ExperienceAtrophies] (
    [id] int IDENTITY(1,1) NOT NULL,
    [graceDays] int  NOT NULL,
    [baseLoss] float  NOT NULL
);
GO

-- Creating table 'Notifications'
CREATE TABLE [dbo].[Notifications] (
    [id] int IDENTITY(1,1) NOT NULL,
    [dateCreated] datetime  NOT NULL,
    [dateToBeSent] datetime  NOT NULL,
    [message] nvarchar(max)  NOT NULL,
    [LimitBreaker_id] int  NOT NULL
);
GO

-- Creating table 'LimitBreakers'
CREATE TABLE [dbo].[LimitBreakers] (
    [id] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(max)  NOT NULL,
    [gender] nvarchar(max)  NOT NULL,
    [dateOfBirth] datetime  NOT NULL,
    [verified] bit  NOT NULL,
    [deactivated] bit  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [Statistics_id] int  NOT NULL
);
GO

-- Creating table 'Statistics'
CREATE TABLE [dbo].[Statistics] (
    [id] int IDENTITY(1,1) NOT NULL,
    [level] int  NOT NULL,
    [experience] float  NOT NULL,
    [weight] float  NOT NULL,
    [height] float  NOT NULL,
    [rmr] float  NOT NULL,
    [bmi] float  NOT NULL,
    [vo2MAX] float  NOT NULL
);
GO

-- Creating table 'ExerciseExps'
CREATE TABLE [dbo].[ExerciseExps] (
    [baseExperience] float  NOT NULL,
    [weightModifier] float  NOT NULL,
    [repModifier] float  NOT NULL,
    [distanceModifier] float  NOT NULL,
    [timeModifier] float  NOT NULL,
    [id] int IDENTITY(1,1) NOT NULL,
    [Exercise_id] int  NOT NULL
);
GO

-- Creating table 'ExerciseRoutine'
CREATE TABLE [dbo].[ExerciseRoutine] (
    [Exercises_id] int  NOT NULL,
    [Routines_id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Exercises'
ALTER TABLE [dbo].[Exercises]
ADD CONSTRAINT [PK_Exercises]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ScheduledExercises'
ALTER TABLE [dbo].[ScheduledExercises]
ADD CONSTRAINT [PK_ScheduledExercises]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'LoggedExercises'
ALTER TABLE [dbo].[LoggedExercises]
ADD CONSTRAINT [PK_LoggedExercises]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SetAttributes'
ALTER TABLE [dbo].[SetAttributes]
ADD CONSTRAINT [PK_SetAttributes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ExerciseGoals'
ALTER TABLE [dbo].[ExerciseGoals]
ADD CONSTRAINT [PK_ExerciseGoals]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Routines'
ALTER TABLE [dbo].[Routines]
ADD CONSTRAINT [PK_Routines]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ScheduledRoutines'
ALTER TABLE [dbo].[ScheduledRoutines]
ADD CONSTRAINT [PK_ScheduledRoutines]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'LevelFormulas'
ALTER TABLE [dbo].[LevelFormulas]
ADD CONSTRAINT [PK_LevelFormulas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ExperienceAtrophies'
ALTER TABLE [dbo].[ExperienceAtrophies]
ADD CONSTRAINT [PK_ExperienceAtrophies]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Notifications'
ALTER TABLE [dbo].[Notifications]
ADD CONSTRAINT [PK_Notifications]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'LimitBreakers'
ALTER TABLE [dbo].[LimitBreakers]
ADD CONSTRAINT [PK_LimitBreakers]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Statistics'
ALTER TABLE [dbo].[Statistics]
ADD CONSTRAINT [PK_Statistics]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ExerciseExps'
ALTER TABLE [dbo].[ExerciseExps]
ADD CONSTRAINT [PK_ExerciseExps]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Exercises_id], [Routines_id] in table 'ExerciseRoutine'
ALTER TABLE [dbo].[ExerciseRoutine]
ADD CONSTRAINT [PK_ExerciseRoutine]
    PRIMARY KEY NONCLUSTERED ([Exercises_id], [Routines_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LoggedExercise_id] in table 'SetAttributes'
ALTER TABLE [dbo].[SetAttributes]
ADD CONSTRAINT [FK_LoggedExerciseSetAttributes]
    FOREIGN KEY ([LoggedExercise_id])
    REFERENCES [dbo].[LoggedExercises]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LoggedExerciseSetAttributes'
CREATE INDEX [IX_FK_LoggedExerciseSetAttributes]
ON [dbo].[SetAttributes]
    ([LoggedExercise_id]);
GO

-- Creating foreign key on [Exercise_id] in table 'ScheduledExercises'
ALTER TABLE [dbo].[ScheduledExercises]
ADD CONSTRAINT [FK_ScheduledExerciseExercise]
    FOREIGN KEY ([Exercise_id])
    REFERENCES [dbo].[Exercises]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ScheduledExerciseExercise'
CREATE INDEX [IX_FK_ScheduledExerciseExercise]
ON [dbo].[ScheduledExercises]
    ([Exercise_id]);
GO

-- Creating foreign key on [Routine_id] in table 'ScheduledRoutines'
ALTER TABLE [dbo].[ScheduledRoutines]
ADD CONSTRAINT [FK_ScheduledRoutineRoutine]
    FOREIGN KEY ([Routine_id])
    REFERENCES [dbo].[Routines]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ScheduledRoutineRoutine'
CREATE INDEX [IX_FK_ScheduledRoutineRoutine]
ON [dbo].[ScheduledRoutines]
    ([Routine_id]);
GO

-- Creating foreign key on [LimitBreakers_id] in table 'ScheduledExercises'
ALTER TABLE [dbo].[ScheduledExercises]
ADD CONSTRAINT [FK_ScheduledExerciseLimitBreaker]
    FOREIGN KEY ([LimitBreakers_id])
    REFERENCES [dbo].[LimitBreakers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ScheduledExerciseLimitBreaker'
CREATE INDEX [IX_FK_ScheduledExerciseLimitBreaker]
ON [dbo].[ScheduledExercises]
    ([LimitBreakers_id]);
GO

-- Creating foreign key on [Statistics_id] in table 'LimitBreakers'
ALTER TABLE [dbo].[LimitBreakers]
ADD CONSTRAINT [FK_LimitBreakerStatistics]
    FOREIGN KEY ([Statistics_id])
    REFERENCES [dbo].[Statistics]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LimitBreakerStatistics'
CREATE INDEX [IX_FK_LimitBreakerStatistics]
ON [dbo].[LimitBreakers]
    ([Statistics_id]);
GO

-- Creating foreign key on [LimitBreaker_id] in table 'Routines'
ALTER TABLE [dbo].[Routines]
ADD CONSTRAINT [FK_LimitBreakerRoutine]
    FOREIGN KEY ([LimitBreaker_id])
    REFERENCES [dbo].[LimitBreakers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LimitBreakerRoutine'
CREATE INDEX [IX_FK_LimitBreakerRoutine]
ON [dbo].[Routines]
    ([LimitBreaker_id]);
GO

-- Creating foreign key on [LimitBreaker_id] in table 'ScheduledRoutines'
ALTER TABLE [dbo].[ScheduledRoutines]
ADD CONSTRAINT [FK_LimitBreakerScheduledRoutine]
    FOREIGN KEY ([LimitBreaker_id])
    REFERENCES [dbo].[LimitBreakers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LimitBreakerScheduledRoutine'
CREATE INDEX [IX_FK_LimitBreakerScheduledRoutine]
ON [dbo].[ScheduledRoutines]
    ([LimitBreaker_id]);
GO

-- Creating foreign key on [LimitBreaker_id] in table 'LoggedExercises'
ALTER TABLE [dbo].[LoggedExercises]
ADD CONSTRAINT [FK_LimitBreakerLoggedExercise]
    FOREIGN KEY ([LimitBreaker_id])
    REFERENCES [dbo].[LimitBreakers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LimitBreakerLoggedExercise'
CREATE INDEX [IX_FK_LimitBreakerLoggedExercise]
ON [dbo].[LoggedExercises]
    ([LimitBreaker_id]);
GO

-- Creating foreign key on [Exercise_id] in table 'LoggedExercises'
ALTER TABLE [dbo].[LoggedExercises]
ADD CONSTRAINT [FK_ExerciseLoggedExercise]
    FOREIGN KEY ([Exercise_id])
    REFERENCES [dbo].[Exercises]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ExerciseLoggedExercise'
CREATE INDEX [IX_FK_ExerciseLoggedExercise]
ON [dbo].[LoggedExercises]
    ([Exercise_id]);
GO

-- Creating foreign key on [Exercise_id] in table 'ExerciseExps'
ALTER TABLE [dbo].[ExerciseExps]
ADD CONSTRAINT [FK_ExerciseExerciseExp]
    FOREIGN KEY ([Exercise_id])
    REFERENCES [dbo].[Exercises]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ExerciseExerciseExp'
CREATE INDEX [IX_FK_ExerciseExerciseExp]
ON [dbo].[ExerciseExps]
    ([Exercise_id]);
GO

-- Creating foreign key on [LimitBreaker_id] in table 'Notifications'
ALTER TABLE [dbo].[Notifications]
ADD CONSTRAINT [FK_NotificationLimitBreaker]
    FOREIGN KEY ([LimitBreaker_id])
    REFERENCES [dbo].[LimitBreakers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_NotificationLimitBreaker'
CREATE INDEX [IX_FK_NotificationLimitBreaker]
ON [dbo].[Notifications]
    ([LimitBreaker_id]);
GO

-- Creating foreign key on [LimitBreaker_id] in table 'ExerciseGoals'
ALTER TABLE [dbo].[ExerciseGoals]
ADD CONSTRAINT [FK_ExerciseGoalLimitBreaker]
    FOREIGN KEY ([LimitBreaker_id])
    REFERENCES [dbo].[LimitBreakers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ExerciseGoalLimitBreaker'
CREATE INDEX [IX_FK_ExerciseGoalLimitBreaker]
ON [dbo].[ExerciseGoals]
    ([LimitBreaker_id]);
GO

-- Creating foreign key on [Exercises_id] in table 'ExerciseRoutine'
ALTER TABLE [dbo].[ExerciseRoutine]
ADD CONSTRAINT [FK_ExerciseRoutine_Exercise]
    FOREIGN KEY ([Exercises_id])
    REFERENCES [dbo].[Exercises]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Routines_id] in table 'ExerciseRoutine'
ALTER TABLE [dbo].[ExerciseRoutine]
ADD CONSTRAINT [FK_ExerciseRoutine_Routine]
    FOREIGN KEY ([Routines_id])
    REFERENCES [dbo].[Routines]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ExerciseRoutine_Routine'
CREATE INDEX [IX_FK_ExerciseRoutine_Routine]
ON [dbo].[ExerciseRoutine]
    ([Routines_id]);
GO

-- Creating foreign key on [Exercise_id] in table 'ExerciseGoals'
ALTER TABLE [dbo].[ExerciseGoals]
ADD CONSTRAINT [FK_ExerciseExerciseGoal]
    FOREIGN KEY ([Exercise_id])
    REFERENCES [dbo].[Exercises]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ExerciseExerciseGoal'
CREATE INDEX [IX_FK_ExerciseExerciseGoal]
ON [dbo].[ExerciseGoals]
    ([Exercise_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------