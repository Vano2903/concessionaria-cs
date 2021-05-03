using System;

namespace concessionario {
   
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
                /*
                 switch (type)
                {
                    case 0: //marca

                        break;
                    case 1: //modello
                        break;
                    case 3: //colore
                        break;
                    case 4: //powerSource
                        break;
                    case 5: //km
                        break;
                    case 6: //registrationYear
                        break;
                    case 7: //isNew
                        break;
                    case 8: //isUsed
                        break
                }*/
            }
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