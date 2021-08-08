CREATE TABLE [dbo].[SortBy] (
    [SortID]  INT           IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (200) NULL,
    [StateID] INT           NULL,
    [UserID]  INT           NULL,
    PRIMARY KEY CLUSTERED ([SortID] ASC),
    CONSTRAINT [FK_SortStateID] FOREIGN KEY ([StateID]) REFERENCES [dbo].[States] ([StateID]),
    CONSTRAINT [FK_SortUserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);

