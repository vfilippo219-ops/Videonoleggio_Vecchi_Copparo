// ----  dichiarazione delle varabili e array per i dvd  ----
// numero massimo di DVD
int      dvd_massimi      = 20;

// ------ Array dei DVD NoN in prestito -------------
string[] titoli           = new string[dvd_massimi];
string[] registi          = new string[dvd_massimi];
int[]    durate           = new int[dvd_massimi];
string[] categorie        = new string[dvd_massimi];
string[] nazione_sviluppo = new string[dvd_massimi];

// ------ Array dei DVD in prestito ----------
string[] titoli_prestati  = new string[dvd_massimi];
string[] registi_prestati = new string[dvd_massimi];
int[] durate_prestati     = new int[dvd_massimi]; 

Console.WriteLine("Benvenuto al videonoleggio Filo_Cop");
Console.Write("Inserisci 'a' per admin, 'c' per cliente: ");

// chiedo un carattere che puo essere solo a o b cioe un array con due char accettabili
char ruolo = getChar(['a','b']);

if (ruolo == 'a')
{
    bool login = false;
    int tentativo = 0;
    Console.Write("\nInserisci la password(4-cifre): ");

    // chiede la password per un massimo di 4 volte
    while (!login && tentativo < 4) {
        int password = 0;
        if (password == 6767) login = true;
        else {
            Console.Write("Password errata, riprova: ");
        }
    }
    
    if (login) {
        Console.WriteLine("Scegli un opzione:\n"+
                          "1. Inserisci un nuovo DVD\n"+
                          "2. Rimuovi un DVD\n"+
                          "0. Fine\n"+
                          "Scegli: ");
        int chose = getNumber(0,2);
        switch (chose)
        {
            case 1:      // Inserimento DVD

                // questa e sbagliata
                Console.Write("\nInserisci il nome del DVD: ");
                dvd_massimi += 1;
                // cosi lo salva nello slot con indice 20 ma l array va da 0 a 19 e poi in caso come fai a sapere che prima non ci siano altri spazi vuoti
                // ti serve un altra variabile contatore per ricordarti quanti dvd ci sono effettivamente
                titoli[dvd_massimi] = Console.ReadLine();
                break;
            case 2:      // Rimozione DVD

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
            
            break;
        case 2:     // Ricerca per Regista
        
            break;
        case 3:     // Stampa DVD piu lungo
        
            break;
        case 4:     // Ordinamento per durata
        
            break;
        case 5:     // Stampa DVD per fascia di durata
        
            break;
        case 0:     // Uscita
            
            break;
    }
}

// funzione per creare i dvd senza dare troppo fastidio al codice
void prepareDVD(string[] titoli, string[] registi, int[] durate, string[] categorie, string[] nazione) {
    
    // ----- TITOLI -----------------
    titoli[0] = "";
    titoli[1] = "";
    titoli[2] = "";
    titoli[3] = "";
    titoli[4] = "";
    titoli[5] = "";
    titoli[6] = "";
    titoli[7] = "";

    // ----- REGISTI -----------------
    registi[0] = "";
    registi[1] = "";
    registi[2] = "";
    registi[3] = "";
    registi[4] = "";
    registi[5] = "";
    registi[6] = "";
    registi[7] = "";

    // ----- DURATE ------------------
    // qui si puo fare anche con random
    durate[0] = 0;
    durate[1] = 0;
    durate[2] = 0;
    durate[3] = 0;
    durate[4] = 0;
    durate[5] = 0;
    durate[6] = 0;
    durate[7] = 0;

    // ----- CATEGORIE ----------------
    // qui si puo fare un array con delle categorie e assegnarle con random
    categorie[0] = "";
    categorie[1] = "";
    categorie[2] = "";
    categorie[3] = "";
    categorie[4] = "";
    categorie[5] = "";
    categorie[6] = "";
    categorie[7] = "";

    // ----- NAZIONE ------------------
    // qui si puo fare come con categorie
    nazione[0] = "";
    nazione[1] = "";
    nazione[2] = "";
    nazione[3] = "";
    nazione[4] = "";
    nazione[5] = "";
    nazione[6] = "";
    nazione[7] = "";
}

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

char getChar(char[] accepted_chars)
{
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
string getName()
{
    // legge da terminale e memorizza in n
    string n = Console.ReadLine();
    // n == null cosi che se non inserisce niente non lo conta giusto
    while(n == null || n.Length > 10)
    {
        Console.Write("\nInput non valido, riprovare: ");
        n = Console.ReadLine();
    }
    
    return n;
}

