CREATE TABLE [dbo].[Account] (
    [IBAN]       NCHAR (20)   NOT NULL,
    [Name]       VARCHAR (50) NOT NULL,
    [BankId]     BIGINT       NULL,
    [CustomerId] BIGINT       NULL,
    [Balance]    DECIMAL (18) NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([IBAN] ASC),
    CONSTRAINT [FK_Account_Bank] FOREIGN KEY ([BankId]) REFERENCES [dbo].[Bank] ([Id]),
    CONSTRAINT [FK_Account_Customer] FOREIGN KEY ([BankId]) REFERENCES [dbo].[Customer] ([Id]) ON DELETE CASCADE
);

