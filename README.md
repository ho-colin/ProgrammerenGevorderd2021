# Programmeren Gevorderd Semester 2 DAG (2020- 2021)

## Vooraf: Tien Geboden

* [YouTube Video](https://www.youtube.com/watch?v=tNBln0tv6oE&list=PLM3q9wWBZWb-0G5rKQOVK-W0ihR5-561c&index=5&t=72s)
* Samengevat:
  1. **VS 2019 Enterprise** 16.8.0 en hoger
  2. **.NET 5.0** C#
  3. Gebruik het **unit testing** framework en geen console app, tenzij anders gevraagd; een console app mag wel bijkomend
  4. Een **bestand per klasse**
  5. **Method volledig zichtbaar** op je VS scherm
  6. Unit testing **code coverage: >= 80%**
  7. Voorzie je code van zinvolle **commentaar** en #region markeringen
  8. Plaats je properties eerst
  9. Gebruik een _ voor private variabelen

# .NET 5.0

* Installeer Visual Studio 2019 versie 16.8.0 of hoger (vandaag is de hoogste versie: 16.9.0 Preview 5.0)
* Opvolger .NET Core 3.1 en tegelijk het einde van de "Frameworks", .NET Core, Mono, enzovoort - voorbij met de hoofdpijn! Door COVID-19 zal pas .NET 6 in november 2021 de unificatiebeweging volledig afronden, inclusief .NET MAUI, de Universal UI, een evolutie van Xamarin.Forms, en ondersteuning voor Android en iOS.
* https://dotnet.microsoft.com/download/dotnet/5.0

## 1. Object oriented programming

1. We hernemen kort concepten reeds toegelicht in "Programmeren Basis":
   1. [OOP](./Documents/OOP.md)
   2. [Object als argument en return value](./Documents/Objecten.md)
   3. [Constructor, destructor](./Documents/Constructors.md)
   4. [Static](./Documents/Static.md)
2. [Overerving](./Documents/Overerving.md)
3. [Abstracte klassen](./Documents/AbstracteKlassen.md)
4. [Polymorfisme](./Documents/Polymorfisme.md)
5. [Null reference](./Documents/NullReference.md)
6. [System.Object](./Documents/SystemObject.md)
7. [Compositie](./Documents/Compositie.md)

## 2. Herhalingsoefening

* [Begeleide oefening: bierwinkel](./Documents/PG_OObasics_oef1_opdracht.pdf)

## 3. Exception handling

- [Werken met exceptions: een eerste kennismaking](./Documents/ExceptionHandling.md)

## 4. Interfaces

* [Werken met interfaces: verdieping](./Documents/Interfaces1.md)

## 5. Unit testing

### 5.1. MSTest v2

Bekijk volgende video's (YouTube):

  1. [Business code en test assemblies (12:13)](https://www.youtube.com/watch?v=ayJYhxs4e6I&list=PLM3q9wWBZWb-0G5rKQOVK-W0ihR5-561c&index=6&t=151s)
  2. [Code quality (3:51)](https://www.youtube.com/watch?v=WAVBJhTV4Ms&list=PLM3q9wWBZWb-0G5rKQOVK-W0ihR5-561c&index=7)
  3. [Running and debugging tests (8:20)](https://www.youtube.com/watch?v=tKhnw61JC6U&list=PLM3q9wWBZWb-0G5rKQOVK-W0ihR5-561c&index=8)
  4. [Test logger (2:01)](https://www.youtube.com/watch?v=mSJ3up_2Ecs&list=PLM3q9wWBZWb-0G5rKQOVK-W0ihR5-561c&index=9)
  5. [Assembly dependencies (1:37)](https://www.youtube.com/watch?v=pDinrXTXoI8&list=PLM3q9wWBZWb-0G5rKQOVK-W0ihR5-561c&index=10)
  6. [Unit testing snippets (4:58)](https://www.youtube.com/watch?v=3pyTcAzONMw&list=PLM3q9wWBZWb-0G5rKQOVK-W0ihR5-561c&index=11&t=39s)

Lees volgende pagina's:

  1. [Unit testing](./Documents/UnitTestingTDD2.md)
  2. [Test methods: beknopt overzicht](./Documents/UnitTestingTestMethods.pdf)

Oefen op volgende *walk through* en werk de oplossing zelfstandig uit met Visual Studio 2019:

  1. [Bank account: TDD](./Documents/UnitTestingWalkthrough.pdf)

### 5.2. xUnit

1. [Automated tests](./Documents/AutomatedTests.pdf)
2. [Test first](./Documents/TestFirst.pdf)
3. [xUnit en Visual Studio 2019: test frameworks en generatoren](./Documents/xUnit1.md)
4. [xUnit Cheat Sheet](./Documents/xUnit2.md)
5. [xUnit](./Documents/xUnitPart1.pdf)

## 6. Git

Bekijk volgende video's:

1. [Git in VS2019 (3:34)](https://www.youtube.com/watch?v=wQdGC8HvKBE&list=PLM3q9wWBZWb-0G5rKQOVK-W0ihR5-561c&index=1&t=2s)
2. [Git Commit (3:17)](https://www.youtube.com/watch?v=jYiIBGsu3SI&list=PLM3q9wWBZWb-0G5rKQOVK-W0ihR5-561c&index=2&t=22s)
3. [Git Push (1:12)](https://www.youtube.com/watch?v=yxJDqfXhNAQ&list=PLM3q9wWBZWb-0G5rKQOVK-W0ihR5-561c&index=3&t=1s)
4. [Git Command Line (1:56)](https://www.youtube.com/watch?v=npqBMnmahs4&list=PLM3q9wWBZWb-0G5rKQOVK-W0ihR5-561c&index=4&t=7s)

Raadpleeg volgende link voor meer informatie: [Werken met Git](./Documents/WerkenMetGit.md)

## 7. Lambda, delegate, event, extension method

1. [Presentatie](./Documents/DelegatesEvents.pdf)
2. Events: een eenvoudig voorbeeld en een vergelijking met werken via een interface
3. Video's: https://www.youtube.com/playlist?list=PLM3q9wWBZWb90CajLrVZcenmxIBCqyaFq (de twee laatste video's leggen oefening Klant/Ober/Kok uit, zie Presentatie)

## 8. IO

1. [Eerste stappen](./Documents/FileIO.md)
2. [Presentatie](./Documents/FileIO.pdf)
3. Maak volgende oefening:
   * [Adresinformatie](./Documents/OpgaveAdresinfo.md) met [invoergegevens](./Documents/adresInfo.zip)

## 9. LINQ

1. [Stap voor stap](./Documents/Linq.md)
2. [Oefening: SportsStore](./Documents/SportsStore.md)

## 10. C# voor gevorderden

1. [Null coalescing](./Documents/NullCoalescing.md)
2. [Null conditional operator](./Documents/NullConditionalOperator.md)
3. Condities: [switch statement](./Documents/switch.md)
4. [Willem Tell](./Documents/WillemTellTernary.md): speciale inheritance keywords, speciale operatoren zoals **ternary ?:**
5. [Culture](./Documents/Culture.md)
6. [Reflection](./Documents/Reflection.md)

## 12. ADO .NET

1. [Microsoft SQL Server](./Documents/InstallSqlExpress.md)
2. [ADO .NET: eerste stappen](./Documents/adonet1.md)
3. [ADO .NET: transacties](./Documents/adonetTransactions.md)
4. [DataSet, DataTable: disconnected](./Documents/adonet3.md)
5. [3-Tier model](./Documents/adonet2.md)
6. [Bulk upload](./Documents/ADONETBulkUpload.md)

## 13. WPF

### 13.1. Eerste stappen

1. [Walkthrough](./Documents/WPF/WPFIntro.md)
2. [Platform Uno of MAUI](./Documents/WPF/UnoOrMaui.md)
3. [Inleiding](./Documents/WPF/WPF_1_XAML.md)
4. Opzet voorbeeldapplicatie ["KlantenBeheer"](https://github.com/lucvervoort/ProgrammerenGevorderd2021Oefeningen/tree/main/KlantbeheerLes):
  - SQLServer databank
  - Repository: ADO .NET
  - Domeinlaag
  - xUnit test suite
  - Console app voor het opladen van informatie naar de databank of voor testen

### 13.2. Basis

1. [Events](./Documents/WPF/WPF_2_Events.md)              
2. [Application](./Documents/WPF/WPF_3_AppCommandLine.md)
3. [Resources](./Documents/WPF/WPF_4_Resources.md)   
  - Icoontjes: Build Action **"Content"**, **"Copy if newer"**
  - Icoontjes bij elke menu item
  - Icoon voor button: zie App.xaml, Resources (kan ook op niveau van venster)
  - Icoon voor venster        
4. [Exceptions](./Documents/WPF/WPF_5_Exceptions.md)
5. [Basic Controls](./Documents/WPF/WPF_6_ControlsBasic.md): Button, TextBlock, TextBox
6. [Layout Management](./Documents/WPF/WPF_7_LayoutManagement.md): Grid "basics"
7. [List Controls](./Documents/WPF/WPF_11_ControlsList.md): DataGrid "basics"
8. [Basic Controls](./Documents/WPF/WPF_6_ControlsBasic.md)
9. [Menu and Status Bar](./Documents/WPF/WPF_13_MenuStatusBar.md)
10. [Interfaces](./Documents/Interfaces1.md)
11. [MaterialDesign (14:02)](https://www.youtube.com/watch?v=F0V01mYER5E&list=PLM3q9wWBZWb-_ZzoI8AFDxJRLYWTXDyYE&index=1)
12. [Debugging (8:59)](https://www.youtube.com/watch?v=CHhgN5DoOMM&list=PLM3q9wWBZWb9ZkhEDkQLqQ43qtDSL_ANJ&index=1)
13. [Debugging Binding Problems (8:21)](https://www.youtube.com/watch?v=gr4Ye8EvvU0&list=PLM3q9wWBZWb9ZkhEDkQLqQ43qtDSL_ANJ&index=2)
14. [Debugging Binding Problems Revisited (3:37)](https://www.youtube.com/watch?v=TMpHLmDDwQo&list=PLM3q9wWBZWb9ZkhEDkQLqQ43qtDSL_ANJ&index=3)
15. [Styles (4:54)](https://www.youtube.com/watch?v=kC9-Xow-aEg&list=PLM3q9wWBZWb9ZkhEDkQLqQ43qtDSL_ANJ&index=4)
16. Optioneel: Sciensano 
  - [Deel 1](https://www.youtube.com/watch?v=RcGVsTkHRpY&list=PLM3q9wWBZWb-gcO0tYtviQsohiNkQZzqd&index=1&t=3s)
  - [Deel 2](https://www.youtube.com/watch?v=LPqaEm9ZWfE&list=PLM3q9wWBZWb-gcO0tYtviQsohiNkQZzqd&index=2)
  - [Deel 3](https://www.youtube.com/watch?v=p0DVhGSPne0&list=PLM3q9wWBZWb-gcO0tYtviQsohiNkQZzqd&index=3)
  - [WPF Covid Charts](https://www.youtube.com/watch?v=CzUEeWvsK18&list=PLM3q9wWBZWb_KX2UcyyFCXg1boSRP0N7N&index=2)

### 13.5. In de praktijk

* Zie voorbeeldapplicatie ["KlantBeheer"](https://github.com/lucvervoort/ProgrammerenGevorderd2021Oefeningen/tree/main/KlantbeheerLes):
  - Interfaces: hoe leg ik een "contract" op (ICrud)
  - Singleton patroon
  - ObservableCollection, IPropertyNotifyChanged: Mode=TwoWay
  - Een venster centraal op je scherm plaatsen
  - Layout management: Grid, DockPanel
  - Applicatie afsluiten bij het sluiten van het hoofdvenster
  - Nieuw venster openen en verbergen bij sluiten: notie UI-thread
  - Voorbeeld van een MessageBox: zie verwijder klant
  - Controleer TextBox per toetsaanslag om een knop beschikbaar te stellen of niet
  - Vertaling en taalinstelling:
    - public class in Translations.resx
    - Per alternatieve taal: een bijkomend .resx bestand zonder code behind
    - Editeer je vertalingen via Visual Studio
    - In App.xaml.cs (vergelijk globale exception handler): 

    ```c#
    Translations.Culture = new System.Globalization.CultureInfo("nl-BE"); // en-US nl-BE
    ```

### 13.6. Laatste loodjes

1. Zie voorbeeldapplicatie ["KlantBeheer"](https://github.com/lucvervoort/ProgrammerenGevorderd2021Oefeningen/tree/main/KlantbeheerLes):
  - DataGrid: hoe synchroniseren we met de databank?
2. [ValueConverter](./Documents/WPF/WPF_9_ValueConverter.md)
3. [Advanced Controls](./Documents/WPF/WPF_10_ControlsAdvanced.md)   
4. [List Controls](./Documents/WPF/WPF_11_ControlsList.md)
5. [Styles](./Documents/WPF/WPF_12_Styles.md)            
6. [Timer](./Documents/WPF/WPF_14_Timer.md)
7. Debugging en tracing met [SeriLog](https://serilog.net/): [een inleiding](./Documents/SeriLog.md)

## 14. "Booster" sessie

1. [Configuraties buiten je applicatie: gebruik app.config](./Documents/BoosterAppConfig.md)
2. [Snelle verwerking van grote XML bestanden](./Documents/XMLParsing.md)
3. [XUnit testing aan de hand van voorbeeldapplicatie "KlantBeheer"](./Documents/BoosterXUnit.md)
4. ADO .NET aan de hand van voorbeeldapplicatie ["KlantBeheer"](https://github.com/lucvervoort/ProgrammerenGevorderd2021Oefeningen/tree/main/KlantbeheerLes)
5. Optioneel: [Timing method](./Documents/Timing.md)

## 15. Optioneel

### WPF  MVVM

1. [MVVM](./Documents/BoosterMVVM.md)
2. [Command pattern](./Documents/WPF/CommandPattern.md)

### C# development

<!-- 1. [UML naar code](./Documents/UMLNaarCode.md) -->
1. [Debugging](./Documents/Debugging.md)
2. [Geheugen management](./Documents/GeheugenManagement.md)
3. [Parameters doorgeven by reference](./Documents/OutEnRef.md)
4. [Jagged arrays](./Documents/JaggedArrays.md)
5. [Nuget packages](./Documents/Nuget.md)
6. [Reguliere expressies](./Documents/Regex.md)
7. [Communicatie: TCP, UDP, websockets, beveiliging](./Documents/SimpleTCP.md)
8. Video's
  - [In, out, ref parameters, heap en stack geheugen (20:09)](https://www.youtube.com/watch?v=BpBc-Nhmlzk&list=PLM3q9wWBZWb_KX2UcyyFCXg1boSRP0N7N&index=1&t=338s)
9. [Generics](./Documents/Generics.md)
10. [C# 9.0](./Documents/Cs9.md)

### C# en SOLID

1. [Interfaces](./Documents/Interfaces1.md)
2. [5 principes](./Documents/SOLID.md)
3. [Microsoft IOC container](./Documents/MSIOCContainer.md): zie voorbeeldapplicatie ["KlantBeheer"](https://github.com/lucvervoort/ProgrammerenGevorderd2021Oefeningen/tree/main/KlantbeheerLes)
4. Meer informatie met betrekking tot IOC: zie [Unity](./Documents/Patterns/Ioc.md).

## 16. Nuttige extra's

* [Overzicht boeken, tutorials, websites, ...](./Documents/NuttigeExtras.md)

## Eindopdracht

1. [Beschrijving](./Documents/PG_Eval2_OpgaveAdresbeheer_001.pdf): zie ook Chamilo onder opdrachten
2. Tips
   1. Gebruik **XmlTextReader**, zie "booster" sessie hierboven
   2. Gebruik de **"bulk upload"** techniek beschreven in hoofdstuk ADO .NET
   3. **Meerlagig** (meer dan 3):
      1. console app voor het opladen van de gegevens
      2. domeinlaag voor de business logica
      3. ADO .NET repository
      4. unit test suite
      5. WPF      
   4. **WPF**: vrij, maar implementeer wat in de opdracht staat en lees deze dus goed!
      1. MaterialDesign wordt geapprecieerd, maar is niet verplicht     
      2. MVVM wordt geapprecieerd, maar is niet verplicht     
   5. Gebruik **Chamilo "Forum"** voor vragen in verband met eindevaluatie: informatie nuttig voor iedereen!

## Tussentijdse evaluatie

1. Scheepvaart: een herhalingsoefening
   * [Opdracht](./Documents/OpgaveCollections.pdf)
   * [Scheepvaart: analyse](./Documents/OefeningCollectionsOvererving.pdf)
2. [Code kata unit testing: een kleine vingeroefening](./Documents/unittestkata1.md)
3. [Winkelmanagement](./Documents/winkelmanagement.md)
4. [Oefening](./Documents/LinqOpgave.pdf): [gegevens](./Documents/LinqAdresInfo.txt)