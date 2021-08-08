CREATE TABLE [dbo].[Sources] (
    [SourceID]   INT          IDENTITY (1, 1) NOT NULL,
    [NameSource] VARCHAR (30) NULL,
    [StateID]    INT          NULL,
    [UserID]     INT          NULL,
    PRIMARY KEY CLUSTERED ([SourceID] ASC),
    CONSTRAINT [FK_FStateID] FOREIGN KEY ([StateID]) REFERENCES [dbo].[States] ([StateID]),
    CONSTRAINT [FK_FUserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);

