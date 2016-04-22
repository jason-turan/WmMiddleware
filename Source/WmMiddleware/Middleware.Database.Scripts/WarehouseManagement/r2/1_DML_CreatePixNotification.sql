INSERT INTO [dbo].[Job]
           ([JobKey]
           ,[Schedule]
           ,[JobExecutable]
           ,[IsActive]
           ,[LastRunExecutionTime]
           ,[LastRunStatus]
           ,[LastRunDateTime]
           ,[NextRunDateTime]
           ,[JobType]
           ,[IsAlerted]
           ,[Description])
     VALUES
           ('PIX Notification Job',
		   '1M',
		   'Middleware.Wm.PixNotification.Exe',
		   1,
		   null,
		   null,
		   null,
		   null,
		   'Inventory Service',
		   0,
		   'Monitors the creation of pix files looking for PO Receipts, Returns, and Stocked events so that the inventory service can be notified')