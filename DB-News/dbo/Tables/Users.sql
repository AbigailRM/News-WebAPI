CREATE TABLE [dbo].[Users] (
    [UserID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (255) NULL,
    [Password] VARCHAR (MAX) NULL,
    [StateID]  INT           NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_UStateID] FOREIGN KEY ([StateID]) REFERENCES [dbo].[States] ([StateID])
);

