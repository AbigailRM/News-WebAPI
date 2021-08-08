CREATE TABLE [dbo].[Categories] (
    [CategoryID] INT          IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (50) NULL,
    [StateID]    INT          NULL,
    [UserID]     INT          NULL,
    PRIMARY KEY CLUSTERED ([CategoryID] ASC),
    CONSTRAINT [FK_CStateID] FOREIGN KEY ([StateID]) REFERENCES [dbo].[States] ([StateID]),
    CONSTRAINT [FK_CUserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);

