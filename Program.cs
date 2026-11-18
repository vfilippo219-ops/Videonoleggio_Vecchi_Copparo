// ----  dichiarazione delle variabili e array per i dvd  ----

// numero massimo di DVD
int DVD_massimi = 20;

// ------ Array dei DVD NON in prestito -------------
string[] titoli = new string[DVD_massimi];
string[] registi = new string[DVD_massimi];
int[] durate = new int[DVD_massimi];
string[] categorie = new string[DVD_massimi];
string[] nazione_sviluppo = new string[DVD_massimi];

// ------ Array dei DVD in prestito ----------
string[] titoli_prestati = new string[DVD_massimi];
string[] registi_prestati = new string[DVD_massimi];
int[] durate_prestati = new int[DVD_massimi];
string[] categoria_prestati = new string[DVD_massimi];
string[] nazione_prestati = new string[DVD_massimi];

prepareDVD(titoli, registi, durate, categorie, nazione_sviluppo);

// variabile contatore per sapere quanti DVD sono disponibili
// (indice dell'ultimo DVD inserito: partiamo da 7 perché prepareDVD riempie 0..7)
int DVD_disponibili = 7;

// variabile contatore per sapere quanti DVD sono in prestito
int DVD_prestati = 0;

// variabili per limiti stringhe
int limite_regista = 30;
int limite_titolo = 50;
int limite_categoria = 30;
int limite_nazione = 20;

Console.WriteLine("Benvenuto al videonoleggio Filo_Cop");
Console.Write("Inserisci 'a' per admin, 'c' per cliente: ");

// chiedo un carattere che può essere solo 'a' o 'c'
char ruolo = getChar(['a', 'c']);

if (ruolo == 'a')
{
    bool login = false;
    int tentativo = 0;
    Console.Write("\nInserisci la password (4-cifre): ");

    // chiede la password per un massimo di 4 volte
    while (!login && tentativo < 4)
    {
        tentativo++;
        string password = getStringWithLimit(4);
        if (password == "6767") login = true;
        else
        {
            if (tentativo != 4) Console.Write("Password errata, riprova: ");
        }
    }

    if (login)
    {
        Console.WriteLine("\nBenvenuto!!");
        Console.Write("\nScegli un'opzione:\n" +
                      "1. Inserisci un nuovo DVD\n" +
                      "2. Rimuovi un DVD\n" +
                      "0. Fine\n" +
                      "Scegli: ");
        int chose = getNumber(0, 2);

        switch (chose)
        {
            case 1:      // Inserimento DVD
                Console.Write("\nInserisci il titolo del DVD (exit6767 -> esci): ");
                string titolo = getStringWithLimit(limite_titolo);
                if (titolo.ToLower() == "exit6767")
                {
                    Console.WriteLine("Ritorno al menù!\n");
                }
                else
                {
                    if (DVD_disponibili + 1 >= DVD_massimi)
                    {
                        Console.WriteLine("\nMemoria piena, impossibile aggiungere altri DVD!");
                        break;
                    }

                    DVD_disponibili += 1;
                    titoli[DVD_disponibili] = titolo;

                    Console.Write("\nInserisci il regista del DVD: ");
                    registi[DVD_disponibili] = getStringWithLimit(limite_regista);

                    Console.Write("\nInserisci la durata del DVD: ");
                    durate[DVD_disponibili] = getNumber(0, int.MaxValue);

                    Console.Write("\nInserisci la categoria del DVD: ");
                    categorie[DVD_disponibili] = getStringWithLimit(limite_categoria);

                    Console.Write("\nInserisci la nazione del DVD: ");
                    nazione_sviluppo[DVD_disponibili] = getStringWithLimit(limite_nazione);

                    Console.WriteLine("\nDVD aggiunto con successo!");
                }
                break;

            case 2:      // Rimozione DVD
                Console.WriteLine("\nDVD disponibili:");
                stampaDisponibili();
                Console.WriteLine("0. Esci");
                Console.Write("Scegli: ");
                int scelta = getNumber(0, DVD_disponibili + 1);
                scelta--;

                if (scelta != -1)
                {
                    string titolo_rimosso = titoli[scelta];

                    // shift a sinistra per chiudere il "buco"
                    for (int i = scelta; i < DVD_disponibili; i++)
                    {
                        titoli[i] = titoli[i + 1];
                        registi[i] = registi[i + 1];
                        durate[i] = durate[i + 1];
                        categorie[i] = categorie[i + 1];
                        nazione_sviluppo[i] = nazione_sviluppo[i + 1];
                    }

                    // pulizia dell'ultimo slot
                    titoli[DVD_disponibili] = "";
                    registi[DVD_disponibili] = "";
                    durate[DVD_disponibili] = 0;
                    categorie[DVD_disponibili] = "";
                    nazione_sviluppo[DVD_disponibili] = "";

                    DVD_disponibili--;
                    Console.WriteLine($"\n\"{titolo_rimosso}\" rimosso con successo!!");
                }
                break;

            case 0:      // Uscita
                break;
        }
    }
    else
    {
        Console.WriteLine("\nTentativi terminati!!");
    }
}
else
{
    int chose;
    do
    {
        // Cliente
        Console.Write("\nScegli un'opzione:\n" +
                      "1. Consulta DVD\n" +
                      "2. Cerca DVD per regista\n" +
                      "3. Stampa DVD più lungo\n" +
                      "4. Ordina DVD per durata\n" +
                      "5. Stampa DVD per fascia di durata\n" +
                      "0. Esci\n" +
                      "Scegli: ");
        chose = getNumber(0, 5);

        switch (chose)
        {
            case 1:     // consultazione
                stampaDisponibili();
                break;

            case 2:     // Ricerca per Regista
                Console.Write("\nChe regista vuoi cercare? ");
                string ricercaRegista = getStringWithLimit(limite_regista).ToLower();
                bool trovato = false;
                for (int i = 0; i <= DVD_disponibili; i++)
                {
                    if (registi[i] != null && registi[i].ToLower() == ricercaRegista)
                    {
                        Console.WriteLine($"Nome: {titoli[i]}\nRegista: {registi[i]}\nDurata: {durate[i]}\nCategoria: {categorie[i]}\nNazione: {nazione_sviluppo[i]}\n");
                        trovato = true;
                    }
                }
                if (!trovato) Console.WriteLine("Nessun DVD trovato per questo regista.");
                break;

            case 3:     // Stampa DVD più lungo
                int indiceMax = 0;
                for (int i = 1; i <= DVD_disponibili; i++)
                {
                    if (durate[i] > durate[indiceMax]) indiceMax = i;
                }
                Console.WriteLine($"Nome: {titoli[indiceMax]}\nRegista: {registi[indiceMax]}\nDurata: {durate[indiceMax]}\nCategoria: {categorie[indiceMax]}\nNazione: {nazione_sviluppo[indiceMax]}");
                break;

            case 4:     // Ordinamento per durata
                // Ordinamento crescente per durata (bubble sort sugli array paralleli)
                for (int i = 0; i <= DVD_disponibili - 1; i++)
                {
                    for (int j = 0; j <= DVD_disponibili - 1 - i; j++)
                    {
                        if (durate[j] > durate[j + 1])
                        {
                            // scambio titoli
                            string tApp = titoli[j]; titoli[j] = titoli[j + 1]; titoli[j + 1] = tApp;
                            // scambio durate
                            int dApp = durate[j]; durate[j] = durate[j + 1]; durate[j + 1] = dApp;
                            // scambio registi
                            string rApp = registi[j]; registi[j] = registi[j + 1]; registi[j + 1] = rApp;
                            // scambio categorie
                            string cApp = categorie[j]; categorie[j] = categorie[j + 1]; categorie[j + 1] = cApp;
                            // scambio nazioni
                            string nApp = nazione_sviluppo[j]; nazione_sviluppo[j] = nazione_sviluppo[j + 1]; nazione_sviluppo[j + 1] = nApp;
                        }
                    }
                }
                Console.WriteLine("\nDVD ordinati per durata:");
                stampaDisponibili();
                break;

            case 5:     // Stampa DVD per fascia di durata
                Console.Write("\nInserisci la durata minima: ");
                int minDurata = getNumber(0, int.MaxValue);
                Console.Write("Inserisci la durata massima: ");
                int maxDurata = getNumber(minDurata, int.MaxValue);

                bool trovatoFascia = false;
                for (int i = 0; i <= DVD_disponibili; i++)
                {
                    if (durate[i] >= minDurata && durate[i] <= maxDurata)
                    {
                        Console.WriteLine($"{titoli[i]} by {registi[i]}, durata: {durate[i]}min, {categorie[i]} from {nazione_sviluppo[i]}");
                        trovatoFascia = true;
                    }
                }
                if (!trovatoFascia) Console.WriteLine("Nessun DVD in questa fascia di durata.");
                break;

            case 0:     // Uscita
                Console.WriteLine("Arrivederci!");
                break;
        }
    } while (chose != 0);
}

// funzione per creare i DVD senza dare troppo fastidio al codice
void prepareDVD(string[] titoli, string[] registi, int[] durate, string[] categorie, string[] nazione)
{
    // ----- TITOLI -----------------
    titoli[0] = "Yassin??? o Mikhail Andropov???";
    titoli[1] = "Il Giorgione e la sua Zozzona!";
    titoli[2] = "Mario Bros e il \"Manganello Magico\"";
    titoli[3] = "Le Fragole pannose di mamma Vecchi";
    titoli[4] = "Arianna e la porta magica!";
    titoli[5] = "1.50€: Il Trauma di un ragazzo... e non solo!";
    titoli[6] = "Il numero maledetto: 676767 SIXSEVEN!";
    titoli[7] = "Le 013...🤤🍆💦";

    // ----- REGISTI -----------------
    registi[0] = "Zingaretti_&_loZEBBI.lungo di ALI";
    registi[1] = "Prof Levuzzo";
    registi[2] = "Ali";
    registi[3] = "No-Bis";
    registi[4] = "Maggio";
    registi[5] = "Coppino in Motorino";
    registi[6] = "Dr Six-Seven";
    registi[7] = "Dr Venturini🤨";

    // ----- DURATE ------------------
    durate[0] = 119;
    durate[1] = 69;
    durate[2] = 104;
    durate[3] = 36;
    durate[4] = 90;
    durate[5] = 150;
    durate[6] = 67;
    durate[7] = 130;

    // ----- CATEGORIE ----------------
    categorie[0] = "Giallo";
    categorie[1] = "Hot, Horror, Culinario";
    categorie[2] = "Esplorazione";
    categorie[3] = "Culinario";
    categorie[4] = "Fantasy";
    categorie[5] = "Comico";
    categorie[6] = "Misterioso";
    categorie[7] = "Caldo🥵🫠";

    // ----- NAZIONE ------------------
    nazione[0] = "Stati Uniti";
    nazione[1] = "Agugliano";
    nazione[2] = "Giappone";
    nazione[3] = "Veccasa";
    nazione[4] = "Bagni della scuola";
    nazione[5] = "Parcheggio";
    nazione[6] = "Pianeta 67";
    nazione[7] = "Asilo Nido";
}

// funzione per ricevere un valore compreso tra due numeri
int getNumber(int min, int max)
{
    int n = 0;
    bool input_valido = false;

    while (!input_valido)
    {
        if (int.TryParse(Console.ReadLine(), out n) && n >= min && n <= max) input_valido = true;
        else Console.Write("Input errato, riprova: ");
    }

    return n;
}

// funzione per ricevere un carattere tra dei caratteri accettabili
char getChar(char[] accepted_chars)
{
    bool input_valido = false;
    char let = ' ';
    while (!input_valido)
    {
        if (char.TryParse(Console.ReadLine(), out let))
        {
            let = char.ToLower(let);

            for (int i = 0; i < accepted_chars.Length; i++)
            {
                if (let == accepted_chars[i]) input_valido = true;
            }
            if (!input_valido) Console.Write("Input errato, riprova: ");
        }
        else Console.Write("Input errato, riprova: ");
    }
    return let;
}

// legge una stringa con un limite massimo di caratteri
string getStringWithLimit(int limit)
{
    string n = Console.ReadLine();
    while (n == null || n.Length > limit)
    {
        Console.Write("\nInput non valido, riprovare: ");
        n = Console.ReadLine();
    }
    return n;
}

void stampaDisponibili()
{
    for (int i = 0; i <= DVD_disponibili; i++)
    {
        Console.WriteLine((i + 1) + ". " + titoli[i] + " by " + registi[i] +
                          ", durata: " + durate[i] + "min, " + categorie[i] +
                          " from " + nazione_sviluppo[i]);
    }
}
