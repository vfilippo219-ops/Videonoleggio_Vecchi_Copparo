// ----  dichiarazione delle variabili e array per i dvd  ----

// numero massimo di DVD
int DVD_massimi = 20;

// ------ Array dei DVD NON in prestito -------------
string[] titoli             = new string[DVD_massimi];
string[] registi            = new string[DVD_massimi];
int   [] durate             = new int   [DVD_massimi];
string[] categorie          = new string[DVD_massimi];
string[] nazione_sviluppo   = new string[DVD_massimi];
int   [] copie              = new int   [DVD_massimi];


// ------ Array dei DVD in prestito ----------
string[] titoli_prestati = new string[DVD_massimi];
string[] registi_prestati = new string[DVD_massimi];
string[] persona_prestato = new string[DVD_massimi];
string[] data_prestito = new string[DVD_massimi];
string[] data_riconsegna = new string[DVD_massimi];

prepareDVD(titoli, registi, durate, categorie, nazione_sviluppo, copie);

// Dichiadazione variabili colori per abbellire
ConsoleColor BlueColor = ConsoleColor.Blue;
ConsoleColor RedColor = ConsoleColor.Red;
ConsoleColor GreenColor = ConsoleColor.Green;
ConsoleColor DefaultColor = ConsoleColor.White;
ConsoleColor YellowColor = ConsoleColor.Yellow;

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

Console.ForegroundColor = BlueColor;
Console.WriteLine("Benvenuto al videonoleggio Filo_Cop");
Console.ForegroundColor = DefaultColor;

char ruolo = ' ';
do
{
    // chiedo un carattere che può essere solo 'a' o 'c' o '0'
    Console.ForegroundColor = BlueColor;
    Console.Write("Inserisci 'a' per admin, 'c' per cliente (0->Esci): ");
    Console.ForegroundColor = DefaultColor;
    ruolo = getChar(['a', 'c', '0']);

    if (ruolo == 'a')
    {
        bool login = false;
        int tentativo = 0;
        int tentativiMassimi = 4;

        // chiede la password per un massimo di 4 volte
        while (!login && tentativo < 4)
        {
            Console.WriteLine($"\nTentativi rimasti: {tentativiMassimi - tentativo}");
            tentativo++;
            Console.WriteLine($"Tentativo n.{tentativo}");
            Console.Write("\nInserisci la password (4-cifre): ");
            string password = getStringWithLimit(4);
            if (password == "6767") login = true;
            else
            {
                // cosi all'ultimo non dice riprova
                if (tentativo != 4)
                {
                    Console.ForegroundColor = RedColor;
                    Console.WriteLine("Password errata!!");
                    Console.ForegroundColor = DefaultColor;
                }
            }
        }

        if (login)
        {
            Console.ForegroundColor = GreenColor;
            Console.WriteLine("\nBenvenuto!!");
            Console.ForegroundColor = DefaultColor;
            int chose;
            do
            {
                Console.ForegroundColor = BlueColor;
                Console.WriteLine("\nScegli un'opzione:"); Console.ForegroundColor = DefaultColor;
                Console.WriteLine("1. Inserisci un nuovo DVD\n" +
                                  "2. Rimuovi un DVD\n" +
                                  "3. Prestiti\n" +
                                  "0. Fine");
                Console.ForegroundColor = BlueColor;
                Console.Write("Scegli: ");
                Console.ForegroundColor = DefaultColor;
                chose = getNumber(0, 3);

                Console.Clear();

                switch (chose)
                {
                    case 1:      // Inserimento DVD
                        addDVD();
                        break;

                    case 2:      // Rimozione DVD
                        removeDVD();
                        break;

                    case 0:      // Uscita

                        break;
                }
            } while (chose != 0);
        }
        else
        {
            Console.ForegroundColor = RedColor;
            Console.WriteLine("\nTentativi terminati!!");
            Console.ForegroundColor = DefaultColor;
        }
    }
    else if (ruolo == 'c')
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
                          "6. Prestiti\n" +
                          "0. Esci\n" +
                          "Scegli: ");
            chose = getNumber(0, 6);

            switch (chose)
            {
                case 1:     // consultazione
                    stampaDisponibili();
                    break;

                case 2:     // Ricerca per Regista
                    showDVDbyProducer();
                    break;

                case 3:     // Stampa DVD più lungo
                    showLongerDVD();
                    break;

                case 4:     // Ordinamento per durata
                    // Ordinamento decrescente per durata (bubble sort sugli array paralleli)
                    orderDVDforDuration();
                    break;

                case 5:     // Stampa DVD per fascia di durata
                    showDVDforRange();
                    break;
                case 6:

                    Console.Write("Scegli un'opzione:\n" +
                                  "1. Prendi in prestito un DVD\n" +
                                  "2.Cerca DVD disponibile\n"+
                                  "3. Riconsegna DVD\n" +
                                  "4.Stampa tutti i DVD disponibili\n" +
                                  "0. Esci\n" +
                                  "Scegli: ");
                    int chose2 = getNumber(0, 4);
                    switch (chose2)
                    {
                        case 1:
                            borrowDVD();
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 0:
                            break;
                    }

                    break;

                case 0:     // Uscita
                    Console.ForegroundColor = GreenColor;
                    Console.WriteLine("Arrivederci!");
                    Console.ForegroundColor = DefaultColor;
                    break;
            }
        } while (chose != 0);
    }
} while (ruolo != '0');

// funzione per creare i DVD senza dare troppo fastidio al codice
void prepareDVD(string[] titoli, string[] registi, int[] durate, string[] categorie, string[] nazione, int[] copie)
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

    // ----- COPIE --------------------
    copie[0] = 4;
    copie[1] = 3;
    copie[2] = 6;
    copie[3] = 7;
    copie[4] = 3;
    copie[5] = 4;
    copie[6] = 3;
    copie[7] = 6;
}

// funzione per ricevere un valore compreso tra due numeri
int getNumber(int min, int max)
{
    int n = 0;
    bool input_valido = false;

    while (!input_valido)
    {
        if (int.TryParse(Console.ReadLine(), out n) && n >= min && n <= max) input_valido = true;
        else
        {
            Console.ForegroundColor = RedColor;
            Console.Write("Input errato, riprova: ");
            Console.ForegroundColor = DefaultColor;
        }
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
            if (!input_valido)
            {
                Console.ForegroundColor = RedColor;
                Console.Write("Input errato, riprova: ");
                Console.ForegroundColor = DefaultColor;
            }
        }
        else
        {
            Console.ForegroundColor = RedColor;
            Console.Write("Input errato, riprova: ");
            Console.ForegroundColor = DefaultColor;
        }
    }
    return let;
}

// legge una stringa con un limite massimo di caratteri
string getStringWithLimit(int limit)
{
    string n = Console.ReadLine();
    while (n == null || n.Length > limit)
    {
        Console.ForegroundColor = RedColor;
        Console.Write("\nInput non valido, riprovare: ");
        Console.ForegroundColor = DefaultColor;
        n = Console.ReadLine();
    }
    return n;
}

//
void stampaDisponibili()
{
    for (int i = 0; i <= DVD_disponibili; i++)
    {
        Console.WriteLine((i + 1) + ". " + titoli[i] + " by " + registi[i] +
                          ", durata: " + durate[i] + "min, " + categorie[i] +
                          " from " + nazione_sviluppo[i] + ", copie: " + copie[i]);
    }
}

//
void addDVD()
{
    Console.Write("\nInserisci il titolo del DVD ");
    Console.ForegroundColor = YellowColor;
    Console.Write("(exit6767 -> esci): ");
    Console.ForegroundColor = DefaultColor;
    string titolo = getStringWithLimit(limite_titolo);
    if (titolo.ToLower() == "exit6767")
    {

        Console.WriteLine("Ritorno al menù!\n");
    }
    else
    {
        if (DVD_disponibili + 1 >= DVD_massimi)
        {
            Console.ForegroundColor = RedColor;
            Console.WriteLine("\nMemoria piena, impossibile aggiungere altri DVD!");
            Console.ForegroundColor = DefaultColor;
            return;
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
        Console.Write("\nInserisci il numero di copie: ");
        copie[DVD_disponibili] = getNumber(0, int.MaxValue);
        Console.ForegroundColor = GreenColor;
        Console.WriteLine("\nDVD aggiunto con successo!");
        Console.ForegroundColor = DefaultColor;
    }
}

//
void removeDVD()
{
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
        Console.ForegroundColor = GreenColor;
        Console.WriteLine($"\n\"{titolo_rimosso}\" rimosso con successo!!");
        Console.ForegroundColor = DefaultColor;
    }
}

//
void showDVDforRange()
{
    Console.ForegroundColor = GreenColor;
    Console.Write("\nInserisci la durata minima: ");
    Console.ForegroundColor = DefaultColor;
    int minDurata = getNumber(0, int.MaxValue);
    Console.ForegroundColor = BlueColor;
    Console.Write("Inserisci la durata massima: ");
    Console.ForegroundColor = DefaultColor;
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
    if (!trovatoFascia)
    {
        Console.ForegroundColor = RedColor;
        Console.WriteLine("Nessun DVD in questa fascia di durata.");
        Console.ForegroundColor = DefaultColor;
    }
}

int searchDVDbyTitle()
{
    Console.Write("\nChe DVD vuoi cercare? ");
    string ricercaDVD = getStringWithLimit(limite_titolo).ToLower();
    bool trovato = false;
    for (int i = 0; i <= DVD_disponibili; i++)
    {
        if (titoli[i] != null && titoli[i].ToLower() == ricercaDVD)
        {
            Console.WriteLine($"{i + 1}. Nome: {titoli[i]}\nCategoria: {categorie[i]}\n");
            Console.WriteLine("0. esci");
            trovato = true;
        }
    }
    if (!trovato)
    {
        Console.ForegroundColor = RedColor;
        Console.WriteLine("Nessun DVD trovato.");
        Console.ForegroundColor = DefaultColor;

    }
}

//
void showDVDbyProducer()
{
    Console.Write("\nChe regista vuoi cercare? ");
    string ricercaRegista = getStringWithLimit(limite_regista).ToLower();
    bool trovato = false;
    for (int i = 0; i <= DVD_disponibili; i++)
    {
        if (registi[i] != null && registi[i].ToLower() == ricercaRegista)
        {
            Console.WriteLine($"Nome:      {i}\n" +
                              $"Regista:   {i}\n" +
                              $"Durata:    {i}\n" +
                              $"Categoria: {i}\n" +
                              $"Nazione:   {i}\n" +
                              $"Copie:     {i}\n");
            trovato = true;
        }
    }
    if (!trovato)
    {
        Console.ForegroundColor = RedColor;
        Console.WriteLine("Nessun DVD trovato per questo regista.");
        Console.ForegroundColor = DefaultColor;

    }
}

//
void showLongerDVD()
{
    int indiceMax = 0;
    for (int i = 1; i <= DVD_disponibili; i++)
    {
        if (durate[i] > durate[indiceMax]) indiceMax = i;
    }
    Console.WriteLine($"Nome: {titoli[indiceMax]}\nRegista: {registi[indiceMax]}\nDurata: {durate[indiceMax]}\nCategoria: {categorie[indiceMax]}\nNazione: {nazione_sviluppo[indiceMax]}\nCopie{copie[indiceMax]}\n");
}

//
void orderDVDforDuration()
{
    bool swap;
    do
    {
        swap = false;
        for (int i = 0; i < DVD_disponibili; i++)
        {
            if (durate[i] < durate[i + 1])
            {
                // cambiamento avvenuto
                swap = true;
                // scambio tutti i valori
                string tApp = titoli[i];
                string rApp = registi[i];
                int dApp = durate[i];
                string catApp = categorie[i];
                string nApp = nazione_sviluppo[i];
                int copApp = copie[i];

                titoli[i] = titoli[i + 1];
                registi[i] = registi[i + 1];
                durate[i] = durate[i + 1];
                categorie[i] = categorie[i + 1];
                nazione_sviluppo[i] = nazione_sviluppo[i + 1];
                copie[i] = copie[i + 1];

                titoli[i + 1] = tApp;
                registi[i + 1] = rApp;
                durate[i + 1] = dApp;
                categorie[i + 1] = catApp;
                nazione_sviluppo[i + 1] = nApp;
                copie[i + 1] = copApp;
            }
        }
    } while (swap);
    Console.ForegroundColor = GreenColor;
    Console.WriteLine("\nDVD ordinati per durata:");
    Console.ForegroundColor = DefaultColor;
    stampaDisponibili();
}
void borrowDVD()
{
    int wantedDVD;
    do
    {
        wantedDVD = searchDVDbyTitle();

    } while (wantedDVD == -2);

    // -1 se inserisce 0
    if (wantedDVD == -1) return;
    Console.WriteLine($"Nome: {titoli[wantedDVD]}\n" +
                      $"Regista: {registi[wantedDVD]}\n" +
                      $"Durata: {durate[wantedDVD]}\n" +
                      $"Categoria: {categorie[wantedDVD]}\n" +
                      $"Nazione: {nazione_sviluppo[wantedDVD]}\n" +
                      $"Copie: {copie[wantedDVD]}\n");

    Console.WriteLine("1. Prendi in prestito\n0. torna al menù");
    bool stocastico = (getChar(['1', '0']) == '1');
    if (stocastico == true)
    {
        Console.WriteLine("Digita il tuo nome: ");
        persona_prestato[wantedDVD] = getStringWithLimit(20);
        Console.WriteLine("Digita il tuo nome: ");
        persona_prestato[wantedDVD] = persona_prestato[wantedDVD] + " " + getStringWithLimit(20);

        Console.WriteLine("Prenotazione avvenuta con successo!");
        titoli_prestati[wantedDVD] = titoli[wantedDVD];
        registi_prestati[wantedDVD] = titoli[wantedDVD];
        copie[wantedDVD] -= 1;

    }
}

//
void giveBackDVD()
{

}
