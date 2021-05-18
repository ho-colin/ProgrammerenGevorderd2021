# Timing

Om een idee te hebben van de uitvoeringstijd van een method, start je de method met volgende code:

```c#
            var stopWatch = new Stopwatch();
            stopWatch.Start();
```

en sluit je de method af met deze code:

```C#
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            var ts = stopWatch.Elapsed;
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            System.Diagnostics.Debug.WriteLine("Running time: " + elapsedTime); // opgelet: print vertraagt!
```

