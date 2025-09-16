USE [TestDB]
GO

CREATE TABLE [dbo].[BT_Product](
	[Id] [int] NOT NULL identity(1,1) primary key,
	[Code] [int] NOT NULL unique,
	[FullName] [varchar](250) NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[InternalReference] [varchar](100) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[Estate] [bit] NOT NULL,
	[MeassureUnit] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT CHK_invalidDate CHECK (CreatedDate >= GETDATE())
) 
GO

CREATE OR ALTER PROCEDURE BT_CreateProduct
	@Code int ,
	@FullName varchar(250),
	@Description varchar(250),
	@InternalReference varchar(100),
	@UnitPrice decimal(18, 2),
	@Estate bit ,
	@MeassureUnit varchar(50),
	@CreatedDate datetime 
as
begin

	INSERT INTO [dbo].[BT_Product]
           ([Code]
           ,[FullName]
           ,[Description]
           ,[InternalReference]
           ,[UnitPrice]
           ,[Estate]
           ,[MeassureUnit]
           ,[CreatedDate])
     output inserted.Id
     VALUES
           (@Code,
           @FullName,
           @Description,
           @InternalReference,
           @UnitPrice,
           @Estate,
           @MeassureUnit,
           @CreatedDate)

    
end
GO

CREATE OR ALTER PROCEDURE BT_DeleteProduct
	@Code int 
as
begin

	DELETE FROM [dbo].[BT_Product]
	WHERE Code = @Code

    SELECT @@ROWCOUNT;
end
GO



CREATE OR ALTER PROCEDURE BT_SelectProduct
	@Code int null
as
begin

	SELECT [Id]
      ,[Code]
      ,[FullName]
      ,[Description]
      ,[InternalReference]
      ,[UnitPrice]
      ,[Estate]
      ,[MeassureUnit]
      ,[CreatedDate]
  FROM [dbo].[BT_Product]
	where (@Code IS NULL OR Code = @Code)

end
GO




CREATE OR ALTER PROCEDURE BT_UpdateProduct
@Code int ,
@FullName varchar(250),
@Description varchar(250),
@InternalReference varchar(100),
@UnitPrice decimal(18, 2),
@Estate bit ,
@MeassureUnit varchar(50),
@CreatedDate datetime 
as
begin

UPDATE [dbo].[BT_Product]
   SET [FullName] = @FullName
      ,[Description] = @Description
      ,[InternalReference] = @InternalReference
      ,[UnitPrice] = @UnitPrice
      ,[Estate] = @Estate
      ,[MeassureUnit] = @MeassureUnit
      ,[CreatedDate] = @CreatedDate
 WHERE [Code] = @Code

  SELECT @@ROWCOUNT;

end
GO


select * from [dbo].[BT_Product]