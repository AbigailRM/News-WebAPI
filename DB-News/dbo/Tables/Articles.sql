﻿CREATE TABLE [dbo].[Articles] (
    [ArticleID]    INT           IDENTITY (1, 1) NOT NULL,
    [Title]        VARCHAR (255) NULL,
    [AuthorID]     INT           NULL,
    [Description]  TEXT          NULL,
    [Content]      TEXT          NULL,
    [URLToArticle] VARCHAR (255) NULL,
    [URLToImage]   VARCHAR (255) NULL,
    [publishedAt]  DATETIME      NULL,
    [Uptake]       INT           NULL,
    [SourceID]     INT           NULL,
    [CategoryID]   INT           NULL,
    [CountryID]    INT           NULL,
    [LanguageID]   INT           NULL,
    [StateID]      INT           NULL,
    [SortID]       INT           NULL,
    [UserID]       INT           NULL,
    [CreateDate]   DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([ArticleID] ASC),
    CONSTRAINT [FK_ArSortID] FOREIGN KEY ([SortID]) REFERENCES [dbo].[SortBy] ([SortID]),
    CONSTRAINT [FK_ArStateID] FOREIGN KEY ([StateID]) REFERENCES [dbo].[States] ([StateID]),
    CONSTRAINT [FK_ArUserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID]),
    CONSTRAINT [FK_AuthorID] FOREIGN KEY ([AuthorID]) REFERENCES [dbo].[Authors] ([AuthorID]),
    CONSTRAINT [FK_CatgoriaID] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories] ([CategoryID]),
    CONSTRAINT [FK_CountryID] FOREIGN KEY ([CountryID]) REFERENCES [dbo].[Countries] ([CountryID]),
    CONSTRAINT [FK_LanguageID] FOREIGN KEY ([LanguageID]) REFERENCES [dbo].[Languages] ([LanguageID]),
    CONSTRAINT [FK_SourceID] FOREIGN KEY ([SourceID]) REFERENCES [dbo].[Sources] ([SourceID])
);
