USE [aspnet-GUI_Assignment2_Breakfast_Group19-91766602-056B-42B4-A7BC-2A5A2B35AA6C]
GO

/****** Object: Table [dbo].[Room] Script Date: 20-04-2021 17:27:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Room];


GO
CREATE TABLE [dbo].[Room] (
    [RoomId]                  INT IDENTITY (1, 1) NOT NULL,
    [RoomNumber]              INT NOT NULL,
    [Adults]                  INT NOT NULL,
    [Children]                INT NOT NULL,
    [ArrivalsAtBreakfastId]   INT NULL,
    [BreakfastReservationsId] INT NULL
);

USE [aspnet-GUI_Assignment2_Breakfast_Group19-91766602-056B-42B4-A7BC-2A5A2B35AA6C]
GO

/****** Object: Table [dbo].[ArrivalsAtBreakfast] Script Date: 20-04-2021 17:28:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[ArrivalsAtBreakfast];


GO
CREATE TABLE [dbo].[ArrivalsAtBreakfast] (
    [ArrivalsAtBreakfastId] INT           IDENTITY (1, 1) NOT NULL,
    [Date]                  DATETIME2 (7) NOT NULL
);




USE [aspnet-GUI_Assignment2_Breakfast_Group19-91766602-056B-42B4-A7BC-2A5A2B35AA6C]
GO

/****** Object: Table [dbo].[BreakfastReservations] Script Date: 20-04-2021 17:28:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[BreakfastReservations];


GO
CREATE TABLE [dbo].[BreakfastReservations] (
    [BreakfastReservationsId] INT           IDENTITY (1, 1) NOT NULL,
    [Date]                    DATETIME2 (7) NOT NULL
);


