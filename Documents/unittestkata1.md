# Kata 1



## Vooraleer je van start gaat: 

- **Probeer niet vooruit te lezen**!
- Voer **een enkele taak per keer** uit. De truuk is: leer incrementeel werken.
- Test bij deze opdracht enkel of invoer correct is (het is voor deze oefening niet nodig ongeldige invoer te testen, met andere woorden)

## String Calculator

1. Maak een klassenbibliotheek voor je domein-code (business code hoort in een aparte assembly) en gebruik het test framework van Visual Studio 2019 om een apart project met unit testen te genereren.

2. Maak een eenvoudige String rekenaar aan, een klasse *Calculator* met een methode met volgende signatuur:

   ```
   int Add(string numbers)
   ```

   De methode kan tot **maximaal twee getallen** in de string parameter bevatten, getallen die gescheiden zijn door een komma. De methode geeft de som terug. Voorbeelden van de string parameter:

   * “” 

   * “1” 

   * “1,2”

     

   **Bij een lege string wordt 0 als som teruggegeven.**

   Hints:

    - Start met het eenvoudigste geval: de lege string en implementeer daarna het geval met 1 getal en vervolgens het geval met twee getallen.
    - Probeer je oplossing zo eenvoudig mogelijk te houden en maak hierbij testen aan waar je nog niet aan dacht bij voorbaat.
    - Vergeet niet je code beter te schrijven bij elke test.

3. Verbeter de Add() methode zodat deze **meer dan twee getallen** kan optellen (0, 1, 2, ..., n getallen waarbij n onbekend is).

4. Verbeter de Add() methode zodat deze **"newlines" tussen getallen toelaat in plaats van komma's**.

   1. Voorbeeld: “1\n2,3” is toegelaten en geeft als resultaat 6.
   2. De volgende invoer is niet toegelaten en wordt niet ondersteund door je methode: “1,\n” (je moet voor dit geval geen test schrijven).

5. Wanneer Add() opgeroepen wordt met een **negatief getal**, werp je een ***Exception*** op met de tekst “**negatives not allowed**” - gevolgd door de negatieve waarde die doorgegeven werd. Indien er meer dan 1 negatieve waarde doorgegeven wordt, toon dan alle negatieve waarden in de boodschap (Message) van de exception.

6. Getallen **groter dan 1000 worden verwaarloosd** en niet verwerkt: 2 + 1001 = 2.