CREATE TABLE [dbo].[Person] (
    [Id]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (MAX) NULL,
    [Age]  SMALLINT      NULL,
    [Psw]  VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id] ASC)
);

