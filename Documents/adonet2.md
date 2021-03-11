













https://www.webtrainingroom.com/adonet/dataadapter

Via ADO.NET beschikken we over een reeks .NET klassen om eenvoudig de verbinding met een database te openen en gegevens weg te schrijven naar de database of op te halen uit de database.

SqlConnection

Connection string



DataReader

We leren hoe we een gegeven uit een SQLServer databank kunnen oplezen door gebruik te maken van de klasse DataReader.

DataReader werkt via geconnecteerde toegang: we openen een connectie, we gebruiken deze en sluiten deze. Vergelijk met wat we doen wanneer we een bestand inlezen. DataReader laat enkel toe gegevens "voorwaarts" op te halen uit de databank en laat niet toe deze gegevens te wijzigen (read-only).

We tonen je hoe we werken met SqlDataReader. Je kan ook gebruik maken van OleDbDataReader onder de System.Data.OleDb namespace: beide klassen erven over van DbDataReader en implementeren interface IDataReader.

Kenmerken

* SqlDataReader laat toe om gegevens op te halen op de meest performantie manier
* SqlDataReader kan enkel "voorwaarts" ophalen: dit betekent dat wanneer je gegevens opleest, je deze moet bijhouden in een object of meteen gebruiken want je kan niet terug naar het vorige gegeven
* We kunnen een of meer records ophalen en je kan niet anders dan deze een voor een behandelen
* Je kan geen gegevens naar de database schrijven
* Je moet een open connectie (geassocieerd met een dataReader) aanleggen terwijl je gegevens ophaalt

```c#
List<WTRStudent> getStudents()
{
    SqlDataReader reader = null;
    SqlConnection conn = new SqlConnection(connectionString);
    SqlCommand cmd = new("select StudentName, Address, ContactNumber from tbStudent", _conn);
    List<WTRStudent> studentList = new List<WTRStudent>();
    WTRStudent student = null;
	try
	{            
		//open the connection
		conn.Open();
		// read the data into reader
		reader = _cmd.ExecuteReader();
		while (reader.Read())
		{
		    // get the results of each column
		    student.FullName =  reader["StudentName"] as string;
		    student.Address =  reader["Address"] as string;
		    student.ContactNumber =  reader["ContactNumber"] as string;        
		    studentList.Add(student);
		}
		// incase you have another record set to read, you can read this way
		while (reader.NextResult())
		{            
		    // read the next record set.
		}
	}
	catch (Exception ex)
	{
	    // do the exception handling rightly
	}
	return studentList;
}
```

Async



```c#
using (SqlConnection con = new SqlConnection(Util.DBConnectionString))
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from dbo.tbStock", con);
        cmd.CommandTimeout = 1;
        SqlDataReader reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            _stock = new Stock();
            _stock.Price = Convert.ToDecimal(reader["price"]);
            _stock.Qty = Convert.ToInt32(reader["quantity"]);
            _stock.Product = Convert.ToString(reader["productName"]);
            stockDetails.Add(_stock);
        }
        con.Close();
    }
```

## Het 3-tier model

Het spreekt voor zich dat wanneer een applicatie groter wordt, de complexiteit toeneemt. Het goed organiseren van de code is van groot belang om:

- de code overzichtelijk te houden en gemakkelijk terug te vinden
- efficiënt samen te werken met andere programmeurs
- makkelijker fouten weg te werken
- alle functionaliteit eenmalig te coderen
- …

De voordelen van het lagenmodel zijn dan ook:

- onderhoudbaarheid
- schaalbaarheid
- flexibiteit
- beschikbaarheid.

Het 3-tier model is een veelgebruikt model om de code gestructureerd en overzichtelijk te organiseren met een duidelijke aanpak. Bij het hanteren van het 3-tier model wordt de applicatie onderverdeeld in 3 aparte lagen, namelijk de presentatielaag, de business-laag (of ook: het domeinmodel) en de data-laag.

[![Database: Het 3-Tier model](C:\Users\u2389\source\repos\ProgrammerenGevorderd2021\Documents\3TierModel.jpg)](http



De **presentatielaag** of **GUI** is de bovenste laag. Deze laag bestaat uit de pagina’s die de gebruiker kan zien aan de buitenkant van het systeem, namelijk de lay-out van de webpagina’s en de navigatie.

De **business-laag** zorgt voor de verbinding met de ander lagen en bevat alle programmeerlogica, objecten en methoden. Tijdens de uitvoering van het programma wordt de invoer van de gebruikers opgeslagen in de objecten en worden de businessregels toegepast.

De **datalaag** of **persistence manager** verbindt de toepassing met de databank. Hierin staat de code die gegevens ophaalt uit de database en die bewerkingen uitvoert op de database. Enkel de datalaag bevat de SQL-code. SQL (Structured Query Language) is een opdrachttaal voor het invoeren, wijzigen, verwijderen, raadplegen en beveiligen van gegevens in een relationele databank.

## Inleiding

ADO.NET, waarbij ADO staat voor ActiveX Data Objects, is het geheel van klassen die gebruikt worden om databases te benaderen. In hoofdstuk 20 is aangeleerd om een database aan te maken. Nadat de database aangemaakt is wordt de code geprogrammeerd zodat een webapplicatie gegevens kan wegschrijven naar de database of gegevens kan ophalen uit de database. Hoe het wegschrijven en ophalen van gegevens gebeurd is afhankelijk van het DBMS (Database Management System): bijvoorbeeld MS Access, Microsoft SQL Server, MySQL, enz. De code is afhankelijk van de provider.

## Verbinding maken met een database

Er is een **database connection** nodig om met een database te kunnen communiceren.

Maak een nieuwe website “Hoofdstuk21” aan. Open de Server Explorer en klik op de knop Connect to Database.

[![Figuur 21.1 Connection: Connect to Database](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig21.1.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig21.1.jpg)

Figuur 21.1: Connect to Database

Bij Data Source wordt gekozen voor het type databank waarmee gewerkt wordt. Kies hier voor een **Microsoft SQL Server Database File**. Automatisch wordt de geschikte Data provider geselecteerd.

[![Figuur 21.2 Connection: Keuze Data Source](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig21.2.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig21.2.jpg)

Klik op OK en browse in het volgende scherm naar de databank ArtemisSQL.mdf. Deze databank is [hier](https://www.c-sharp.be/?attachment_id=2579) te downloaden.

[![Figuur 21.3 Connection: Browse naar database](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig21.3.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig21.3.jpg)

Hier kan de connectie getest worden via de knop **Test Connection**. Door op OK te klikken verschijnt de database in de **Server Explorer** onder de **Data Connections**. Bij het openvouwen verschijnen alle tabel- en query-objecten die zich in de database bevinden met hun structuur.

[![Figuur 21.4 Connection: Structuur database](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig21.5.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig21.5.jpg)

Selecteer bijvoorbeeld de tabelnaam tblKlanten en kies in het snelmenu Show Data Table. De gegevens van de tabel verschijnen in de gegevensbladweergave. Door dubbel te klikken op een tabel opent de ontwerpweergave. Je bent rechtstreeks verbonden met de databank. Wanneer je gegevens wijzigt in de ontwerpweergave dan worden deze wijzigingen opgeslagen in de database.

[![Figuur 21.5 Connection: Gegevensbladweergave](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig21.6.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig21.6.jpg)

[![Figuur 21.6 Connection: Ontwerpweergave](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig21.7.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig21.7.jpg)

De belangrijkste eigenschap van de Data Connection is de Connection String waarin gegevens staan die nodig zijn om de verbinding te leggen. De connection string is opgebouwd uit de volgende elementen:

- **Data Source=(LocalDB)\v11.0**: de naam van de server en de database.
- **AttachDbFilename=F:\Csharp.be\Websites\Databases\ArtemisSQL.mdf**: het volledige pad naar de database. De webapplicatie voegt het databasebestand toe aan de applicatie.
- **Integrated Security=True**: authenticatie, de manier waarop toegang bekomen wordt tot de database.
- **Connect Timeout=30**: tijdsduur in seconden dat geprobeerd wordt een verbinding tot stand te brengen.

In ADO.NET zijn er twee mogelijkheden van datatoegang, namelijk **Connected** en **Disconnected toegang**.

- Connected: de verbinding met de database blijft open gedurende de bewerking. Er wordt rechtstreeks in de database gewerkt.
- Disconnected: de data wordt ingelezen in een cache (DataSet). Er wordt gewerkt met de gegevens in de DataSet zonder een open verbinding met de database. De verbinding met de database wordt onmiddellijk na het inlezen van de gegevens gesloten.

## Connected toegang

Bij connected toegang wordt een rechtstreekse verbinding geopend met de database. Deze verbinding blijft open gedurende de verwerking van de gegevens. In het geheugen zit telkens slechts één record. Dit record kan enkel bewerkt worden via specifieke commando’s.

Connected toegang is niet belastend voor het geheugen maar wel voor het netwerkverkeer.



## Klassen

Connected toegang wordt beheerd door de onderstaande 2 klassen:

- **System.Data.SQLClient.SqlConnection**: dit is de klasse om de verbinding met de database te openen en te sluiten:
- **System.Data.SQLClient.SqlCommand**: dit is de klasse om gegevens op te vragen of aan te passen. Meestal is dit een SQL-instructie die uitgevoerd wordt bij het oproepen van de SQLCommand.



## Wijzigingen aanbrengen: ExecuteNonQuery

In dit onderdeel is een oefening uitgewerkt om de postcode te wijzigen in de tabel tblKlanten van de database Artemis.

Maak in Visual Studio Express for Desktop een nieuw project aan “Hoofdstuk22”.

[![Figuur 22.1 Connected toegang: Aanmaken nieuw project](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.1a.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.1a.jpg)

Verander de naam van het standaardformulier Form1.cs in **frmWijzigPostcode.cs** en klik op OK.

[![Figuur 22.2 Connected toegang: Formuliernaam wijzigen](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.1b.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.1b.jpg)

Figuur 22.2: Formuliernaam wijzigen e

Verander ook de Property Text in het design van het formulier in Postcode wijzigen.

[![Figuur 22.3 Connected toegang: Property Text wijzigen](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.1c.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.1c.jpg)

Voeg via het snelmenu Add, New Item een **ADO.NET Entity Data Model** toe met als naam Artemis.

[![Figuur 22.4 Connected toegang: ADO.NET Entity Data Model toevoegen](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.1d.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.1d.jpg)

Selecteer **EF Designer from Database** om een model aan te maken op basis van een bestaande database.

[![Figuur 22.5 Connected toegang: Model aanmaken](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.5.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.5.jpg)

Figuur 22.5: Model aanmaken

Klik op Next en kies de gewenste database, in dit geval ArtemisSQL.mdf.

[![Figuur 22.6 Connected toegang: Database selecteren](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.6.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.6.jpg)

Figuur 22.6: Database selecteren

Beantwoord onderstaande vraag met Ja.

[![Figuur 22.7 Connected toegang: Bestand kopiëren naar het project](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.7.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.7.jpg)

Figuur 22.7: Bestand kopiëren naar het project

Kies voor **Entity Framework 6.x**, klik op Next. Selecteer vervolgens alle onderdelen van de database die je wenst toe te voegen en klik op Finish.

[![Figuur 22.8 Connected toegang: Onderdelen van de database toevoegen](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.8.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.8.jpg)

Figuur 22.8: Onderdelen van de database toevoegen

Voeg op het formulier een knop “POSTCODE WIJZIGEN” toe. Sleep vervolgens een SqlConnection naar het formulier. Wijzig de naam in **cnnArtemisSQL** en kies bij ConnectionString voor ArtemisSQL.mdf. Voeg daarnaast ook een SqlCommand toe met de naam **scmdWijzigPostcode**.

[![Figuur 22.9 Connected toegang: SqlConnection en SqlCommand toevoegen](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.9.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.9.jpg)

Figuur 22.9: SqlConnection en SqlCommand toevoegen

Wanneer het tabblad Data van de Toolbox geen SqlConnection of SqlCommand bevat, voeg dan deze klassen toe door rechts te klikken in de toolbox en via het snelmenu Choose Items de gewenste klassen te selecteren.

[![Figuur 22.10 Connected toegang: Klasse toevoegen aan Toolbox](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.1.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.1.jpg)

Figuur 22.10: Klasse toevoegen aan Toolbox

Kies in de Property Connection van de klasse scmdWijzigPostcode voor de bestaande verbinding cnnArtemisSQL.

[![Figuur 22.11 Connected toegang: Connection met SqlCommand](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.11.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.11.jpg)

Figuur 22.11: Connection met SqlCommand

Door op de 3 puntjes te klikken bij de Property CommandText opent de Query Builder. Selecteer de gewenste tabel, namelijk tblKlanten. Kies vervolgens via het Snelmenu Change Type voor Update.

[![Figuur 22.12 Connected toegang: Query Builder](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.12.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.12.jpg)

Figuur 22.12: Query Builder

Selecteer het veld Postnr en voer onderstaande SQL-instructie in. Klik vervolgens op OK.

[![Figuur 22.13 Connected toegang: SQL](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.13.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.13.jpg)

Figuur 22.13: SQL

Wanneer op de knop Postcode Wijzigen geklikt wordt dan wordt de postcode 2000 van alle klanten gewijzigd naar postcode 3000. In een Messagebox wordt meegedeeld hoeveel records gewijzigd zijn. Achter de knop zit de onderstaande code:

[![Figuur 22.14 Connected toegang: Programmeercode](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.14.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.14.jpg)

Figuur 22.14: Programmeercode

Het is van groot belang om de verbinding te verbreken (cnnArtemis.Close) nadat de data gewijzigd is. Indien dit niet gebeurt dan blijft de connection open staan. Dit kan problemen veroorzaken bij bezoekers omdat het aantal connections dat gelijktijdig geopend mag worden beperkt is.

Ziehier het resultaat wanneer op de knop gedrukt wordt.

[![Figuur 22.15 Connected toegang: Resultaat van het programma](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.15.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.15.jpg)

Figuur 22.15: Resultaat van het programma

[Top](https://www.c-sharp.be/ado-net/connected-toegang/#TopH22)

## 22.4     Overige methoden

Om één gegeven uit de database op te vragen en weer te geven, wordt de methode **ExecuteScalar** gebruikt. Deze methode geeft de eerste kolom van de eerste rij van de resultaatset van het SELECT-SQL-statement. Omdat het resultaat van het gegevenstype Object is moet er meestal een conversie van het type plaats vinden.

Met het SELECT-statement kunnen ook meerdere gegevens opgevraagd worden. De uitvoering hiervan gebeurt met de methode **ExecuteReader**. Met deze methode wordt bij een SqlCommand een **SqlDataReaderObject** gecreëerd.

In een SQL-statement kunnen ook **parameters** gebruikt worden. Via code wordt een waarde toegekend aan deze parameters. In SQL Server worden parameters aangeduid met een @.
[Top](https://www.c-sharp.be/ado-net/connected-toegang/#TopH22)

## 22.5     Stored procedure

Naast SQL-statements kunnen ook stored procedures gebruikt worden om gegevens uit een database te halen. Een stored procedure is eigenlijk een opgeslagen SQL-statement met uitgebreide programmeerinstructies. Stored procedures zijn vooral handig wanneer hetzelfde SQL-commando meermaals gebruikt wordt.

Met de property CommandType wordt bepaalt hoe de property CommandText geïnterpreteerd moet worden. De mogelijkheden zijn:

- Text: SQL-statement (zie de methoden eerder dit hoofdstuk);
- StoredProcedure: naam van een stored procedure in een SQL database;
- TableDirect: alle gegevens van de tabel worden opgehaald.

[![Figuur 22.16: Property CommandType](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.16.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.16.jpg)

Figuur 22.16: Property CommandType

Open de Database Explorer en rechtsklik op Stored Procedures om via Add New Stored Procedure een nieuwe stored procedure toe te voegen.

Geef de procedure de naam ProductenTeBestellen en voeg de onderstaande SQL-instructies toe.

[![Figuur 22.17: Stored Procedure](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.17.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.17.jpg)

Figuur 22.17: Stored Procedure

Als bij CommandType de optie Stored Procedure geselecteerd wordt dan kan gekozen worden tussen de opgeslagen Stored Procedures.

[![Figuur 22.18: CommandType Stored Procedure](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.18.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.18.jpg)

Figuur 22.18: CommandType Stored Procedure

De Stored procedure kan getest worden door in het snelmenu van de Stored Procedure te kiezen voor Execute.

[![Figuur 22.19: Stored Procedure testen](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.19.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/11/Fig22.19.jpg)

Figuur 22.19: Stored Procedure testen

##  Inleiding Disconnected Toegang

In het vorige hoofdstuk “Connected Toegang” was een constante verbinding met de database vereist. In dit hoofdstuk wordt de data offline gebruikt. Een tijdelijke verbinding met de database is uiteraard noodzakelijk om de data op te halen. Maar daarna is de data offline beschikbaar en kan de data bewerkt worden. Het is zelfs mogelijk om helemaal zonder verbinding te werken en een volledige dataset met relaties op te bouwen in het geheugen.
[Top](https://www.c-sharp.be/ado-net/disconnected-toegang/#TopH23)

## 23.2     Databasegegevens in een formulier

Maak een nieuw project “Hoofdstuk 23” en ontwerp daarin een formulier “frmKlanten”. Voeg een Data Source toe via het menu Project, Add New Data Source…

[![Figuur 23.1: Data Source toevoegen](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.1.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.1.jpg)

Figuur 23.1: Data Source toevoegen

De Data Source Configuration Wizard opent. Doorloop deze wizard en maak hierbij de keuzes die hieronder stap voor stap uitgelegd staan.

Kies **Database** als Data Source Type en druk op Next.

[![Figuur 23.2: Type Database](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.21.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.21.jpg)

Figuur 23.2: Type Database

Kies **Dataset** als Database Model en druk op Next.

[![Figuur 23.3: Dataset](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.3.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.3.jpg)

Figuur 23.3: Dataset

In de dropdownlist kan gekozen worden voor de data connections die in de Database Explorer staan. Selecteer de verbinding met **ArtemisSQL.mdf**. Druk op Next.

[![Figuur 23.4: Data Connection](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.4.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.4.jpg)

Figuur 23.4: Data Connection

De onderstaande melding verschijnt. Kies voor “Nee”. De database wordt niet toegevoegd aan het project.

[![Figuur 23.5: Database NIET toevoegen aan project](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.5.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.5.jpg)

Figuur 23.5: Database NIET toevoegen aan project

Zorg dat optie “Yes, save the connection as:” aangevinkt is. Hierdoor wordt de connection string in de application configuration file bewaard worden. Bijgevolg moeten aanpassingen aan de connection string enkel hierin aangebracht worden. Druk op Next.

[![Figuur 23.6: Bewaar de connection string](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.6.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.6.jpg)

Figuur 23.6: Bewaar de connection string

Plaats tblKlanten in de dataset en geef de dataset de naam dtsKlanten. Een dataset is een deel van relationele databank in het geheugen van de computer (meer hierover in paragraaf 23.3 Dataset). Druk op Finish.

[![Figuur 23.7: Dataset](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.7.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.7.jpg)

Figuur 23.7: Dataset

In de Solution Explorer staat nu het nieuwe bestand van de aangemaakte dataset.

[![Figuur 23.8: Dataset in Solution Explorer](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.8.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.8.jpg)

Figuur 23.8: Dataset in Solution Explorer

Dubbelklik op de aangemaakte dataset dtsKlanten.xsd. In deze dataset zit één DataTable, namelijk de tabel tblKlanten.

[![Figuur 23.9: DataTable](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.9.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.9.jpg)

Figuur 23.9: DataTable

Om de gegevens van eigenlijke database over te brengen naar de DataTable wordt een TableAdapter gebruikt. Aan de DataTable tblKlanten is de TableAdapter tblKlantenTableAdapter verbonden. Met het SQL commando “Fill,GetData()” kunnen de gewenste gegevens opgehaald worden.

[![Figuur 23.10: SQL-commando Fill,GetData()](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.10.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.10.jpg)

Figuur 23.10: SQL-commando Fill,GetData()

Wanneer de Data Sources geactiveerd worden (View, Other Windows, Data Sources) dan kunnen de gegevens overgezet worden naar het formulier in een lijst (DataGridView) of individueel (Details).

[![Figuur 23.11: Data Sources](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.11.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.11.jpg)

Figuur 23.11: Data Sources

Standaard worden de verschillende velden weergegeven in een Textbox. Het gewenste besturingselement kan voor ieder veld geselecteerd worden.

[![Figuur 23.12: Besturingselement wijzigen](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.12.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.12.jpg)

Figuur 23.12: Besturingselement wijzigen

Verander het besturingselement voor Klantnummer naar label en voor Type naar Combobox.

Alle velden overbrengen naar het formulier gebeurt als volgt: Sleep ofwel alle velden één voor één naar het formulier ofwel de tabelnaam naar het formulier.

Schik de velden zodanig tot het onderstaande resultaat.

[![Figuur 23.13: Design formulier frmKlanten](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.131.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.131.jpg)

Figuur 23.13: Design formulier frmKlanten

Automatisch is de navigatiebalk toegevoegd aan het formulier. De onderstaande objecten zorgen ervoor dat het formulier gekoppeld wordt aan de gegevens van de database:

- dtsKlanten: de dataset is een deel van de relationele database die in het geheugen staat.
- tblKlantenBindingSource: zorgt voor de koppeling van de data aan de besturingselementen op het formulier.
- tblKlantenTableAdapter: verzorgt het transport van data tussen de DataTable en de Dataset.
- tableAdapterManager: bewaart data in een relationele databank.
- tblKlantenBindingNavigator: zorgt voor het navigeren, het toevoegen en verwijderen van records…

Voeg aan de Combobox de keuzemogelijkheden P, R, T en W toe via het snelmenu Edit Items. Een andere mogelijkheid om keuzemogelijkheden aan te passen is via de property “Items” van de Combobox.

[![Figuur 23.14: Items toevoegen aan combobox](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.14.jpg)](https://www.c-sharp.be/wp-content/uploads/2015/12/Fig23.14.jpg)

Figuur 23.14: Items toevoegen aan combobox

In het formulier kunnen gegevens gewijzigd, verwijderd of toegevoegd worden. De aanpassingen zijn pas definitief wanneer op de bewaarknop gedrukt wordt. De gegevens worden dan zoals ze in de DataTable staan, weggeschreven naar de database . De DataTable tblKlanten wordt bij het laden van het formulier gevuld met de gegevens van de klanten die uit de database gehaald worden.
[Top](https://www.c-sharp.be/ado-net/disconnected-toegang/#TopH23)

## 23.3     Dataset

Een dataset bevat één of meer tabellen en wordt vertegenwoordigt door DataTables. Een DataTable vertegenwoordigt een gegevensbron die gegevens in rij- en kolomopmaak opslaat.

Eigenlijk is een dataset een relationele database (of een deel van een relationele database) die zich volledig in het geheugen van de PC bevindt. Tijdens de verwerking is er helemaal geen verbinding met de database. Alleen op het ogenblik dat de gegevens in de DataSet geladen worden en op het ogenblik dat de aangepaste gegevens vanuit de DataSet naar de database weggeschreven worden, is er een verbinding met de database.
[Top](https://www.c-sharp.be/ado-net/disconnected-toegang/#TopH23)

## 23.4     TableAdapter en TableAdapterManager

De TableAdapter staat in voor de de communicatie tussen de database en de DataSet, m.a.w. de TableAdapter zorgt ervoor dat de gegevens ingeladen worden in de DataSet. Met de TableAdapter kunnen ook de gewijzigde gegevens van een individuele tabel bewaard worden in de database.

Het bewaren van wijzigingen in een relationele databank met meerdere tabellen in een DataSet gebeurt met de TableAdapterManager. De TableAdapterManager maakt gebruik van de relaties tussen de verschillende tabellen om de volgorde te bepalen waarin gegevens toegevoegd, gewijzigd of verwijderd worden, rekening houdend met de referentiële integriteit.
[Top](https://www.c-sharp.be/ado-net/disconnected-toegang/#TopH23)

## 23.5     BindingSource

Databinding slaat op het feit dat velden van een DataSource gekoppeld worden aan besturingselementen om de gegevens uit de database weer te geven. Er bestaan twee soorten databinding, namelijk:

- Enkelvoudige databinding: de gegevensbron wordt gekoppeld aan een besturingselement dat enkelvoudige informatie kan bevatten, bijvoorbeeld een TextBox of een CheckBox…
- Complexe databinding: een besturingselement kan meerdere gegevens uit de gegevensbron bevatten, bijvoorbeeld een keuzelijst…

[Top](https://www.c-sharp.be/ado-net/disconnected-toegang/#TopH23)

## 23.6     DataRelation

Als een rij van een ParentTable meerdere ChildRows heeft, dan kunnen deze via de methode GetChildRows van de DataRow rechtstreeks aangesproken worden. Het argument van deze mehode is de naam van een DataRelation of de index van de DataRelation. Het resultaat is een Array van DataRows. Het aantal elementen in de array kan opgevraagd worden met de eigenschap Length.