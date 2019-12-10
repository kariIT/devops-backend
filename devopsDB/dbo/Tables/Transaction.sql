CREATE TABLE [dbo].[Transaction] (
    [Id]        BIGINT       IDENTITY (1, 1) NOT NULL,
    [IBAN]      NCHAR (20)   NULL,
    [Amount]    DECIMAL (18) NULL,
    [TimeStamp] DATETIME     NULL,
    CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Transaction_Account] FOREIGN KEY ([IBAN]) REFERENCES [dbo].[Account] ([IBAN]) ON DELETE CASCADE ON UPDATE CASCADE
);

