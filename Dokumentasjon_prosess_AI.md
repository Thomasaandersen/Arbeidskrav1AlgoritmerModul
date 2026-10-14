# Dokumentasjon av kilder, utviklingsprosessen og AI/prompt dokumentasjon

Her vil jeg liste opp hvilke kilder jeg har brukt og hvordan jeg har arbeidet for å oppfylle de forskjellige kravene i arbeidskravet. Jeg har forsøkt å være tydelig på hva jeg har gjort selv, hva jeg har hentet fra kursmaterialet, og hvor dette er brukt i prosjektet. AI er blitt brukt som et hjelpemiddel og som en pekepinne. Jeg har lagt ved to av promptene jeg har brukt og svarene. 

**For arbeidskravet så brukte jeg notater, ressursene og alt som ble delt på fra øktene (Uke 35- Uke 38).** Dette for å forstå begrepene, følge de forskjellige algoritmene og slå opp standardtypene i .NET.

Alt av notater, lenker og ressurser samler jeg fra hver økt i et dokument for å holde en bedre oversikt over alt sammen. **“Grunnleggende og obligatorisk teori + ressurser og linker”.** Dette er blant annet filen som jeg sendte til AI for å hjelpe meg. En viktig grunn til at jeg gjør dette, er for å forhindre AI i å fortelle meg ting jeg ikke har lært om eller. Dokumentet hjelper den med å holde seg “on track” og ikke hallucinere. 

Koden er skrevet på engelsk for å fortsette med det jeg alltid har gjort i praksis generelt sett og fra tidligere arbeidskrav.

`Andre kilder:`

En god del hjelp kom fra øktene vi har hatt og lenkene som ble lagt ut som ressurser. 

- [CS50/Yale – Lecture 3: Searching, Big O, recursion and Merge sort — Supplerende teori for lineært og binært søk, Big-O, rekursjon og MergeSort. Brukt til konsepter, ikke C\#-kode.](https://cs50.yale.edu/2019/fall/notes/3/)   
- [Microsoft Learn – Array.BinarySearch — API-oppslag om søk i sorterte arrayer og returverdier. Prosjektet bruker egen binærsøk-kode.](https://learn.microsoft.com/en-us/dotnet/api/system.array.binarysearch?view=net-10.0)  
- [OpenDSA – Graphs Chapter Introduction — Supplerende forklaring av noder, kanter og forskjellen mellom naboliste og nabolagsmatrise.](https://opendsa-server.cs.vt.edu/ODSA/Books/pubbook/odsa-all/fall-2019/Public_Instance/html/GraphIntro.html)  
- [CP-Algorithms – Breadth-First Search — Supplerende forklaring av BFS, kø, besøkte noder og korteste rute i uvektede grafer.](https://cp-algorithms.com/graph/breadth-first-search.html)  
- [Microsoft Learn – Queue og Stack — API-oppslag for FIFO-køen i BFS og LIFO-stakken i iterativ DFS.](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1?view=net-10.0)  
- [Microsoft Learn – Stack — API-oppslag for den innebygde LIFO-stakken i iterativ DFS.](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.stack-1?view=net-10.0)   
- [Microsoft Learn – HashSet — API-oppslag for mengden som brukes til å holde oversikt over besøkte stasjoner.](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1?view=net-10.0)   
- [Microsoft Learn – Dictionary — API-oppslag for nøkkel/verdi-samlingen som lagrer grafens naboliste.](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-10.0)  
- [Microsoft Learn – Collections and Data Structures — Oversikt brukt til å sammenligne .NET-samlinger og deres vanlige bruksområder.](https://learn.microsoft.com/en-us/dotnet/standard/collections/)

# Dokumentasjon og kilder for arbeidskravet

## Oppgave 1 \- Lineært søk og binærsøk

Ressurser og notater fra uke 35 ble brukt til å følge søkeintervallet steg for steg og til å forklare hvorfor binærsøk forutsetter sorterte data. *Yale-forelesningen (lecture 3\)* ga en god forklaring på søk og **Big-O**. *Microsofts dokumentasjon* av **Array.BinarySearch** ble brukt som oppslag for .NETs sorteringsforutsetning og som kontrast til den egenimplementerte metoden. Prosjektets binærsøk fortsetter mot venstre for å returnere første forekomst av duplikat.

## Oppgave 2 \- Egen generisk stakk
 Notatene fra økten i uke 38 og ressursene om stakk og LIFO støttet forklaringen av **'Push', 'Pop' og 'Peek'**. **'CustomStack'** i prosjektet er bygd med egne lenkede noder. Microsofts Stack-dokumentasjon for den innebygde stakken som brukes i den iterative DFS-en, ikke som implementasjon av den egenlagde stakken.

## Oppgave 3 \- MergeSort  
Fra økten vi hadde i uke 36 så forklarte grunntilfellet, deling og sammenslåing, stabilitet og hvorfor **MergeSort** bruker **O(n log n) tid** og **O(n)** ekstra plass. De sorterte, omvendt sorterte, dupliserte og tomme testdata i demoen følger også testtilfellene som gjennomgås i notatet. 

## Oppgave 4 \- Graf og BFS  
Uke 37-notatet støttet valget av naboliste og bruken av kø og besøkt-mengde. OpenDSA ga supplerende forklaring på grafrepresentasjoner, mens CP-Algorithms ble brukt til å kontrollere BFS-prinsippet for korteste antall kanter i en uvektet graf. Microsoft Learn ble brukt som API-oppslag for **'Dictionary'**, **'Queue'** og **'HashSet\`**. 

## Oppgave 5 \- Rekursiv og iterativ DFS  
Notater og øvings oppgaver fra uke 38 støttet valget mellom eksplisitt stakk og rekursiv kallstakk, samt håndtering av sykler og naborekkefølge. Microsoft Learn ble brukt som API-oppslag for **'Stack'** og **'HashSet'**. Ressursene støtter forklaringen av datastrukturene, selve traverseringsmetodene ligger i prosjektets egne C\#-klasser. 

---

# `AI Dokumentasjon`

**Prompt:**   
(Lagt til oppgave teksten for oppgave 5). Jeg skal lage DfsDemo.cs for oppgave 5\. Ikke skriv koden ferdig. Hjelp meg å planlegge hvordan jeg kan vise resultatet fra rekursiv DFS, iterativ DFS og BFS på samme graf. Still spørsmål som hjelper meg å teste at DFS-variantene besøker de nåbare stasjonene én gang, og at rutetesten fungerer for en isolert stasjon. La meg skrive koden før du vurderer den.

**Svar:**  
For å demonstrere alle tre algoritmene tydelig i DfsDemo.cs, kan du bygge opp én felles grafinstans i starten av programmet som inneholder hele transportnettet og den isolerte stasjonen. Deretter kjører du traverseringene fra samme startnode, for eksempel Majorstuen, siden oppgaveteksten ber deg sammenligne besøksrekkefølgen herfra. Hvis metodene dine returnerer samlinger med stasjonsnavn, kan du skrive dem ut rett under hverandre med string.Join. Da ser du umiddelbart hvordan BFS, iterativ DFS og rekursiv DFS velger ulike veier.

Når du bygger logikken for å sikre at DFS-variantene kun besøker nåbare stasjoner nøyaktig én gang, bør du tenke gjennom akkurat når stasjonen registreres. Nøyaktig hvor i koden markerer du en node som besøkt? Oppgaven tipser om at et konsekvent tidspunkt for dette gjør det lettere å unngå duplikater og uendelige løkker. Dette er spesielt viktig for den iterative varianten, slik at du ikke ender opp med å legge samme nabo på stakken flere ganger. Du kan også vurdere hvilken datastruktur som gir raskest oppslag for å sjekke om en stasjon allerede er håndtert.

For rutetesten din med en isolert stasjon, er det greit å provosere frem kanttilfellene. Hva skjer i koden din hvis stakken eller køen tømmes helt fordi det ikke finnes en gyldig vei frem til den isolerte stasjonen? Hvordan oppfører metoden seg i det motsatte tilfellet, altså hvis du starter på den isolerte stasjonen og nabolisten er helt tom fra første steg? Tenk over hva metoden bør returnere for at programmet skal kunne informere brukeren om at ingen rute finnes, i stedet for å krasje.

**Prompt:**   
Jeg jobber med CustomStack\<T\> i oppgave 2\. Bruk oppgaveteksten og den relevante teorien i «Grunnleggende og obligatorisk teori \+ ressurser og linker». Gi meg en uferdig skisse med en lenket node, top og count, og la disse metodene ha TODO-er:

public void Push(T value)  
{  
// TODO: Lag en ny node og oppdater toppen.  
}  
public T Pop()  
{  
// TODO: Bestem hva som skjer hvis stakken er tom.  
// TODO: Ta vare på og fjern verdien på toppen.  
throw new NotImplementedException();  
}

Ikke bruk Stack\<T\> til å implementere stakken. Hjelp meg med ett hint om gangen, og spør meg hva toppen og antallet skal være etter hvert kall. Vis til kravene om generisk type, API og tom stakk. Ikke skriv ferdig klassen for meg. 

**Svar:**   
Her er en uferdig skisse av den generiske datastrukturen for Oppgave 2\. Klassen tar inn en generisk typeparameter \<T\>, og implementerer et standard LIFO-API med Push og Pop slik teorien for stakk og rekursjon beskriver. Ved å bruke en indre lenket node bygger du strukturen fra bunnen av, og får full kontroll over tilstanden gjennom top-referansen og variabelen count.   
using System;

public class CustomStack\<T\>  
{  
    private class Node  
    {  
        public T Value { get; set; }  
        public Node Next { get; set; }

        public Node(T value)  
        {  
            Value \= value;  
        }  
    }

    private Node top;  
    private int count;

    public int Count \=\> count;

    public void Push(T value)  
    {  
        // TODO: Lag en ny node og oppdater toppen.  
    }

    public T Pop()  
    {  
        // TODO: Bestem hva som skjer hvis stakken er tom.  
        // TODO: Ta vare på og fjern verdien på toppen.  
        throw new NotImplementedException();  
    }  
}  
For å ta det første steget med Push-metoden: Hvis stakken akkurat er opprettet og er helt tom, og du kaller Push for å legge til en ny verdi, hva bør top peke på, og hva skal count oppdateres til?

---