int      dvd_massimi      = 20;
string[] titoli           = new string[dvd_massimi];
string[] registi          = new string[dvd_massimi];
int[]    durata           = new int[dvd_massimi];
string[] categorie        = new string[dvd_massimi];
string[] nazione_sviluppo = new string[dvd_massimi];


Console.WriteLine("Benvenuto al videonoleggio Filo_Cop");
Console.Write("Inserisci 'a' per admin, 'c' per cliente: ");

// chiedo un carattere che possa essere solo a o b cioe un array con due char accettabili
char ruolo = getChar(new char[]{'a','b'});
if (ruolo == 'a')
{
    Console.Write("\nInserisci la password(4-cifre): ");
    int password = 0;
    while (password != 6767)
    {
        Console.Write("")
    }
    
    Console.WriteLine("Scegli un opzione:\n"+
                      "1. Inserisci un nuovo DVD\n"+
                      "2. Rimuovi un DVD\n"+
                      "0. Fine\n"+
                      "Scegli: ");
    int chose = getNumber(0,2);
    switch (chose)
    {
        case 1:

            // questa e sbagliata
            Console.Write("\nInserisci il nome del DVD: ");
            dvd_massimi += 1;
            // cosi lo salva nello slot con indice 20 ma l array va da 0 a 19 e poi in caso come fai a sapere che prima non ci siano altri spazi vuoti
            // ti serve un altra variabile contatore per ricordarti quanti dvd ci sono effettivamente
            titoli[dvd_massimi] = Console.ReadLine();
            break;
        case 2:

            break;
        case 0:

            break;
    }
}
else
{
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
        case 1:
            
            break;
        case 2:
        
            break;
        case 3:
        
            break;
        case 4:
        
            break;
        case 5:
        
            break;
        case 6:
        
            break;
        case 7:
        
            break;
        case 0:
        break;
    }
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

string  getString()
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

