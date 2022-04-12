CREATE TABLE [dbo].[RealtyUser]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[RealtyId] INT NOT NULL,
	[UserId] INT NOT NULL,
	CONSTRAINT [FK_RealtyUser_Realty] FOREIGN KEY ([RealtyId]) REFERENCES [dbo].[Realty]([Id]),
	CONSTRAINT [FK_RealtyUser_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([Id])
)
