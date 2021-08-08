CREATE TABLE [dbo].[Languages] (
    [LanguageID]   INT           IDENTITY (1, 1) NOT NULL,
    [LanguageCode] VARCHAR (8)   NULL,
    [Name]         VARCHAR (100) NULL,
    [StateID]      INT           NULL,
    [UserID]       INT           NULL,
    PRIMARY KEY CLUSTERED ([LanguageID] ASC),
    CONSTRAINT [FK_IStateID] FOREIGN KEY ([StateID]) REFERENCES [dbo].[States] ([StateID]),
    CONSTRAINT [FK_IUserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);

