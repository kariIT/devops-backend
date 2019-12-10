CREATE TABLE [dbo].[Bank] (
    [Id]   BIGINT       IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    [BIC]  NCHAR (8)    NULL,
    CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED ([Id] ASC)
);

