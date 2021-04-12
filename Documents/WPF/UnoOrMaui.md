**Platform Uno or MAUI? Nog onduidelijk...**

Xamarin.Forms (krijgt de naam MAUI) bestaat reeds langer, alleszins meer dan 5 jaar. 

De punten van gelijkenis:

- In beide gevallen betreft het C# Cross Platform Frameworks
- **Beide ondersteunen XAML**
- Beide ondersteunen iOS, Android, Universal Windows Platform, en (in mindere mate) Mac OS via non-.Forms Xamarin platform frameworks
- Xamarin.Essentials werkt met Xamarin en Uno op hierboven vermelde platformen
- Geen van beide ondersteunt van huize uit Printing, PDF generatie of PNG generatie.

De verschillen:

- Architecturaal is Xamarin.Forms een eigen abstractielaag boven native APIs, terwijl Uno UWP interfaces implementeert bovenop de native APIs. Dit laatste maakt een belangrijk verschil om drie verschillende redenen:
  - In Android omvat de abstractie van Xamarin.Forms het meet- en opmaakbeheer. Dit is ZEER KOSTELIJK en resulteert  voor alle behalve de meest eenvoudige lijstweergaven in zeer slechte prestaties. Uno, daarentegen, voert meet- en opmaakbeheer uit in de native laag - en vermijdt zo buitensporig veel heen en weer verkeer tussen Java en C#.
  - In WASM rendert Xamarin via Blazor - wat hybride server / client applicaties mogelijk maakt. Helaas voegt dit complexiteit toe in vergelijking met de aanpak van Uno. Blijft nog te bezien of de Xamarin aanpak een performantienadeel heeft.
  - Omdat Uno UWP implementeert bovenop de native UI frameworks, is het vrij makkelijk om diepgaande wijzigingen onder de motorkap aan te brengen. Het is veel moeilijker (zo niet onmogelijk in sommige gevallen) om dat in Xamarin.Forms te doen.
- Uno kan gebruikt worden op Windows 7, Tizen en Linux (GTK).
- Uno ondersteunt de complexiteit van UWP XAML: dit is een groot voordeel indien je ervaring hebt met WPF of UWP.
- Uno ondersteunt WinUI en Windows Community Toolkit libraries.
- Xamarin.Forms bestaat een drietal jaar langer dan Platform Uno. Uno heeft Xamarin echter snel ingehaald op het vlak van functionaliteit en codekwaliteit, vooral omdat UWP zeer matuur is. 
- Uno vereist minder lijnen code (in de grootteorde van 65000 lijnen in vergelijking met 132000 lijnen), vooral met betrekking tot de grafische laag (models, view models, business logica blijven doorgaans grotendeels onaangeroerd): UWP controls zijn "feature rich".

Wat betreft Linux:

- Xamarin.Forms: niet ondersteund.
- Uno Platform: ondersteund op voorwaarde dat je een migratie doorvoert. Vergelijk de inspanning met het porteren van je programma van WPF naar UWP.

Afhankelijk van hoe je wat aanpakt kan je een andere ervaring hebben, maar als je ervaring hebt met WPF of UWP kunnen we vooral Uno aanbevelen. Heb je geen ervaring met WPF of UWP, ook dan kan Uno aanbevolen worden omwille van de superieure performantie op Android.