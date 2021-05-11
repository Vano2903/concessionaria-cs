using System;
using System.Collections.Generic;

namespace concessionario {
    /*struct carSearch {
        public String marca;
        public String modello;
        public String colore;
        public String powerSource;
        public int km;
        public int registrationYear;
        public float minPrice;
        public float maxPrice;
        public bool isNew;
        public bool isUsed;
    }*/

    class Program {
        static seller cd;
        static void Main(string[] args) {
            cd = new seller();
            bool logged = false;
            bool quit = false;

            Console.WriteLine("concessionaria D:");
            
            while (true) {
                if (logged) {
                    Console.Clear();
                    Console.WriteLine("ora sei nel main da loggato :D");
                    if(Home()) {
                        cd.save();
                        Environment.Exit(0);
                    }
                } else {
                    bool stopAsk = true;
                    while (stopAsk) {
                        (var user, var pass) = LoginInput();
                        if (cd.login(user, pass)) {
                            Console.WriteLine("Loggato con successo");
                            stopAsk = false;
                            logged = true;
                        }
                    }
                }
            }
        }

        static public bool Home() {
            string choiseS;
            int choise = -1;
            int i = 0;
            string toPrint = "Opzioni disponibili \n1) ricerca auto \n2) compra auto \n3) vendi auto\n4) esci dal programma";
            do {
                Console.Clear();
                Console.WriteLine(toPrint);
                choiseS = Console.ReadLine();
                try {
                    choise = int.Parse(choiseS);
                } catch {
                    i++;
                    if (i == 1) {
                        toPrint += "\n\n...questa volta mettendo un numero vero peró ;-;";
                    }
                }
            } while (choise > 4 || choise <= 0 );
                switch (choise) {
                    case 1:
                        HandlerSearch();
                    return false;

                    case 2:
                        HanderBuy();
                    return false;

                    case 3:
                        HanderSell();
                    return false;

                    default:
                    return true;
                }
        }

        static public int HandlerSearch() {
            string choiseS;
            int choise;

            string toPrint = "Ricerche disponibili: \n\n1) marca \n2) modello \n3) colore \n4) carburante \n5) chilometri \n6) anno di registrazione \n7) prezzo \n8) auto nuove \n9) auto usate \n0) id";
            do {
                Console.Clear();
                Console.WriteLine(toPrint);
                choiseS = Console.ReadLine();
                choise = int.Parse(choiseS);
            } while (choise > 9 || choise <= -1);
            
            string sType;
            string element;
            int elementI;
            List<car> cars;
            switch (choise) {
                case 1: //marca
                    sType = "marca";
                    do {
                        Console.Clear();
                        Console.WriteLine("ricerca per " + sType + ":\n\ninserisci " + sType + ": ");
                        element = Console.ReadLine();
                    } while (element == "");

                    cars = cd.searchMarca(element);
                    printList(cars);
                    var poisson = Console.ReadLine();
                    return -1;//getIdFromList(cars);

                case 2: //modello
                    sType = "modello";
                    do {
                        Console.Clear();
                        Console.WriteLine("ricerca per " + sType + ":\n\ninserisci " + sType + ": ");
                        element = Console.ReadLine();
                    } while (element == "");

                    cars = cd.searchModello(element);
                    printList(cars);
                    return getIdFromList(cars);

                case 3: //colore
                    sType = "colore";
                    do {
                        Console.Clear();
                        Console.WriteLine("ricerca per " + sType + ":\n\ninserisci " + sType + ": ");
                        element = Console.ReadLine();
                    } while (element == "");

                    cars = cd.searchColore(element);
                    printList(cars);
                    return getIdFromList(cars);

                case 4: //powerSource
                    sType = "carburante ";
                    do {
                        Console.Clear();
                        Console.WriteLine("ricerca per " + sType + ":\n\ninserisci " + sType + ": ");
                        element = Console.ReadLine();
                    } while (element == "");

                    cars = cd.searchPowerSource(element);
                    printList(cars);
                    return getIdFromList(cars);

                case 5: //km
                    sType = "chilometri";
                    do {
                        Console.Clear();
                        Console.WriteLine("ricerca per " + sType + ":\n\ninserisci " + sType + ": ");
                        element = Console.ReadLine();
                        elementI = int.Parse(element);
                    } while (element == "" && elementI < 0);

                    cars = cd.searchKm(elementI);
                    printList(cars);
                    return getIdFromList(cars);

                case 6: //registration Year
                    sType = "anno di registrazione";
                    do {
                        Console.Clear();
                        Console.WriteLine("ricerca per " + sType + ":\n\ninserisci " + sType + ": ");
                        element = Console.ReadLine();
                        elementI = int.Parse(element);
                    } while (element == "" && elementI < 0);

                    cars = cd.searchRegistrationYear(elementI);
                    printList(cars);
                    return getIdFromList(cars);

                case 7: //between prices
                    sType = "prezzo ";
                    float min;
                    float max;
                    Console.Clear();
                    Console.WriteLine("ricerca per " + sType + ":\n\ninserisci il prezzo minimo: ");
                    do {
                        element = Console.ReadLine();
                        min = element == "" ? -1 : float.Parse(element);

                        Console.WriteLine("inserisci il prezzo massimo: ");
                        element = Console.ReadLine();
                        max = element == "" ? -1 : float.Parse(element);
                    } while (min < -1 && max < -1);

                    cars = cd.searchBetweenPrices(min, max);
                    printList(cars);
                    return getIdFromList(cars);

                case 8: //isNew
                    Console.Clear();
                    Console.WriteLine("lista di tutte le auto nuove: ");

                    cars = cd.searchIsNew(true);
                    printList(cars);
                    return getIdFromList(cars);

                case 9: //isUsed
                    Console.Clear();
                    Console.WriteLine("lista di tutte le auto usate: ");

                    cars = cd.searchIsNew(true);
                    printList(cars);
                    return getIdFromList(cars);

                default: //id
                    sType = "id";
                    do {
                        Console.Clear();
                        Console.WriteLine("ricerca per " + sType + ":\n\ninserisci il prezzo minimo: ");
                        element = Console.ReadLine();
                        elementI = int.Parse(element);
                    } while (element != "" || elementI < 0);

                    var a = cd.searchId(elementI);
                    Console.WriteLine(a.ToString());
                    return a == null ? -1 : a.Id;
            }
        }

        static public void HanderBuy() {
            Console.Clear();
            Console.WriteLine("Compra Auto\n");
            string marca;
            string modello;
            string colore;
            string powerSource;
            int km;
            int rYear;
            float price;
            bool isNew;
            bool isUsed;

            do {
                Console.Clear();
                Console.WriteLine("inserire la marca dell'auto:");
                marca = Console.ReadLine();
            } while (marca == "");

            do {
                Console.Clear();
                Console.WriteLine("inserire il modello dell'auto:");
                modello = Console.ReadLine();
            } while (modello == "");

            do {
                Console.Clear();
                Console.WriteLine("inserire il colore dell'auto:");
                colore = Console.ReadLine();
            } while (colore == "");

            do {
                Console.Clear();
                Console.WriteLine("inserire il tipo di carburante dell'auto:");
                powerSource = Console.ReadLine();
            } while (powerSource == "");

            do {
                Console.Clear();
                Console.WriteLine("inserire il chilometraggio dell'auto:");
                km = int.Parse(Console.ReadLine());
            } while (km < 0);

            do {
                Console.Clear();
                Console.WriteLine("inserire l'anno di registrazione dell'auto:");
                rYear = int.Parse(Console.ReadLine());
            } while (rYear < 0);

            do {
                Console.Clear();
                Console.WriteLine("inserire il prezzo dell'auto:");
                price = float.Parse(Console.ReadLine());
            } while (price < 0.0);

            string risp;
            do {
                Console.Clear();
                Console.WriteLine("l'auto é nuova? (s/n):");
                risp = Console.ReadLine();
            } while (risp == "s" && risp == "n" && risp == "S" && risp == "N");

            isNew = risp == "s" || risp == "S" ? true : false;

            do {
                Console.Clear();
                Console.WriteLine("l'auto é usata? (s/n):");
                risp = Console.ReadLine();
            } while (risp == "s" && risp == "n" && risp == "S" && risp == "N");

            isUsed = risp == "s" || risp == "S" ? true : false;

            car toAdd = new car(marca, modello, colore, powerSource, km, rYear, price, isNew, isUsed);
            cd.buyAuto(toAdd);
            Console.WriteLine("auto comprata con successo");
            toAdd.ToString();
        }

        static public void HanderSell() {
        }

        static public (string, string) LoginInput() {
            string name, pass;
            Console.WriteLine("Logga all'interno del programma");
            Console.WriteLine("Username del venditore");
            name = Console.ReadLine();
            Console.WriteLine("Password del venditore");
            pass = Console.ReadLine();
            return (name, pass);
        }
        static public void printList(List<car> cars) {
            int i = 0;
            if (cars.Count != 0) {
                Console.WriteLine("nessun elemento trovato");
            } else {
                foreach (car a in cars) {
                    Console.WriteLine(i.ToString() + ") " + a.ToString());
                }
            }
        }
        static public int getIdFromList(List<car> cars) {
            int id = -1;
            List<int> idl = new List<int>();

            Console.Clear();
            foreach(car a in cars) {
                idl.Add(a.Id);
                idl.ToString();
            }
            do {
                string ids = Console.ReadLine();
                id = int.Parse(ids);
            } while (!idl.Contains(id));
            return id;
        }
    }
}