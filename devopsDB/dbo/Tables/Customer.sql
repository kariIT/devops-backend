CREATE TABLE [dbo].[Customer] (
    [Id]        BIGINT       IDENTITY (1, 1) NOT NULL,
    [Firstname] VARCHAR (50) NULL,
    [Lastname]  VARCHAR (50) NULL,
    [BankId]    BIGINT       NULL,
    [Psw]       VARCHAR (50) NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Customer_Bank] FOREIGN KEY ([BankId]) REFERENCES [dbo].[Bank] ([Id]) ON DELETE CASCADE
);

