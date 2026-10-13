# Arbeidskrav 1 – Algoritmer

Student: Thomas Andersen
Utdypende informasjon, kilder og dokumentasjon er i et eget dokument for å ikke fullstendig overta README filen.

## Beskrivelse

Dette arbeidskravet er en .NET-konsolløsning med demoer av søkealgoritmer, en egen datastruktur, sortering og graftraversering. En relativt enkel konsoll meny gjør det mulig å kjøre oppgavene hver for seg. Demoene gir oss resultater og kjører enkle kontroller som skriver `PASS` eller `FAIL` i konsollen.

## Oppgaver

### 1. Lineært søk og binærsøk

- `LinearSearchAlgorithm` går gjennom arrayet fra venstre mot høyre og returnerer indeksen til første treff, eller `-1` hvis verdien ikke finnes.
- `BinarySearchAlgorithm` bruker nedre grense, øvre grense og midtpunkt. Arrayet må være sortert stigende. Algoritmen fortsetter mot venstre etter et treff for å finne første forekomst av duplikater.
- Lineært søk teller én sammenligning per undersøkt verdi. Binærsøk teller likhetssjekken og, når verdiene ikke er like, sjekken av hvilken side målet ligger på.

| Algoritme | Beste tid | Verste tid | Ekstra plass |
| --- | --- | --- | --- |
| Lineært søk | O(1) | O(n) | O(1) |
| Binærsøk, første forekomst | O(log n) | O(log n) | O(1) |

Lineært søk fungerer også på usorterte data. Binærsøk er raskere for gjentatte søk i sorterte data, men dataene må sorteres først hvis de ikke allerede er sortert. Programmet sjekker ikke automatisk om arrayet er sortert.

### 2. Egen generisk stakk

`CustomStack<T>` er implementert med egne lenkede noder og følger LIFO-prinsippet: sist inn er først ut. Den tilbyr `Push`, `Pop`, `Peek`, `Count` og `IsEmpty`.

- `Push`, `Pop` og `Peek`: O(1) tid.
- Plassbruk: O(n) for n elementer.
- `Pop` og `Peek` kaster `InvalidOperationException` hvis stakken er tom.

Stakken demonstreres både med heltall og tekst. Kontrollene dekker blant annet LIFO-rekkefølge, antall elementer og tom stakk.

### 3. MergeSort

`MergeSortAlgorithm` deler arrayet rekursivt i mindre deler og fletter sorterte delområder sammen. Et delområde med null eller ett element er basissteget. Ved like verdier velges elementet fra venstre del først, slik at flettingen er stabil.

- Beste, gjennomsnittlige og verste tid: O(n log n).
- Ekstra plass: O(n) til midlertidige arrayer.
- Demoen teller sammenligninger mellom verdier og antall sammenslåinger.

| Datasett | Sammenligninger | Sammenslåinger |
| --- | ---: | ---: |
| `[64, 34, 25, 12, 22, 11, 90]` | 13 | 6 |
| Sortert array med fem verdier | 7 | 4 |
| Omvendt sortert array med fem verdier | 5 | 4 |
| Array med duplikater | 7 | 4 |

Tomt array og array med ett element sorteres uten sammenslåinger.

### 4. Graf og BFS

`Graph` lagrer en urettet graf som en naboliste. `BreadthFirstSearch` bruker en kø og besøkte-noder-sett til å traversere grafen nivå for nivå. `ShortestDistance` returnerer antall forbindelser på korteste rute, eller `-1` hvis stasjonene mangler eller ingen rute finnes.

- Tid: O(V + E), der V er antall stasjoner og E er antall forbindelser.
- Ekstra plass: O(V) til kø og besøkte stasjoner.
- FIFO-rekkefølgen gjør at BFS først besøker stasjoner med færrest forbindelser fra start.

Testgrafen bruker Majorstuen, Nationaltheatret, Stortinget, Jernbanetorget, Grønland, Tøyen, Blindern, Forskningsparken og Ullevål stadion. En ekstra forbindelse mellom Nationaltheatret og Blindern lager en sykel. Lysaker er isolert.

Fra Majorstuen er BFS-rekkefølgen:

```text
Majorstuen → Nationaltheatret → Blindern → Stortinget → Forskningsparken → Jernbanetorget → Ullevål stadion → Grønland → Tøyen
```

Korteste avstand fra Majorstuen til Grønland er 4 forbindelser. Avstanden fra Ullevål stadion til Tøyen er 7 forbindelser i testgrafen. Naboene besøkes i rekkefølgen de ble lagt til.

### 5. DFS og sammenligning med BFS

`DepthFirstSearch` implementerer rekursiv DFS, iterativ DFS med `Stack<string>` og `HasPath` for å undersøke om to stasjoner er forbundet. Begge DFS-variantene bruker et sett med besøkte stasjoner for å stoppe traversering gjennom sykler.

- DFS-tid: O(V + E).
- Ekstra plass: O(V) til besøkte stasjoner og stakk; rekursiv DFS bruker i tillegg kallstakken.
- Rekursiv DFS kan bruke for mye kallstakk i svært dype grafer.

I testgrafen besøker begge DFS-variantene de samme nåbare stasjonene, i denne rekkefølgen:

```text
Majorstuen → Nationaltheatret → Stortinget → Jernbanetorget → Grønland → Tøyen → Blindern → Forskningsparken → Ullevål stadion
```

Den iterative varianten legger naboene på stakken i motsatt rekkefølge, slik at den første naboen behandles først. BFS bruker kø og besøker nivå for nivå; DFS følger én gren så langt som mulig. BFS passer derfor for korteste rute i en uvektet graf, mens DFS er nyttig for å utforske nåbare noder eller undersøke om en rute finnes.

## Bygg og kjør

Prosjektet bruker .NET 10.0. Åpne prosjektmappen i Visual Studio Code. Kjør kommandoene fra mappen som inneholder `ArbeidskravModul1.sln`:

```powershell
dotnet build ArbeidskravModul1.sln
dotnet run --project ArbeidskravModul1/ArbeidskravModul1.csproj
```

Velg oppgave 1–5 i menyen. Velg `0` for å avslutte.

## Tester og resultater

Kontrollene ligger i demo-filene, adskilt fra algoritmeklassene og kjører når den tilhørende oppgaven velges. De viser `PASS` når resultatet stemmer med forventningen.

Kontrollene dekker:

- Søk etter verdier som finnes og mangler, tomme arrayer, ett element, verdier utenfor området og duplikater.
- Binærsøk på usorterte data for å vise hvorfor resultatet ikke er pålitelig uten sortert input.
- Stakkens LIFO-rekkefølge, `Peek`, `Count` og oppførsel når stakken er tom.
- MergeSort på oppgitt, sortert, omvendt sortert, duplisert og tomt datasett.
- BFS og DFS på sykler, isolerte stasjoner, tom graf, én stasjon og ukjente stasjoner.
- Korteste rute, ingen rute og DFS-rute mellom stasjoner.

Demoene printer også ut søkeindekser, sammenligningstall, sorteringsresultater og grafenes besøksrekkefølge.

## Prosjektstruktur

```text
Arbeidskrav1Algoritmer/
├── ArbeidskravModul1.sln
└── ArbeidskravModul1/
    ├── ArbeidskravModul1.csproj
    ├── Program.cs
    ├── Shared/
    │   └── ConsoleHelper.cs
    ├── Task1_Searching/
    │   ├── LinearSearch.cs
    │   ├── BinarySearch.cs
    │   └── SearchDemo.cs
    ├── Task2_DataStructure/
    │   ├── CustomStack.cs
    │   └── DataStructureDemo.cs
    ├── Task3_Sorting/
    │   ├── MergeSort.cs
    │   └── SortingDemo.cs
    └── Graphs/
        ├── Graph.cs
        ├── Task4_BFS/
        │   ├── BreadthFirstSearch.cs
        │   └── BfsDemo.cs
        └── Task5_DFS/
            ├── DepthFirstSearch.cs
            └── DfsDemo.cs
```

## Refleksjon

Selve arbeidet med arbeidskravet viser hvordan valget av datastruktur henger sammen med algoritmen: Køen i BFS gir traversering nivå for nivå, mens stakken i DFS lar søket gå dypere langs en gren. Den egenimplementerte stakken viser også hvordan lenkede noder kan gi konstant tid for innsetting og fjerning på toppen. Kontroller av tomme datasett, duplikater, sykler og manglende stasjoner gjør det enklere å se hvordan løsningene oppfører seg i kanttilfeller.

Dette har vært et veldig krevende arbeidskrav, for dette med algorytmer satt ikke for meg. Jeg måtte konstant forholde meg til lærestoffet vi har gått gjennom, lærings lenker som ble delt som ressurser og presentasjonene. Jeg forstår at vi kan bruke AI, men ettersom jeg slet så mye med dette så ville jeg faktisk holde meg unna for å kunne faktisk lære av det.

Jeg valgte å legge oppgave 4 og 5 i en egen folder `Graphs`. Dette fordi oppgave 5 skulle gjenbruke grafen fra oppgave 4 og jobbe videre med den i dybden. 

Jeg la ved kommentarer ved hvert punkt jeg føler det var nødvendig, spesielt for min egen del slik at jeg kunne huske hva hver funksjon gjorde. Spesielt her i README filen, så skrev jeg ned oppgavene og litt for mye i dypden om hva de gjorde, men for min egen del. 

