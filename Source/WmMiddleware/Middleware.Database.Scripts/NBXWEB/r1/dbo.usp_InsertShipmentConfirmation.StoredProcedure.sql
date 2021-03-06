USE [NBXWEB]
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertShipmentConfirmation]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_InsertShipmentConfirmation]
	@Date datetime
	,@ExternalUID varchar(30)
	,@ClientID varchar(10)
	,@ShipDate datetime
	,@PONumber varchar(30)
	,@PODate datetime
	,@Carrier varchar(15)
	,@WeighUOM varchar(10)
	,@TotalWeight float
	,@TotalShipped int      
	,@InterfaceUser1  varchar(256)     
	,@VendorID varchar(15)
	,@SKU varchar(30)						   
	,@UOM varchar(10)
	,@Qty int						 
	,@ParentMUID varchar(50)
	,@MUIDType varchar(50)
	,@DetailInterfaceUser1 varchar(256)
	,@DetailInterfaceUser2 varchar(256)
	,@DetailInterfaceUser3 varchar(256)          
	,@DetailInterfaceUser10 varchar(256)
     
AS
BEGIN

 declare @headerID int
 declare @ID table (ID int)


if(select count(*) from [InterfaceShipmentConfirmationHeader] where externaluid = @ExternalUID and status = 'Test') =0
	begin

			INSERT INTO [dbo].[InterfaceShipmentConfirmationHeader]
				([UpdateDate]
				,[UpdateUserID]
				,[UpdatePID]
				,[InsertDate]
				,[ExternalUID]
				,[ClientID]
				,[OrderDate]
				,[OrderType]
				,[OrderPriority]
				,[OrderStatus]
				,[ShipDate]
				,[ExpectedDeliveryDate]
				,[CustomerPORef]
				,[CustomerPODate]
				,[FacilityNbr]
				,[BillToCustomerID]
				,[ShipToCustomerID]
				,[CarrierCode]
				,[SCAC]
				,[BOL]
				,[WeightUOM]
				,[TotalWeightShipped]
				,[TotalUnitsShipped]           
				,[InterfaceUser1]         
				,[InterfaceStatus] 
				,[ActionCode]
				,[VendorID]
				,[ASNdirection]
				,[ASNfacilityNbr]        
				,[BuyerRefNbr]
				,[Status])
			--output inserted.IDInterfaceShipmentConfirmationHeader into @ID
			VALUES
				(@Date
				,'ASNImport'
				,'BSS'
				,@Date
				,@ExternalUID
				,@ClientID
				,@ShipDate
				,'01'
				,'76'
				,'73'
				,@ShipDate
				,@ShipDate
				,@PONumber
				,@PODate
				,'01'
				,@ClientID
				,@ClientID
				,@Carrier
				,@Carrier
				,@ExternalUID         
				,@WeighUOM
				,@TotalWeight
				,@TotalShipped       
				,@InterfaceUser1           
				,'NEW RECORD'          
				,'A'
				,@VendorID
				,'IN'
				,'01'
				,right(@PONumber, 15)
				,'TEST')
				--
			declare @hID int 
			set @hID = (select SCOPE_IDENTITY())
			set @headerID =(Select max(idinterfaceshipmentconfirmationheader) from dbo.[InterfaceShipmentConfirmationHeader] where  ExternalUID = @ExternalUID and status = 'TEST')
			--(select max(id) from @id)--(select  SCOPE_IDENTITY())
			--(Select max(idinterfaceshipmentconfirmationheader) from [InterfaceShipmentConfirmationHeader] where  ExternalUID = @ExternalUID and status = 'TEST')

			INSERT INTO [dbo].[InterfaceShipmentConfirmationDetail]
					([UpdateDate]
					,[UpdateUserID]
					,[UpdatePID]
					,[InsertDate]
					,[IDInterfaceShipmentConfirmationHeader]
					,[SKU]
					,[SKUClass]
					,[UPC]
					,[UOM]
					,[UnitsShipped]
					,[UnitsOrdered]
					,[ParentMUID]
					,[ParentMUType]
					,[VendorID]
					,[InterfaceUser1]
					,[InterfaceUser2]
					,[InterfaceUser3]
					,[InterfaceUser10]
					,[InterfaceStatus]         
					,[ExternalUID]
					,[ActionCode]
					,[Status])
				VALUES
					(@Date
					,'ASNImport'
					,'BSS'
					,@Date
					,@headerid
					,@SKU
					,'01'
					,@SKU
					,@UOM
					,@Qty
					,@Qty
					,@ParentMUID
					,@MUIDType
					,@ClientID
					,@DetailInterfaceUser1
					,@DetailInterfaceUser2
					,@DetailInterfaceUser3           
					,@DetailInterfaceUser10
					,'NEW RECORD'           
					,@ExternalUID
					,'A'
					,'TEST')
	end		   
else 
	if(select count(*) from InterfaceShipmentConfirmationHeader where ExternalUID = @ExternalUID and status = 'test') >0
	begin

		set @headerID = (Select max(IDInterfaceShipmentConfirmationHeader) from InterfaceShipmentConfirmationHeader where  Externaluid = @ExternalUID and status = 'test')

				INSERT INTO [dbo].[InterfaceShipmentConfirmationDetail]
					([UpdateDate]
					,[UpdateUserID]
					,[UpdatePID]
					,[InsertDate]
					,[IDInterfaceShipmentConfirmationHeader]
					,[SKU]
					,[SKUClass]
					,[UPC]
					,[UOM]
					,[UnitsShipped]
					,[UnitsOrdered]
					,[ParentMUID]
					,[ParentMUType]
					,[VendorID]
					,[InterfaceUser1]
					,[InterfaceUser2]
					,[InterfaceUser3]
					,[InterfaceUser10]
					,[InterfaceStatus]         
					,[ExternalUID]
					--,[ShipmentID]          
					,[ActionCode]
					,[Status])
				VALUES
					(@Date
					,'ASNImport'
					,'BSS'
					,@Date
					,@headerid
					,@SKU
					,'01'
					,@SKU
					,@UOM
					,@Qty
					,@Qty
					,@ParentMUID
					,@MUIDType
					,@ClientID
					,@DetailInterfaceUser1
					,@DetailInterfaceUser2
					,@DetailInterfaceUser3           
					,@DetailInterfaceUser10
					,'NEW RECORD'           
					,@ExternalUID
					,'A'
					,'TEST')
		end
	End

GO
