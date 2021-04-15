using System;
using System.Collections.Generic;
using System.Text;

namespace concessionario
{
    class customer
    {
        private string nome;
        private string cognome;
        private string mail;
        private string telefono;
        private string id;

        public customer(string nome, string cognome, string mail, string telefono, string id)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.mail = mail;
            this.telefono = telefono;
            this.id = id;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Cognome { get => cognome; set => cognome = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Id { get => id; set => id = value; }

        //customer.Nome; // accesso negato
        //customer.Nome("Davide"); -> richiama il set
        //nomeCliente = customer.Nome(); -> richiama il get
    }
}
