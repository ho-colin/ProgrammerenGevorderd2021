# Debugging met SeriLog

## Installatie als nuget pakket(ten)

![image-20210505170104557](./image-20210505170104557.png)

## Configuratie in code (*object chaining*): zie App.xaml.cs

```c#
Log.Logger = new LoggerConfiguration().
MinimumLevel.Debug().
Enrich.WithProperty("Application", "Klantenbeheer").
Enrich.WithThreadId().
Enrich.WithMemoryUsage().                
//WriteTo.File(@"logs\Log_SerilogDemoWPF.txt", rollingInterval: RollingInterval.Day).
WriteTo.File(new CompactJsonFormatter(), @"logs\log.json", rollingInterval: RollingInterval.Hour).
WriteTo.Debug().
CreateLogger();
```

## Output

* Debug console

* Json bestand

* vele andere mogelijkheden!

  ## Afsluiten

  ```c#
  Log.CloseAndFlush();
  ```

