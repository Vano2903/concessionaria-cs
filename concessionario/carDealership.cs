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

        
        //costruttori
        public carDealership() {
            sel = new seller();
        }
    }
}
