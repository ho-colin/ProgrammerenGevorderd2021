# Microsoft IOC Container

![image-20210502095531816](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\WPF\image-20210502095531816.png)

* Registratie in App.xaml.cs (vergelijk taalinstelling, globale exception handler): 

  ```c#
  ServiceCollection.AddTransient<IInterface, Class>()
  ```

* Elders ophalen van een nieuwe instantie van Class die IInterface implementeert: 

  ```c#
  ServiceProvider.GetRequiredService<IInterface>()
  ```

* 