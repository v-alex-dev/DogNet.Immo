CREATE TABLE [dbo].[Realty]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY,
	[RealtyTypeId] INT NOT NULL, 
	[City] NVARCHAR(100) NOT NULL,
	[Price] DECIMAL (19,2) NOT NULL,
	[Area] INT NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
	[ForSale] BIT NOT NULL,
	[IsSold] BIT NOT NULL,
	[CreationDate] DATETIME2 NOT NULL,
	CONSTRAINT [FK_Realty_RealtyType] FOREIGN KEY ([RealtyTypeId]) REFERENCES [dbo].[RealtyType] ([Id])
)
