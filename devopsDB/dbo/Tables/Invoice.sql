CREATE TABLE [dbo].[Invoice] (
    [id]            BIGINT          IDENTITY (1, 1) NOT NULL,
    [InvoiceSender] VARCHAR (50)    NOT NULL,
    [RecipientName] VARCHAR (50)    NOT NULL,
    [RecipientIBAN] VARCHAR (18)    NOT NULL,
    [Reference]     VARCHAR (20)    NOT NULL,
    [InvoiceNumber] VARCHAR (10)    NOT NULL,
    [BIC]           VARCHAR (8)     NOT NULL,
    [Total]         DECIMAL (18, 2) NOT NULL,
    [DueDay]        DATETIME        NOT NULL,
    [Date]          DATETIME        CONSTRAINT [DF_Invoice_Date] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED ([id] ASC)
);

