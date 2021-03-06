USE [NBXWEB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetNewOrders]    Script Date: 2/25/2016 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[sp_GetNewOrders] AS
-- disabled this section due to issues in  NBD-12658 

--update gp_header
--set cadrestatus = 'VERIFY'
--where order_number in (
----select distinct(h.order_number)
----from gp_header h
----inner join GP_line_items d
----on  h.[order_number] = d.[order_number] and h.company = d.company
----inner join integrationfrauddetection i
----on h.company = i.sitecode
----where d.cadrestatus = 'new' AND(h.[shipping_method] <> 'RETURN' and h.[shipping_method] <> 'SALE' ) and h.[payment_only] <> 'yes' and trans_type <> 'return' and d.return_to = ''
---- and  sub_total > total and ((total/sub_total)-1)*-1*100 > i.maxpercentageallowed)

--select distinct h.order_number
--from gp_header h
--left join GP_line_items d
--on  h.order_number = d.[order_number] and h.company = d.company
--where 
--d.cadrestatus = 'NEW' AND
--(h.[shipping_method] <> 'RETURN' and h.[shipping_method] <> 'SALE' ) 
--and h.[payment_only] <> 'yes' and trans_type <> 'return' 
--and d.return_to = '' 
--and h.company='JNBO' and h.order_source = 'web'
--and convert(varchar(10),left(h.[order_number],8)) in 
--(select convert(varchar(10),o.[order_number]) from [172.28.1.136].nbdb.dbo.vdw_Orders o
--where ((o.[sub_total] > o.[order_total]) and (o.[sub_total] > 0)) and (((o.[order_total])/(o.[sub_total]))-1)*-1*100 >=21 
--and o.[date_ordered] >=dateadd(d,-5,getdate())))

-- update GP_line_items
-- set CadreStatus = 'VERIFY'
-- where order_number in (
-- select distinct h.order_number
--from gp_header h
--left join GP_line_items d
--on  h.order_number = d.[order_number] and h.company = d.company
--where 
--d.cadrestatus = 'NEW' AND
--(h.[shipping_method] <> 'RETURN' and h.[shipping_method] <> 'SALE' ) 
--and h.[payment_only] <> 'yes' and trans_type <> 'return' 
--and d.return_to = '' 
--and h.company='JNBO' and h.order_source = 'web'
--and convert(varchar(10),left(h.[order_number],8)) in 
--(select convert(varchar(10),o.[order_number]) from [172.28.1.136].nbdb.dbo.vdw_Orders o
--where ((o.[sub_total] > o.[order_total]) and (o.[sub_total] > 0)) and (((o.[order_total])/(o.[sub_total]))-1)*-1*100 >21 
--and o.[date_ordered] >=dateadd(d,-5,getdate())))


-- select distinct(h.order_number)
--from gp_header h
--inner join GP_line_items d
--on  h.[order_number] = d.[order_number] and h.company = d.company
--inner join integrationfrauddetection i
--on h.company = i.sitecode
--where d.cadrestatus = 'new' AND(h.[shipping_method] <> 'RETURN' and h.[shipping_method] <> 'SALE') and h.[payment_only] <> 'yes' and trans_type <> 'return' and d.return_to = ''
-- and  sub_total > total and ((total/sub_total)-1)*-1*100 > i.maxpercentageallowed)

SELECT h.[auto_id] as HeaderId
       ,h.[company] AS Company
       ,h.[order_number] as OrderNumber
       ,h.[order_date] as OrderDate
       ,h.[date_downloaded] as HeaderDownloadDate
       ,h.[customer_number] as CustomerNumber
       ,h.[order_priority] as OrderPriority
       ,h.[bill_name] as BillingName
       ,h.[bill_address] as BillingAddress1
       ,h.[bill_address2] as BillingAddress2
       ,h.[bill_address3] as BillingAddress3
       ,h.[bill_city] as BillingCity
       ,h.[bill_state] as BillingState
       ,h.[bill_zip] as BillingZip
       ,h.[bill_country] as BillingCountry
       ,h.[bill_phone] as BillingPhone
       ,h.[ship_name] as ShippingName
       ,h.[ship_address] as ShippingAddress1
       ,h.[ship_address2] as ShippingAddress2
       ,h.[ship_address3] as ShippingAddress3
       ,h.[ship_city] as ShippingCity
       ,h.[ship_state] as ShippingState
       ,h.[ship_zip] as ShippingZip
       ,h.[ship_country] as ShippingCountry
       ,h.[ship_phone] as ShippingPhone
       ,h.[email_address] as EmailAddress
       ,h.[trans_type] as TransactionType
       ,h.[shipping_method] as ShippingMethod
       ,h.[sub_total] as Subtotal
       ,h.[discount] as Discount
       ,h.[freight] as Freight
       ,h.[misc_handling] as MiscHandling
       ,h.[tax_amount] as TaxAmount
       ,h.[total] as Total
       ,h.[original_order] as OriginalOrder
       ,h.[payment_only] as PaymentOnly
       ,h.[GP_status] as HeaderGPStatus
		/* staged for bs-1348, go live slated for 9/7*/
		--,case when ic.gender <> 'men' and h.company = 'NBWE' and getdate() >= '09/05/2015 12:00:00' then 'Insert Womens Catalog'
		--else isnull(os.overridemessage, h.[shipping_note]) end as ShippingNote

		, case 
		when os.OverrideMessage is not null then os.OverrideMessage
		when ic.gender <> 'men' and h.company = 'NBWE' and getdate() >= '09/05/2015 12:00:00' then 'Insert Womens Catalog'
		else h.shipping_note end as ShippingNote
		--isnull(os.overridemessage, case when ic.gender <> 'men' and h.company = 'NBWE' and getdate() >= '09/05/2015 12:00:00' then 'Insert Womens Catalog'
		/* end of bs-1348*/
		-- comment this out when bs-1348 is pushed
		--,isnull(os.overridemessage, h.[shipping_note])  as ShippingNote
       --,h.[shipping_note]  as ShippingNote
       ,h.[gift_message_1] as GiftMessage1
       ,h.[gift_message_2] as GiftMessage2
       ,h.[order_source] as OrderSource
       ,h.[payment_applied] as PaymentApplied
       ,h.[DIS_when_downloaded] as HeaderDISDownloadedWhen
       ,h.[DIS_readyfor_download] as HeaderDISDownloadReady
       ,h.[DIS_row_downloaded] as HeaderDISRowDownloaded
       ,h.[CadreStatus] as HeaderCadreStatus
       ,d.[item_number] as ItemNumber
       ,d.[item_sku] as ItemSKU
       ,d.[item_descrip] as ItemDescription
       ,d.[qty] as Quantity
       ,d.[unit_of_measure] as UnitsOfMeasure
       ,d.[each_price] as EachPrice
       ,d.[item_discount] as ItemDiscount
       ,d.[ext_price] as ExtendedPrice
       ,d.[item_comments] as ItemComments
       ,d.[inventory_type] as InventoryType
       ,d.[return_to] as ReturnTo
       ,d.[ship_date] as ShipDate
       ,d.[GP_status] as DetailGPStatus
       ,d.[DIS_row_downloaded] as DetailDISRowDownloaded
       ,d.[DIS_when_downloaded] as DetailDISDownloadedWhen
       ,d.[DIS_readyfor_download] as DetailDISDownloadReady
       ,d.[CadreStatus] as DetailCadreStatus
	   --Dviano - 12/1/2015 need more product fields for PickTicket Details
	   ,SUBSTRING(ic.[Style],1,2) AS SeasonYear
	   ,SUBSTRING(ic.[Style],3,7) AS Style
	   ,ic.[Attr] AS Color
	   ,ic.[Size] AS Size
  FROM [NBXWEB].[dbo].[GP_header] h with(nolock)
  LEFT JOIN [NBXWEB].[dbo].[GP_line_items] d with(nolock)
    ON h.[order_number] = d.[order_number] and h.company = d.company
	left join NBXWEB.dbo.overrideshipmentnote os with(nolock)
	on os.upc = d.item_sku
	/* added for bs-1348*/
	--left join nbsnb.dbo.nbwe_inventory_cache ic with(nolock)
	left join NBXWEB.dbo.nbwe_inventory_cache ic with(nolock) --DVIANO - 11/30/2015 FOR TESTING PURPOSES
	on d.item_sku = ic.sku 
  WHERE 
  d.cadrestatus in( 'NEW','APPROVED') AND (h.[shipping_method] <> 'RETURN' and h.[shipping_method] <> 'SALE' AND h.[shipping_method] <> 'DROP' and d.inventory_type <> 'drop' and d.inventory_type <> 'FR' and d.inventory_type <> 'KOMEN' and d.inventory_type <> 'CUSTOM' and d.inventory_type <> 'fullcustom' and d.inventory_Type <> 'PZ' ) and h.[payment_only] <> 'yes' and trans_type <> 'return' and d.return_to = ''
  --DVIANO - 12/1/2015 use the header status for testing purposes. 
  --h.cadrestatus in( 'NEW','APPROVED') AND (h.[shipping_method] <> 'RETURN' and h.[shipping_method] <> 'SALE' AND h.[shipping_method] <> 'DROP' and d.inventory_type <> 'drop' and d.inventory_type <> 'FR' and d.inventory_type <> 'KOMEN' and d.inventory_type <> 'CUSTOM' and d.inventory_type <> 'fullcustom' and d.inventory_Type <> 'PZ' ) and h.[payment_only] <> 'yes' and trans_type <> 'return' and d.return_to = ''








GO
