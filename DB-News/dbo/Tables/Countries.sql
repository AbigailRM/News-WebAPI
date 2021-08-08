CREATE TABLE [dbo].[Countries] (
    [CountryID]   INT            IDENTITY (1, 1) NOT NULL,
    [CountryCode] VARCHAR (10)   NULL,
    [Name]        NVARCHAR (250) NULL,
    [StateID]     INT            NULL,
    [UserID]      INT            NULL,
    PRIMARY KEY CLUSTERED ([CountryID] ASC),
    CONSTRAINT [FK_PStateID] FOREIGN KEY ([StateID]) REFERENCES [dbo].[States] ([StateID]),
    CONSTRAINT [FK_PUserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);

