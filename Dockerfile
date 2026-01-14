# Steg 1: Bygger applikationen
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Kopierar projektfilerna först (för att cacha dependencies)
COPY ["PersonnummerApp/PersonnummerApp.csproj", "PersonnummerApp/"]

# Återställer beroenden för den specifika filen
RUN dotnet restore "PersonnummerApp/PersonnummerApp.csproj"

# Kopierar resten av koden och bygger applikationen
COPY . ./

# Bygger och publicerar applikationen
WORKDIR "/src/PersonnummerApp"
RUN dotnet publish -c Release -o /app/publish

# Steg 2: Skapar runtime image
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Startkommandot för applikationen
ENTRYPOINT ["dotnet", "csharpgrupparbete.dll"]
