# Grupparbete: C# Konsolapplikation och Docker Container för Kontroll av Svenskt PersonnummerThank you.
Detta är ett C#-projekt för att validera och hantera personnummer på ett säkert sätt. Vi har byggt ett konsolprogram i C# som kollar
om svenska personnummer är giltiga enligt de regler som gäller för format och kontrollsiffror. Projektet är containeriserat med Docker 
för att underlätta distribution och körning i olika miljöer. Det har varit lärorikt att få arbeta tillsammans i grupp och 
testa på hur man jobbar ihop i Git samt hur man använder Docker för att skapa en isolerad körmiljö.

## Om personnummer & hur konsolapplikationen fungerar
I Sverige har varje person ett unikt personnummer som börjarr när man är född, detta används för identifiering i olika sammanhang.
Man kan skriva personnummer med 10 eller 12 siffror ( t.ex.ÅÅMMDD-XXXX eller ÅÅÅÅMMDD-XXXX). Vår applikation tar emot ett personnummer som indata och
kontrollerar om det är giltigt genom att verifiera formatet och kontrollsiffran med Luhn algoritmen. Om personnumret är giltigt kommer applikationen 
att bekräfta detta, annars kommer den att indikera att personnumret är ogiltigt. 
Regfler för att numret ska vara rätt är:

* Personnumret måste bestå av exakt 10 eller 12 siffror
* Månaden måste alltid vara mellan 01 och 12
* Dagen måste vara mellan 01 och 31 beroende på månaden
* Den sista siffran är en kontrollsiffra som valideras med Luhn algoritmen

Konsolapplikationen kontrollen i olika steg. Till en början så kollar koden ifall man har skrivit rätt antal
siffror, sedan kontrollerar den ifall datumet och månaden är giltig. Slutligen gör den en matematisk uträkning med Luhn algoritmen

### Gruppmedlemmar och roller
Baserat på vårt samarbete i Discord har vi fördelat ansvaret enligt följande:
* Hannes: Ansvarig för huvudlogiken i Program.cs och valideringsmetoder (t.ex. kontroll av månader 01–12).
* Hannah: Ansvarig för enhetstester i projektet PersonnummerApp.Tests med hjälp av xUnit.
* Philip: Ansvarig för Docker konfiguration och miljöhantering.
* Sebastian: Ansvarig för CI/CD automatisering.
* Hiba: Ansvarig för dokumentation och projektets README.

## Teknisk Stack
För att bygga applikation har vi använt följande tekniker:
* Språk: C# som körs på .NET 10
* Testning: xUnit för automatisk enhetstestning
* Containerisering: Docker flr att skapa en isolerad körmiljö
* Automatisering: GitHub Actions för automatiserad bygg och testprocess

## Kom igång

### Förutsättningar
För att kunna köra projektet lokalt på din maskin behöver du ha .NET 10 SDK installerat. 

### Köra applikationen lokalt
För att starta programmet, kör följande kommando i terminalen :

```bash
dotnet run --project PersonnummerApp
```
### Köra testerna
För att vi ska vara säkra på att personnumren valideras på ett korrekt sätt har vi skapat automatiserade 
enhetstester med xUnit. Dessa tester kontrollerar logiken automatiskt så att vi enklare uppmärksammar eventuella fel. 

För att köra testerna, använd följande kommando i terminalen:

```bash 
dotnet test PersonnummerApp.Tests
```
### Användning av Docker
Vi har också gjort det möjligt att köra applikationen med Docker, på så vis fungerar applikationen likadant oavsett vilken miljö den körs i.

1. 1. Bygg Docker imagen med följande kommando i terminalen:
```bash
docker build -t personnummerapp .
```
2. Kör applikationen i terminalen med följande kommando:

```bash 
docker run -it personnummerapp
```

Detta startar applikationen i en interaktiv terminal där du kan mata in personnummer för validering.
