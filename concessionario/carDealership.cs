using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace concessionario {

    class carDealership {

        //attributi
        private seller sel;

        //costruttori
        private carDealership() {
            sel = new seller();
        }
    }
}
