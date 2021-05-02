using System;
using System.Collections.Generic;
using System.Text;

namespace concessionario {
    class customer {
        //attributi
        private string nome;
        private string cognome;
        private string mail;
        private string telefono;
        private string id;

        //get e set
        public string Nome { get => nome; set => nome = value; }
        public string Cognome { get => cognome; set => cognome = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Id { get => id; set => id = value; }
        
        //costruttori
        public customer(string nome, string cognome, string mail, string telefono, string id) {
            this.nome = nome;
            this.cognome = cognome;
            this.mail = mail;
            this.telefono = telefono;
            this.id = id;
        }
    }
}
