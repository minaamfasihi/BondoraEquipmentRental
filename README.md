# Bondora Equipment Rental Service

Bondora Equipment Rental Platform where you can rent out different equipments.

The complete solution is built in a two-tier fashion with the frontend in ASP.NET MVC and backend in C# (console application). These are two separate projects and must be run separately.
There is also a third project titled `BondoraTests` where all the unit tests are present.
 
How to Run:

1. The backend titled `Bondora` should be run as a console app. 
2. The web frontend titled `Frontend` should be run on IIS. You can run it in Visual Studio. 
3. The unit test project titled `BondoraTests` can be run inside Visual Studio.
4. MSMQ's are required for both backend and frontend. 
5. When you launch the web frontend, you can go to the Equipments page to see all the equipments. Equipments are loaded from a text file titled `inventory.txt` which is inside the `<path-to-frontend>\bin\Debug\netcoreapp3.1` directory. This file could also have been placed somewhere more general. 
6. Select the number of days you rent the equipment for. Click `Add to Cart`. Once you are done adding items to the cart, click on `Go to Cart`.
7. Cart is stored in `HttpContext.Session`. Since complex objects are not allowed, cart is serialized into a JSON string and then stored in the session. When you go to your cart, the cart is read from session as a string, deserialized as a Cart object and then listed.  
8. Now your cart will be listed. Click on `Generate Invoice` to generate the invoice. Once you click on `Generate Invoice`, the cart is serialized into a JSON and sent to an MSMQ for the backend service to consume. On the backend service side, there is a background thread that is listening on messages on this queue. As soon as a message arrives, the thread calls the method to process the message using a delegate. 
9. The invoice file is titled `Invoice.txt` and it will reside in `C:\Bondora\Invoices\Invoice.txt`. So you might have to make the folders `C:\Bondora` and `C:\Bondora\Invoices`.

Bonus:
1. Message based architecture is used such that the communication between web frontend and backend happens through message queues (MSMQ) which are scalable and efficient. We could have used other queues or message brokers but MSMQ seemed like a pretty decent option.
2. Logging is added. log4net is used for this purpose. ConsoleAppender, FileAppender and RollingFileAppender are used. Logs are generated in `C:\Logs`.
3. Caching is used to list the equipments. For the first time, the equipments are read from a text file. Once that is done, the equipments are stored in a cache for 3600 seconds (1 hour). This value can be changed. All subsequent requests to list equipments are served through the cache (for 3600 seconds).
4. Dependency Injection is used to inject the dependency of IEquipmentRepository in EquipmentController. We can swap out the repository with any other data source (file, database, cache etc.). DI is also used for caching inside equipments controller. 
5. UI uses bootstrap. 
