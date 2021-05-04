using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace concessionario {

    class carDealership {

        //attributi
        private seller sel;

        //metodi privati


        //metodi pubblici
        public bool login(string name, string pass) {
            return sel.login(name, pass);
        }

        public (List<car>, bool) customSearch(carSearch obj, bool condition ){
            //0 marca, 1 modello, 2 colore, 3 powerSource
            //4 km, 5 prezzo min, 6 prezzo max, 7 isNew, 8 isUsed
            //true = and, false = or
            List<List<car>> scanned = new List<List<car>>();
            //car[] scanned = new car[10];
            List<car> found = new List<car>();

            scanned.Add(obj.marca != "" ? sel.searchMarca(obj.marca) : null);
            scanned.Add(obj.modello != "" ? sel.searchModello(obj.modello) : null);
            scanned.Add(obj.colore != "" ? sel.searchColore(obj.colore) : null);
            scanned.Add(obj.km != -1 ? sel.searchKm(obj.km) : null);
            scanned.Add(obj.registrationYear != -1 ? sel.searchRegistrationYear(obj.registrationYear) : null);
            scanned.Add(obj.isNew != false ? sel.searchIsNew(obj.isNew) : null);
            scanned.Add(obj.isUsed != false ? sel.searchIsUsed(obj.isUsed) : null);
            scanned.Add(sel.searchBetweenPrices(obj.minPrice, obj.maxPrice));

            foreach(List<car> cars in scanned) {
                if (condition) {
                    if () { //CONTROLLO MULTIRICERCA 
                        found.Add();
                    }
                } else {

                }
            }

            return (found, false);
        }

        //costruttori
        public carDealership() {
            sel = new seller();
        }
    }
}
