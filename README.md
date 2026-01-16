# Grupparbete: C# Konsolapplikation och Docker Container för Kontroll av Svenskt Personnummer.
Detta är ett C# projekt för att validera och hantera personnummer på ett säkert sätt. Vi har byggt ett konsolprogram i C# som kontrollerar
om svenska personnummer är giltiga enligt de format och kontrollsiffra (Luhn algoritmen). Genom att använda Github Actions och Docker har vi skapat ett 
helautomatiskt flöde från kod till färdig produkt.  

## Snabbstart
Man behöver inte installera .NET eller ladda ner koden för att testa programmet. Kör bara detta i din terminal.

```bash
docker run --rm -it projectsbyph/csharpgrupparbete

```
Programmet hämtas automatiskt som en färdig image från Docker Hub och startas direkt i terminalen.

## Automatisering och CI/CD
För att säkerställa hög kvalitet använder vi oss av följande flöde:

* GitHub Actions: Varje gång vi skickar upp kod körs våra tester automatiskt, man kan se historiken av körningar i GitHub Actions fliken i repot.

* Docker Hub: Efter godkända tester byggs en image som skickas till Docker Hub, där den lagras och görs tillgänglig för nedladdning.

## Om personnummer & hur konsolapplikationen fungerar
I Sverige har varje person ett unikt personnummer som börjar när man är född, detta används för identifiering i olika sammanhang.
Man kan skriva personnummer med 10 eller 12 siffror ( t.ex.ÅÅMMDD-XXXX eller ÅÅÅÅMMDD-XXXX). Vår applikation tar emot ett personnummer som indata och
kontrollerar om det är giltigt genom att verifiera formatet och kontrollsiffran med Luhn algoritmen. Om personnumret är giltigt kommer applikationen 
att bekräfta detta, annars kommer den att indikera att personnumret är ogiltigt. 
Regler för validering av personnummer:

* Längd: Måste bestå av exakt 10 eller 12 siffror
* Datuom: Giltig månad (01-12) och dag (01-31 beroende på månad).  
* Kontrollsiffra: Den sista siffran beräknas och valideras med Luhn algoritmen.

### Gruppmedlemmar och roller
Vi har fördelat ansvaret enligt följande:
* Hannes: Ansvarig för huvudlogiken i Program.cs och valideringsmetoder (t.ex. kontroll av månader 01–12).
* Hannah: Ansvarig för enhetstester i projektet PersonnummerApp.Tests (xUnit).
* Philip: Ansvarig för Docker konfiguration och miljöhantering.
* Sebastian: Ansvarig för CI/CD automatisering.
* Hiba: Ansvarig för dokumentation och projektets README.

## Köra lokalt 
Förutsättningar för att köra projektet lokalt:
* .NET 10 SDK installerat på din maskin
* Docker installerat (valfritt,för att köra via container)

## Instruktioner
1. Klona repot från GitHub och navigera till projektmappen i terminalen.
 ```bash
 git clone https://github.com/hannestrieb/csharpgrupparbete.git
 cd csharpgrupparbete
 ```

2. Bygg och kör applikationen.
```bash
	dotnet run --project PersonnummerApp
```
3. Kör enhetstesterna för att verifiera valideringslogiken.
```bash
	dotnet test PersonnummerApp.Tests
```


### Bygga egen Docker image lokalt
För att bygga och köra applikationen i en Docker container lokalt, använd följnade kommandon.
```bash
	docker build -t personnummerapp .
	docker run -it personnummerapp
```
