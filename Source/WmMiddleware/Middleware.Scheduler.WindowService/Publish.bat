
sc \\STLMW01 stop "New Balance Warehouse Management Middleware"

timeout 10

xcopy /s /y Middleware.Scheduler.WindowService\* \\Stlmw01\d$\WmMiddleware\Scheduler

sc \\STLMW01 start "New Balance Warehouse Management Middleware"

pause