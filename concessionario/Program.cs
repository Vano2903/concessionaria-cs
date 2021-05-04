using System;

namespace concessionario {
        struct carSearch {
            public String marca;
            public String modello;
            public String colore;
            public int km;
            public int registrationYear;
            public float minPrice;
            public float maxPrice;
            public bool isNew;
            public bool isUsed;
        }

    class Program {
        

        static void Main(string[] args) {
            bool logged = false;
            bool quit = false;

            Console.WriteLine("concessionaria :D");
            carDealership cd = new carDealership();
            while (!quit) {
                if (logged) {
                    Console.Clear();
                    Console.WriteLine("ora sei nel main da loggato :D");
                } else {
                    bool stopAsk = true;
                    while (stopAsk) {
                        (var user, var pass) = loginInput();
                        if (cd.login(user, pass)) {
                            Console.WriteLine("Loggato con successo");
                            stopAsk = false;
                            logged = true;
                        }
                    }
                }
                 
            }
        }

        static public bool Switch() {
            string choiseS;

            string toPrint = "Opzioni disponibili \n1) ricerca auto \n2) compra auto \n3)vendi auto";
            Console.WriteLine(toPrint);
            choiseS = Console.ReadLine();
                switch (int.Parse(choiseS)) {
                    case 1:
                        handlerSearch();
                    break;

                    case 2:
                        handerBuy();
                    break;

                    case 3:
                        handerSell();
                    break;
            }
            return true;
        }

        static public void handlerSearch() {

        }

        static public void handerBuy() {

        }

        static public void handerSell() {

        }

        static public (string, string) loginInput() {
            string name, pass;
            Console.WriteLine("Logga all'interno del programma");
            Console.WriteLine("Username del venditore");
            name = Console.ReadLine();
            Console.WriteLine("Password del venditore");
            pass = Console.ReadLine();
            return (name, pass);
        }


    }
}