CREATE TABLE [dbo].[Contact] (
    [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [FirstName]     NVARCHAR (MAX) NULL,
    [LastName]      NVARCHAR (MAX) NULL,
    [StreetAddress] NVARCHAR (MAX) NULL,
    [City]          NVARCHAR (MAX) NULL,
    [PostalCode]    NVARCHAR (MAX) NULL,
    [PhoneNumber]   NVARCHAR (MAX) NULL,
    [EmailAddress]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([Id] ASC)
);

