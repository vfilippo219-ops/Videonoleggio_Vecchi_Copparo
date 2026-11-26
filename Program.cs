// ----  dichiarazione delle variabili e array per i dvd  ----

// numero massimo di DVD
using System.Reflection.PortableExecutable;

int DVD_massimi = 20;

// ------ Array dei DVD NON in prestito -------------
string[] titoli = new string[DVD_massimi];
string[] registi = new string[DVD_massimi];
int[] durate = new int[DVD_massimi];
string[] categorie = new string[DVD_massimi];
string[] nazione_sviluppo = new string[DVD_massimi];
int[] copie = new int[DVD_massimi];


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
    Console.Write("Inserisci 'a' per admin, 'c' per cliente ");
    Console.ForegroundColor = YellowColor;
    Console.Write("(0->Esci): ");
    Console.ForegroundColor = DefaultColor;
    ruolo = getChar(['a', 'c', '0']);

    // All admin
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
            Console.ForegroundColor = BlueColor;
            Console.Write("\nInserisci la password (4-cifre): ");
            Console.ForegroundColor = DefaultColor;

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

        // menù per admin
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

                    case 3:

                        break;

                    case 0:      // Uscita
                        break;
                }
            } while (chose != 0);
        }
        // Tentativi terminati
        else
        {
            Console.ForegroundColor = RedColor;
            Console.WriteLine("\nTentativi terminati!!");
            Console.ForegroundColor = DefaultColor;
        }
    }

    //All Client
    else if (ruolo == 'c')
    {
        int chose;
        do
        {
            //menù Client
            Console.ForegroundColor = BlueColor;
            Console.Write("\nScegli un'opzione:\n");
            Console.ForegroundColor = DefaultColor;
            Console.Write("1. Consulta DVD\n" +
                          "2. Cerca DVD per regista\n" +
                          "3. Stampa DVD più lungo\n" +
                          "4. Ordina DVD per durata\n" +
                          "5. Stampa DVD per fascia di durata\n" +
                          "6. Prestiti\n" +
                          "0. Esci\n");

            Console.ForegroundColor = BlueColor;
            Console.Write("Scegli: ");
            Console.ForegroundColor = DefaultColor;
            chose = getNumber(0, 6);
            Console.Write("\n");

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
                    int chose2;
                    do
                    {
                        Console.ForegroundColor = BlueColor;
                        Console.Write("Scegli un'opzione:\n");
                        Console.ForegroundColor = DefaultColor;
                        Console.WriteLine("1. Prendi in prestito un DVD\n" +
                                          "2. Cerca DVD disponibile\n" +
                                          "3. Riconsegna DVD\n" +
                                          "4. Stampa tutti i DVD in prestito\n" +
                                          "0. Esci");
                        Console.ForegroundColor = BlueColor;
                        Console.Write("Scegli: ");
                        Console.ForegroundColor = DefaultColor;
                        chose2 = getNumber(0, 4);
                        // Menù Prestiti
                        switch (chose2)
                        {
                            case 1:
                                borrowDVD();
                                break;
                            case 2:
                                searchDVDbyTitle();
                                break;
                            case 3:
                                giveBackDVD();
                                break;
                            case 4:
                                showBorrowedDVD();
                                break;
                            case 0:
                                break;
                        }
                    } while (chose2 != 0);

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

// stampa tutti i DVD disponibili
void stampaDisponibili()
{
    for (int i = 0; i <= DVD_disponibili; i++)
    {
        if (copie[i] > 0)
        {
            Console.WriteLine($"{i + 1}.\n" +
                              $"========== {titoli[i]} ==========\n" +
                              $" - Fatto da: {registi[i]}\n" +
                              $" - Durata: {durate[i]}\n" +
                              $" - Categoria: {categorie[i]}\n" +
                              $" - Nazione: {nazione_sviluppo[i]}\n" +
                              $" - Copie: {copie[i]}\n");
        }
    }
}

void showBorrowedDVD()
{
    if (DVD_prestati == 0)
    {
        Console.ForegroundColor = RedColor;
        Console.WriteLine("Ancora non sono stati prestati DVD");
        Console.ForegroundColor = DefaultColor;
    }
    else
    {
        for (int i = 0; i < DVD_disponibili; i++)
        {
            if (persona_prestato[i] != null)
            {
                Console.WriteLine($"{i + 1}.\n" +
                                  $"========== {titoli_prestati[i]} ==========\n" +
                                  $" - Fatto da: {registi_prestati[i]}\n" +
                                  $" - Copie disponibili: {copie[i]}\n" +
                                  $" - Data di Riconsegna: {data_riconsegna[i]}");
                if (ruolo == 'a')
                {
                    Console.WriteLine($" - Data di prestito: {data_prestito[i]}" +
                                      $" - Nome e cognome: {persona_prestato[i]}");
                }
            }
        }
    }
}

// funzione per aggiungere DVD
void addDVD()
{

    //controllo memoria DVD massimi
    if (DVD_disponibili + 1 >= DVD_massimi)
    {
        Console.ForegroundColor = RedColor;
        Console.WriteLine("\nMemoria piena, impossibile aggiungere altri DVD!");
        Console.ForegroundColor = DefaultColor;
        return;
    }

    // richiesta titolo
    Console.ForegroundColor = BlueColor;
    Console.Write("\nInserisci il titolo del DVD ");
    Console.ForegroundColor = DefaultColor;

    Console.ForegroundColor = YellowColor;
    Console.Write("(exit6767 -> esci): ");
    Console.ForegroundColor = DefaultColor;

    string titolo = getStringWithLimit(limite_titolo);

    if (titolo.ToLower() == "exit6767")
    {
        Console.ForegroundColor = YellowColor;
        Console.WriteLine("Ritorno al menù!\n");
        Console.ForegroundColor = DefaultColor;
    }
    else
    {
        DVD_disponibili += 1;
        titoli[DVD_disponibili] = titolo;

        // richiesta regista
        Console.ForegroundColor = BlueColor;
        Console.Write("\nInserisci il regista del DVD: ");
        Console.ForegroundColor = DefaultColor;
        registi[DVD_disponibili] = getStringWithLimit(limite_regista);

        // richiesta durata
        Console.ForegroundColor = BlueColor;
        Console.Write("\nInserisci la durata del DVD: ");
        Console.ForegroundColor = DefaultColor;
        durate[DVD_disponibili] = getNumber(0, int.MaxValue);

        // richiesta categoria
        Console.ForegroundColor = BlueColor;
        Console.Write("\nInserisci la categoria del DVD: ");
        Console.ForegroundColor = DefaultColor;
        categorie[DVD_disponibili] = getStringWithLimit(limite_categoria);

        // richiesta nazione
        Console.ForegroundColor = BlueColor;
        Console.Write("\nInserisci la nazione del DVD: ");
        Console.ForegroundColor = DefaultColor;
        nazione_sviluppo[DVD_disponibili] = getStringWithLimit(limite_nazione);

        // richiesta numero copie
        Console.ForegroundColor = BlueColor;
        Console.Write("\nInserisci il numero di copie: ");
        Console.ForegroundColor = DefaultColor;
        copie[DVD_disponibili] = getNumber(0, int.MaxValue);

        Console.ForegroundColor = GreenColor;
        Console.WriteLine("\nDVD aggiunto con successo!");
        Console.ForegroundColor = DefaultColor;

        int cambiamenti;
        do
        {
            Console.ForegroundColor = BlueColor;
            Console.WriteLine("Vuoi modificare qualcosa? Scegli:");
            Console.ForegroundColor = DefaultColor;

            Console.Write("1. Titolo\n" +
                          "2. Regista\n" +
                          "3. Durata\n" +
                          "4. Categoria\n" +
                          "5. Nazione\n" +
                          "6. Numero copie disponibili\n" +
                          "0. Esci\n");

            Console.ForegroundColor = BlueColor;
            Console.WriteLine("Scegli: ");
            Console.ForegroundColor = DefaultColor;
            cambiamenti = getNumber(0, 6);

            switch (cambiamenti)
            {
                case 1:
                    Console.ForegroundColor = BlueColor;
                    Console.Write("\nInserisci il titolo del DVD: ");
                    Console.ForegroundColor = DefaultColor;
                    titoli[DVD_disponibili] = getStringWithLimit(limite_titolo);

                    break;

                case 2:
                    Console.ForegroundColor = BlueColor;
                    Console.Write("\nInserisci il regista del DVD: ");
                    Console.ForegroundColor = DefaultColor;
                    registi[DVD_disponibili] = getStringWithLimit(limite_regista);

                    break;

                case 3:
                    Console.ForegroundColor = BlueColor;
                    Console.Write("\nInserisci la durata del DVD: (0 -->esci)");
                    Console.ForegroundColor = DefaultColor;
                    durate[DVD_disponibili] = getNumber(0, int.MaxValue);

                    break;

                case 4:
                    Console.ForegroundColor = BlueColor;
                    Console.Write("\nInserisci la categoria del DVD: ");
                    Console.ForegroundColor = DefaultColor;
                    categorie[DVD_disponibili] = getStringWithLimit(limite_categoria);

                    break;

                case 5:
                    Console.ForegroundColor = BlueColor;
                    Console.Write("\nInserisci la nazione del DVD: ");
                    Console.ForegroundColor = DefaultColor;
                    nazione_sviluppo[DVD_disponibili] = getStringWithLimit(limite_nazione);

                    break;

                case 6:
                    Console.ForegroundColor = BlueColor;
                    Console.Write("\nInserisci il numero di copie: ");
                    Console.ForegroundColor = DefaultColor;
                    copie[DVD_disponibili] = getNumber(0, int.MaxValue);

                    break;

                case 0:

                    break;

            }


        } while (cambiamenti != 0);
    }
}

// funzione per rimuovere DVD
void removeDVD()
{
    Console.ForegroundColor = BlueColor;
    Console.WriteLine("\nDVD disponibili: ");
    Console.ForegroundColor = DefaultColor;

    stampaDisponibili();

    Console.WriteLine("0. Esci");

    Console.ForegroundColor = BlueColor;
    Console.Write("Scegli: ");
    Console.ForegroundColor = DefaultColor;
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
            copie[i] = copie[i + 1];
            nazione_sviluppo[i] = nazione_sviluppo[i + 1];
        }

        // pulizia dell'ultimo slot
        titoli[DVD_disponibili] = "";
        registi[DVD_disponibili] = "";
        durate[DVD_disponibili] = 0;
        categorie[DVD_disponibili] = "";
        nazione_sviluppo[DVD_disponibili] = "";
        copie[DVD_disponibili] = 0;
        DVD_disponibili--;

        Console.ForegroundColor = GreenColor;
        Console.WriteLine($"\n\"{titolo_rimosso}\" rimosso con successo!!");
        Console.ForegroundColor = DefaultColor;
    }
}

// mostra DVD con una durata compresa in un intervallo
void showDVDforRange()
{
    Console.ForegroundColor = BlueColor;
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

            Console.WriteLine($"========== {titoli[i]} ==========\n" +
                  $" - Fatto da: {registi[i]}\n" +
                  $" - Durata: {durate[i]}\n" +
                  $" - Categoria: {categorie[i]}\n" +
                  $" - Nazione: {nazione_sviluppo[i]}\n" +
                  $" - Copie: {copie[i]}\n");
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

// cerca DVD per il titolo, 
int searchDVDbyTitle()
{
    Console.ForegroundColor = BlueColor;
    Console.Write("\nChe DVD vuoi cercare (0->Esci)? ");
    Console.ForegroundColor = DefaultColor;
    string ricercaDVD = getStringWithLimit(limite_titolo).ToLower();
    if (ricercaDVD == "0") return -1;
    bool trovato = false;
    int indice = 0;
    for (int i = 0; i <= DVD_disponibili; i++)
    {
        if (titoli[i] != null && titoli[i].ToLower().Contains(ricercaDVD) && trovato == false)
        {
            trovato = true;
            indice = i;
        }
        else if (titoli[i] != null && titoli[i].ToLower().Contains(ricercaDVD) && trovato == true)
        {
            Console.ForegroundColor = RedColor;
            Console.WriteLine("Non sufficiente!");
            Console.ForegroundColor = DefaultColor;
            return -2;
        }
    }
    if (!trovato)
    {
        Console.ForegroundColor = RedColor;
        Console.WriteLine("Nessun DVD trovato.");
        Console.ForegroundColor = DefaultColor;
        return -2;
    }
    return indice;
}

//
void showDVDbyProducer()
{
    Console.ForegroundColor = BlueColor;
    Console.Write("\nChe regista vuoi cercare? ");
    Console.ForegroundColor = DefaultColor;
    string ricercaRegista = getStringWithLimit(limite_regista).ToLower();
    bool trovato = false;
    for (int i = 0; i <= DVD_disponibili; i++)
    {
        if (registi[i] != null && registi[i].ToLower().Contains(ricercaRegista))
        {
            Console.WriteLine($"{i + 1}.\n" +
                              $"========== {titoli[i]} ==========\n" +
                              $" - Fatto da: {registi[i]}\n" +
                              $" - Durata: {durate[i]}\n" +
                              $" - Categoria: {categorie[i]}\n" +
                              $" - Nazione: {nazione_sviluppo[i]}\n" +
                              $" - Copie: {copie[i]}\n");
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

//DEVI CAMBIARE IL CONSOLE.WRITELINE E INCOLONNARLO
void showLongerDVD()
{
    int indiceMax = 0;
    for (int i = 1; i <= DVD_disponibili; i++)
    {
        if (durate[i] > durate[indiceMax]) indiceMax = i;
    }

    Console.WriteLine($"========== {titoli[indiceMax]} ==========\n" +
                          $" - Fatto da: {registi[indiceMax]}\n" +
                          $" - Durata: {durate[indiceMax]}\n" +
                          $" - Categoria: {categorie[indiceMax]}\n" +
                          $" - Nazione: {nazione_sviluppo[indiceMax]}\n" +
                          $" - Copie: {copie[indiceMax]}\n");
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
    Console.WriteLine("\nDVD ordinati per durata: ");
    Console.ForegroundColor = DefaultColor;
    stampaDisponibili();
}

//
int getwantedDVD()
{
    //DA CORREGGERE ERRORE NEL DO WHILE: SE searchDVDbyTitle() DIVENTA -2 IL PROGRAMMA NON ESCE PIU'!!
    int wantedDVD;
    do
    {
        for (int i = 0; i < DVD_disponibili; i++)
        {
            Console.WriteLine($"========== {titoli[i]} ==========\n" +
                      $" - Fatto da: {registi[i]}\n" +
                      $" - Durata: {durate[i]}\n" +
                      $" - Categoria: {categorie[i]}\n" +
                      $" - Nazione: {nazione_sviluppo[i]}\n" +
                      $" - Copie: {copie[i]}\n");

        }

        wantedDVD = searchDVDbyTitle();
        if (wantedDVD < 0)
            return wantedDVD;

        if (copie[wantedDVD] <= 0)
        {
            Console.ForegroundColor = RedColor;
            Console.WriteLine("Copie esaurite.");
            Console.ForegroundColor = DefaultColor;
            wantedDVD = -2;
        }

    } while (wantedDVD == -2);

    return wantedDVD;
}

//
void borrowDVD()

{
    int wantedDVD = getwantedDVD();
    if (wantedDVD == -1 || wantedDVD == -2) return;

    Console.WriteLine($"========== {titoli[wantedDVD]} ==========\n" +
                      $" - Fatto da: {registi[wantedDVD]}\n" +
                      $" - Durata: {durate[wantedDVD]}\n" +
                      $" - Categoria: {categorie[wantedDVD]}\n" +
                      $" - Nazione: {nazione_sviluppo[wantedDVD]}\n" +
                      $" - Copie: {copie[wantedDVD]}\n");

    Console.ForegroundColor = BlueColor;
    Console.WriteLine("Scegli un opzione: ");
    Console.ForegroundColor = DefaultColor;

    Console.WriteLine("\n1. Prendi in prestito\n0. torna al menù.");
    bool stocastico = (getChar(['1', '0']) == '1');
    if (stocastico == true)
    {

        Console.ForegroundColor = BlueColor;
        Console.WriteLine("Digita il tuo nome: ");
        Console.ForegroundColor = DefaultColor;

        persona_prestato[wantedDVD] = getStringWithLimit(20);

        Console.ForegroundColor = BlueColor;
        Console.WriteLine("Digita il tuo cognome: ");
        Console.ForegroundColor = DefaultColor;

        persona_prestato[wantedDVD] = persona_prestato[wantedDVD] + " " + getStringWithLimit(20);

        Console.ForegroundColor = BlueColor;
        Console.WriteLine("Per quanti giorni vuoi prenotare il DVD (massimo 30)? ");
        Console.ForegroundColor = DefaultColor;

        int giorni_richiesti = getNumber(1, 30);

        data_prestito[wantedDVD] = DateTime.Today.ToString("dd/MM/yyyy");
        data_riconsegna[wantedDVD] = DateTime.Today.AddDays(giorni_richiesti).ToString("dd/MM/yyyy");

        Console.ForegroundColor = GreenColor;
        Console.WriteLine($"Confermata data di riconsegna: {data_riconsegna[wantedDVD]}");
        Console.ForegroundColor = DefaultColor;

        copie[wantedDVD] -= 1;

        //correzione di eventuali errori dall'utente
        int cambiamenti2;
        do
        {
            Console.WriteLine($"Nome e cognome: {persona_prestato[wantedDVD]};\n data di riconsegna: {data_riconsegna[wantedDVD]}.");

            Console.ForegroundColor = BlueColor;
            Console.WriteLine("Vuoi modificare qualcosa? Scegli:\n");
            Console.ForegroundColor = DefaultColor;

            Console.WriteLine("1. Nome e Cognome\n2. Data riconsegna\n0. Esci");

            Console.ForegroundColor = BlueColor;
            Console.Write("Scegli: ");
            Console.ForegroundColor = DefaultColor;
            cambiamenti2 = getNumber(0, 2);

            switch (cambiamenti2)
            {
                case 1:
                    Console.ForegroundColor = BlueColor;
                    Console.WriteLine("Digita il tuo nome: ");
                    Console.ForegroundColor = DefaultColor;

                    persona_prestato[wantedDVD] = getStringWithLimit(20);

                    Console.ForegroundColor = BlueColor;
                    Console.WriteLine("Digita il tuo cognome: ");
                    Console.ForegroundColor = DefaultColor;

                    persona_prestato[wantedDVD] = persona_prestato[wantedDVD] + " " + getStringWithLimit(20);

                    break;
                case 2:
                    Console.ForegroundColor = BlueColor;
                    Console.WriteLine("Per quanti giorni vuoi prenotare il DVD(massimo 30): ");
                    Console.ForegroundColor = DefaultColor;

                    giorni_richiesti = getNumber(1, 30);

                    data_prestito[wantedDVD] = DateTime.Today.ToString("dd/MM/yyyy");
                    data_riconsegna[wantedDVD] = DateTime.Today.AddDays(giorni_richiesti).ToString("dd/MM/yyyy");

                    Console.ForegroundColor = BlueColor;
                    Console.WriteLine($"Confermata data di riconsegna: {data_riconsegna[wantedDVD]}");
                    Console.ForegroundColor = DefaultColor;

                    break;
                case 0:
                    break;
            }
        } while (cambiamenti2 != 0);

        titoli_prestati[wantedDVD] = titoli[wantedDVD];
        registi_prestati[wantedDVD] = registi[wantedDVD];
        DVD_prestati++;

        Console.ForegroundColor = GreenColor;
        Console.WriteLine($"{titoli_prestati[wantedDVD]} prenotato con successo fino a data {data_riconsegna[wantedDVD]}!");
        Console.ForegroundColor = DefaultColor;
    }
}

//
void giveBackDVD()
{

}
