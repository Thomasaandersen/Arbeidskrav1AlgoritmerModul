`AI dokumentasjon`
Her er min dokumentasjon for bruk av AI prompts og svar den har gitt meg. Det er flere prompts som er brukt, men alle har hatt samme ordlyd og tone. Jeg har bedt AI om å gi meg veiledende hjelp, ikke fullføre noe arbeid for meg og for å dytte meg i riktig retning. Promptene og svarene er også lagt til i dokumentet `Dokumentasjon_Prosess_AI`.

---

`Prompt 1`

## Prompt: 
(Lagt til oppgave teksten for oppgave 5). Jeg skal lage DfsDemo.cs for oppgave 5. Ikke skriv koden ferdig. Hjelp meg å planlegge hvordan jeg kan vise resultatet fra rekursiv DFS, iterativ DFS og BFS på samme graf. Still spørsmål som hjelper meg å teste at DFS-variantene besøker de nåbare stasjonene én gang, og at rutetesten fungerer for en isolert stasjon. La meg skrive koden før du vurderer den.

Svar:
For å demonstrere alle tre algoritmene tydelig i DfsDemo.cs, kan du bygge opp én felles grafinstans i starten av programmet som inneholder hele transportnettet og den isolerte stasjonen. Deretter kjører du traverseringene fra samme startnode, for eksempel Majorstuen, siden oppgaveteksten ber deg sammenligne besøksrekkefølgen herfra. Hvis metodene dine returnerer samlinger med stasjonsnavn, kan du skrive dem ut rett under hverandre med string.Join. Da ser du umiddelbart hvordan BFS, iterativ DFS og rekursiv DFS velger ulike veier.

Når du bygger logikken for å sikre at DFS-variantene kun besøker nåbare stasjoner nøyaktig én gang, bør du tenke gjennom akkurat når stasjonen registreres. Nøyaktig hvor i koden markerer du en node som besøkt? Oppgaven tipser om at et konsekvent tidspunkt for dette gjør det lettere å unngå duplikater og uendelige løkker. Dette er spesielt viktig for den iterative varianten, slik at du ikke ender opp med å legge samme nabo på stakken flere ganger. Du kan også vurdere hvilken datastruktur som gir raskest oppslag for å sjekke om en stasjon allerede er håndtert.

For rutetesten din med en isolert stasjon, er det greit å provosere frem kanttilfellene. Hva skjer i koden din hvis stakken eller køen tømmes helt fordi det ikke finnes en gyldig vei frem til den isolerte stasjonen? Hvordan oppfører metoden seg i det motsatte tilfellet, altså hvis du starter på den isolerte stasjonen og nabolisten er helt tom fra første steg? Tenk over hva metoden bør returnere for at programmet skal kunne informere brukeren om at ingen rute finnes, i stedet for å krasje.

---

`Prompt 2`
## Prompt: 
Jeg jobber med CustomStack<T> i oppgave 2. Bruk oppgaveteksten og den relevante teorien i «Grunnleggende og obligatorisk teori + ressurser og linker». Gi meg en uferdig skisse med en lenket node, top og count, og la disse metodene ha TODO-er:

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

Ikke bruk Stack<T> til å implementere stakken. Hjelp meg med ett hint om gangen, og spør meg hva toppen og antallet skal være etter hvert kall. Vis til kravene om generisk type, API og tom stakk. Ikke skriv ferdig klassen for meg. 

## Svar: 
Her er en uferdig skisse av den generiske datastrukturen for Oppgave 2. Klassen tar inn en generisk typeparameter <T>, og implementerer et standard LIFO-API med Push og Pop slik teorien for stakk og rekursjon beskriver. Ved å bruke en indre lenket node bygger du strukturen fra bunnen av, og får full kontroll over tilstanden gjennom top-referansen og variabelen count. 
using System;

public class CustomStack<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }

    private Node top;
    private int count;

    public int Count => count;

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
