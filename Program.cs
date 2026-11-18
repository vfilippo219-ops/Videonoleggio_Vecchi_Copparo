// ----  dichiarazione delle varabili e array per i dvd  ----

// numero massimo di DVD
int      DVD_massimi      = 20;

// ------ Array dei DVD NoN in prestito -------------
string[] titoli           = new string[DVD_massimi];
string[] registi          = new string[DVD_massimi];
int[]    durate           = new int[DVD_massimi];
string[] categorie        = new string[DVD_massimi];
string[] nazione_sviluppo = new string[DVD_massimi];

// ------ Array dei DVD in prestito ----------
string[] titoli_prestati    = new string[DVD_massimi];
string[] registi_prestati   = new string[DVD_massimi];
int[] durate_prestati       = new int[DVD_massimi];
string[] categoria_prestati = new string[DVD_massimi];
string[] nazione_prestati   = new string[DVD_massimi];

prepareDVD(titoli, registi, durate, categorie, nazione_sviluppo);

// variabile contatore per sapere quanti DVD sono disponibili
int DVD_disponibili = 8-1;
Console.WriteLine(DVD_disponibili);

// variabile contatore per sapere quanti libri sono in prestito
int DVD_prestati = 0;

//variabili per limiti stringhe
int limite_regista = 30;
int limite_titolo = 50;
int limite_categoria = 30;
int limite_nazione = 20;


Console.WriteLine("Benvenuto al videonoleggio Filo_Cop");
Console.Write("Inserisci 'a' per admin, 'c' per cliente: ");

// chiedo un carattere che puo essere solo a o b e lo indico con un array con due char accettabili
char ruolo = getChar(['a','c']);

if (ruolo == 'a')
{
    bool login = false;
    int tentativo = 0;
    Console.Write("\nInserisci la password(4-cifre): ");

    // chiede la password per un massimo di 4 volte
    while (!login && tentativo < 4) {
        tentativo++;
        string password = getStringWithLimit(4);
        if (password == "6767") login = true;
        else {
            if (tentativo != 4) Console.Write("Password errata, riprova: ");
        }
    }
    
    if (login) {
        Console.WriteLine("\nBenvenuto!!");
        Console.Write("\nScegli un opzione:\n"+
                          "1. Inserisci un nuovo DVD\n"+
                          "2. Rimuovi un DVD\n"+
                          "0. Fine\n"+
                          "Scegli: ");
        int chose = getNumber(0,2);
        
        switch (chose)
        {
            case 1:      // Inserimento DVD
                Console.Write("\nInserisci il titolo del DVD (exit6767 -> esci): ");
                string titolo = getStringWithLimit(limite_titolo);
                if(titolo.ToLower() == "exit6767") {
                    Console.WriteLine("Ritorno al menù!\n");
                }
                else {
                    DVD_disponibili += 1;
                    titoli[DVD_disponibili] = titolo;
                    Console.Write("\nInserisci il regista del DVD: ");
                    registi[DVD_disponibili] = getStringWithLimit(limite_regista);
                    Console.Write("\nInserisci il durata del DVD: ");
                    durate[DVD_disponibili] = getNumber(0, int.MaxValue);
                    Console.Write("\nInserisci la categoria del DVD: ");
                    categorie[DVD_disponibili] = getStringWithLimit(limite_categoria);
                    Console.Write("\nInserisci la nazione del DVD: ");
                    nazione_sviluppo[DVD_disponibili] = getStringWithLimit(limite_nazione);
                }
                
                break;
                
            case 2:      // Rimozione DVD
                Console.WriteLine("\nDVD disponibili:");
                stampaDisponibili();
                Console.WriteLine("0. Esci");
                Console.Write("Scegli: ");
                int scelta = getNumber(0, DVD_disponibili+1);
                scelta--;

                if (scelta != -1) {
                    int indice_DVD = scelta;
                    do {
                        for (int i = scelta; i < DVD_disponibili; i++) {
                            if (i < DVD_disponibili) {
                                indice_DVD++;

                                string titolo_app = titoli[i];
                                string registi_app = registi[i];
                                int durata_app = durate[i];
                                string categoria_app = categorie[i];
                                string nazione_app = nazione_sviluppo[i];

                                titoli[i] = titoli[i + 1];
                                registi[i] = registi[i + 1];
                                durate[i] = durate[i + 1];
                                categorie[i] = categorie[i + 1];
                                nazione_sviluppo[i] = nazione_sviluppo[i + 1];

                                titoli[i + 1] = titolo_app;
                                registi[i + 1] = registi_app;
                                durate[i + 1] = durata_app;
                                categorie[i + 1] = categoria_app;
                                nazione_sviluppo[i + 1] = nazione_app;
                            }
                        }
                    } while (indice_DVD < DVD_disponibili);
                    Console.WriteLine("\n"+titoli[DVD_disponibili]+" by "+registi[DVD_disponibili]+" rimosso con successo!!");
                    DVD_disponibili--;
                }
                break;
            case 0:      // Uscita
                break;
        }
    }
    else {      // login errato chiusura programma
        Console.WriteLine("\nTentativi terminati!!");
    }
}
else
{
    // Cliente
    Console.Write("Scegli un'opzione:\n"+
                  "1. Consulta DVD\n"+
                  "2. Cerca DVD per regista\n"+
                  "3. Stampa DVD piu lungo\n"+
                  "4. Ordina DVD per durata\n"+
                  "5. Stampa DVD per fascia di durata\n"+
                  "0. Esci\n"+
                  "Scegli: ");
    int chose = getNumber(0,5);
    switch (chose)
    {
        case 1:     // consultazione
            Console.WriteLine(stampaDisponibili);
            
            break;
        case 2:     // Ricerca per Regista
            Console.Write("\nChe regista vuoi cercare?");
            string ricercaRegista = getStringWithLimit(limite_regista);
            ricercaRegista = ricercaRegista.ToLower();
            for(int i = 0; i < DVD_disponibili; i++)
            {
                if(registi[i].ToLower() == ricercaRegista){
                    Console.WriteLine($"Nome: {titoli[i]}\nRegista {registi[i]}\nDurata {durate[i]}\nCategoria {categorie[i]}\nNazione {nazione_sviluppo[i]}");
                }
            }

            break;
        case 3:     // Stampa DVD piu lungo
            int indiceMax = 0;
            for(int i = 0; i < DVD_disponibili; i++){
                if(durate[i] > durate[indiceMax]) indiceMax = i;
            }
            Console.WriteLine($"Nome: {titoli[indiceMax]}\nRegista {registi[indiceMax]}\nDurata {durate[indiceMax]}\nCategoria {categorie[indiceMax]}\nNazione {nazione_sviluppo[indiceMax]}");

            break;
        case 4:     // Ordinamento per durata
            
            break;
        case 5:     // Stampa DVD per fascia di durata
        
            break;
        case 0:     // Uscita
            
            break;
    }
}

// funzione per creare i DVD senza dare troppo fastidio al codice
void prepareDVD(string[] titoli, string[] registi, int[] durate, string[] categorie, string[] nazione) {
    
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
    // qui si puo fare anche con random
    durate[0] = 119;
    durate[1] = 69;
    durate[2] = 104;
    durate[3] = 36;
    durate[4] = 90;
    durate[5] = 150;
    durate[6] = 67;
    durate[7] = 130;

    // ----- CATEGORIE ----------------
    // qui si puo fare un array con delle categorie e assegnarle con random
    categorie[0] = "Giallo";
    categorie[1] = "Hot, Horror, Culinario";
    categorie[2] = "Esplorazione";
    categorie[3] = "Culinario";
    categorie[4] = "Fantasy";
    categorie[5] = "Comico";
    categorie[6] = "Misterioso";
    categorie[7] = "Caldo🥵🫠";

    // ----- NAZIONE ------------------
    // qui si puo fare come con categorie
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
int getNumber(int min, int max) {
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
char getChar(char[] accepted_chars) {
    bool input_valido = false;
    char let = ' ';
    while (!input_valido)
    {
        if (char.TryParse(Console.ReadLine(), out let))
        {
            // converto la lettera che ha inserito in lower case cosi che non devo controllare 2 volte
            string app = let.ToString();
            app = app.ToLower();
            let = Convert.ToChar(app);
            
            // controllo la lettera con tutte le lettere accettabili
            for (int i = 0; i < accepted_chars.Length; i++)
            {
                if (let == accepted_chars[i]) input_valido = true;
            }
        }
        else Console.Write("Input errato, riprova: ");   
    }
    return let;
}

// l ho rinominato getName perche lo useremo solo per il nome/regista/categoria quindi getString si
// confonderebbe con Console.ReadLine()
string getStringWithLimit(int limit) {
    // legge da terminale e memorizza in n
    string n = Console.ReadLine();
    // n == null cosi che se non inserisce niente non lo conta giusto
    while(n == null || n.Length > limit)
    {
        Console.Write("\nInput non valido, riprovare: ");
        n = Console.ReadLine();
    }
    
    return n;
}

void stampaDisponibili() {
    for (int i = 0; i < DVD_disponibili+1; i++) {
        Console.WriteLine((i+1)+". "+titoli[i]+" by "+registi[i]+", durata: "+durate[i]+"min, "+categorie[i]+" from "+nazione_sviluppo);
    }
}

