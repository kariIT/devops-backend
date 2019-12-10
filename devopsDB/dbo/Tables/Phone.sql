CREATE TABLE [dbo].[Phone] (
    [Id]       BIGINT        IDENTITY (1, 1) NOT NULL,
    [Type]     VARCHAR (MAX) NULL,
    [Number]   VARCHAR (50)  NULL,
    [PersonId] BIGINT        NULL,
    CONSTRAINT [PK_Phone] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Phone_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

