CREATE TABLE [dbo].[Authors] (
    [AuthorID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (255) NULL,
    [LastName] NVARCHAR (255) NULL,
    [StateID]  INT            NULL,
    [UserID]   INT            NULL,
    PRIMARY KEY CLUSTERED ([AuthorID] ASC),
    CONSTRAINT [FK_AStateID] FOREIGN KEY ([StateID]) REFERENCES [dbo].[States] ([StateID]),
    CONSTRAINT [FK_AUserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);

