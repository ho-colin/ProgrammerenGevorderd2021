# XML

## Inleiding

In softwareontwikkeling is **SAX** een [API](https://nl.wikipedia.org/wiki/Application_programming_interface) voor het [parsen](https://nl.wikipedia.org/wiki/Parser) van [XML](https://nl.wikipedia.org/wiki/Extensible_Markup_Language). De naam komt van **Simple API for XML**. De huidige hoofdversie SAX 2.0 werd in 2000 door [David Megginson](https://nl.wikipedia.org/w/index.php?title=David_Megginson&action=edit&redlink=1) uitgebracht en is [publiek domein](https://nl.wikipedia.org/wiki/Publiek_domein). Een populair alternatief is de [DOM API](https://nl.wikipedia.org/wiki/Document_Object_Model).

Een parser die SAX implementeert (een *SAX-parser*) behandelt de XML-informatie als een enkele sequentiële gegevensstroom. Deze gegevensstroom wordt in één richting afgehandeld, eerder gelezen data kunnen dus niet opnieuw gelezen worden zonder het geheel opnieuw te parsen. Een SAX-parser werkt volgens een [event](https://nl.wikipedia.org/wiki/Event)-gestuurd model, waarin de programmeur [callback](https://nl.wikipedia.org/w/index.php?title=Callback&action=edit&redlink=1)-methoden implementeert die door de parser worden aangeroepen wanneer die het XML-document doorloopt.

Het SAX-mechanisme wordt door velen als sneller dan een verwerking via DOM gezien. Dit schrijft men toe aan het feit dat **SAX stateless** is, en dus slechts weinig geheugenruimte vereist in vergelijking met de volledig opgebouwde gegevensboom in het DOM-model. SAX is dan ook goed bruikbaar voor de verwerking van grote gegevenshoeveelheden.

Volgens het *Document Object Model* bestaat een document uit een *root* node, die ingebedde (geneste) elementen kan bevatten. Een browser leest een html bestand wel degelijk op in een DOM-voorstelling: bijvoorbeeld Javascript kan deze boom manipuleren. 

Een string is **immutable** in C#: telkens wanneer er een string afgeleid moet worden uit een string wordt er **gecopieerd**: dit is enorm tijdrovend!

RegEx gebruiken is trager dan string manipuleren.

XmlTextReader (SAX) vermijdt al deze gevolgen: ***single pass*** zonder kopiëren!

Een DOM parser is mogelijkerwijze nog trager dan string manipulatie: alles wordt eerst in het geheugen gehaald in een ruime structuur.

Wij zullen met SAX onmiddellijk een DataTable samenstellen terwijl we tag per tag verwerken. Een DataTable kan namelijk bijzonder efficiënt opgeladen worden in SQLServer en laat LINQ toe!

```c#
// We leggen een overzichtstabel aan: xml tag, databank veldnaam, type:
private static Dictionary<string, XmlField> _typeMap = new()
{
            { "agiv:ID", new XmlField { Db = "ID", Type = typeof(UInt64) } },
            { "agiv:STRAATNMID", new XmlField { Db = "STRAATNMID", Type = typeof(UInt64) } },
            { "agiv:STRAATNM", new XmlField { Db = "STRAATNM", Type = typeof(string) } },
            { "agiv:HUISNR", new XmlField { Db = "HUISNR", Type = typeof(string) } },
            { "agiv:APPTNR", new XmlField { Db = "APPTNR", Type = typeof(string) } },
            { "agiv:BUSNR", new XmlField { Db = "BUSNR", Type = typeof(string) } },
            { "agiv:HNRLABEL", new XmlField { Db = "HNRLABEL", Type = typeof(string) } },
            { "agiv:NISCODE", new XmlField { Db = "NISCODE", Type = typeof(UInt64) } },
            { "agiv:GEMEENTE", new XmlField { Db = "GEMEENTE", Type = typeof(string) } },
            { "agiv:POSTCODE", new XmlField { Db = "POSTCODE", Type = typeof(UInt64) } },
            { "agiv:HERKOMST", new XmlField { Db = "HERKOMST", Type = typeof(string) } }
};

// We specificeren hoe een type afgeleid wordt van string naar het gevraagde type:
private static Dictionary<Type, Func<string, object>> _conversionMap = new()
{
            { typeof(string), (x => x) },
            { typeof(int), (x => Convert.ToInt32(x)) },
            { typeof(UInt64), (x => Convert.ToUInt64(x)) },
            { typeof(double), (x => Convert.ToDouble(x)) },
            { typeof(DateTime), (x => Convert.ToDateTime(x)) }
};
```

Aanmaak DataTable:

```c#
var addressTable = new DataTable("Address");
foreach(var dbItem in _typeMap.Values)
{
                addressTable.Columns.Add(dbItem.Db, dbItem.Type);
}
```

We lezen het xml bestand onmiddellijk in naar de gegevensstructuur die we efficiënt kunnen opladen in de databank, namelijk een DataTable:

```C#
var myXmlReader = new XmlTextReader(fileName);
while (myXmlReader.ReadToFollowing("agiv:CrabAdr"))
{
  var fieldName = "?";
  var v = "?";
  try
  {
    var dr = addressTable.NewRow();
      
    for (int i = 0; i < _typeMap.Keys.Count; i++)
    {
      fieldName = _typeMap.Keys.ElementAt(i);
      bool elementFound;
      if (i == 0)
        elementFound = myXmlReader.ReadToDescendant(fieldName);
      else
        elementFound = myXmlReader.ReadToFollowing(fieldName);
      if (elementFound)
      {
        v = myXmlReader.ReadInnerXml().Trim();
        if (!string.IsNullOrEmpty(v))
        {
          dr[_typeMap.Values.ElementAt(i).Db] = _conversionMap[_typeMap.Values.ElementAt(i).Type](v);
        }
       }
      }
      
      addressTable.Rows.Add(dr);
    }
    catch(Exception e)
    {
      System.Diagnostics.Debug.WriteLine("Address " + addressCount + ", field " + fieldName + ", value " + v + ": " + e.Message);
    }
}
```

LINQ met een DataTable:

```c#
var result = addressTable.AsEnumerable().Where(myRow => myRow["GEMEENTE"].Equals("Hoogstraten"));
```

