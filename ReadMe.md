# Unity with NLog Sample for ASP.NET Web API 2.x

1. Add NuGet packages:
    - Unity.AspNet.WebApi
    - Unity.Mvc (do not overwrite UnityConfig)
    - Unity.NLog
    - NLog.Config
2. Add following to Models folder
    - Product
    - IProductRepository
    - ProductRepository
3. Add ProductsController
    - Inject IProductRepository
4. Add following to `UnityConfig.RegisterTypes`
    ```csharp
    container.RegisterType<IProductsRepository, ProductsRepository>(new PerRequestLifetimeManager())
    ```
5. In NLog.config uncomment File target and logger rule.

6. Add following code to `UnityConfig`:
    ```csharp
    container.AddNewExtension<NLogExtension>();
    ```
7. Inject `ILogger` into `ProductController`.
    - Call `_logger.Log` in the `Get` action.
8. Add `NLogExceptionLogger` class to an Infrastructure folder.
    ```csharp
    public class NLogExceptionLogger : ExceptionLogger
    {
        private readonly ILogger _logger;

        public NLogExceptionLogger(ILogger logger)
        {
            _logger = logger;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            _logger.Log(LogLevel.Error, context.Exception);
        }
    }
    ```
9. Add following to `UnityConfig.RegisterTypes`
    ```csharp
    container.RegisterType<IProductsRepository, ProductsRepository>(new PerRequestLifetimeManager())
    ```
10. Add following to `WebApiConfig.Register`:
    ```csharp
    container.RegisterType<IExceptionLogger, NLogExceptionLogger>(new ContainerControlledLifetimeManager());
    ```
11. Throw an exception in `Get(int id)` in `ProductController`.
    - The info and exception should both appear in the logs folder log file.

