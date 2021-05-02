using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace concessionario
{
    class car
    {
        //atrtibuti
        private String marca;
        private String modello;
        private String colore;
        private String powerSource;
        private int id;
        private int km;
        private int registrationYear;
        private bool isNew;
        private bool isUsed;
        private List<string> con; //just for the config file
        
        //get e set
        public String Marca { get => marca; set => marca = value; }
        public String Modello { get => modello; set => modello = value; }
        public String Colore { get => colore; set => colore = value; }
        public String PowerSource { get => powerSource; set => powerSource = value; }
        public int Id { get => id; }
        public int Km { get => km; set => km = value; }
        public int RegistrationYear { get => registrationYear; set => registrationYear = value; }
        public bool IsNew { get => isNew; set => isNew = value; }
        public bool IsUsed { get => isUsed; set => isUsed = value; }
        

        //privati
        private void writeId(int iaaaa)
        {
            string path = @"files\config.json";

            con[0] = iaaaa.ToString();
            StreamWriter sw = new StreamWriter(path);
            string json = JsonConvert.SerializeObject(con, Formatting.Indented);
            sw.WriteLine(json);
            sw.Close();

        }
        private int getLastId()
        {
            string path = @"files\config.json";

            StreamReader sr = new StreamReader(path);
            string json = sr.ReadToEnd();

            con = JsonConvert.DeserializeObject<List<string>>(json);
            sr.Close();
            return int.Parse(con[0]);
        }
        private void genId()
        {
            id = getLastId() + 1;
            writeId(id);
        }

        //costruttori
        public car() {
            marca = "";
            modello = "";
            colore = "";
            powerSource = "";
            km = 0;
            registrationYear = 0;
            isNew = false;
            isUsed = false;
            genId();
        }
        public car(string ma, string mo, string co, string ps, int km, int ry, bool n, bool u)
        {
            marca = ma;
            modello = mo;
            colore = co;
            powerSource = ps;
            this.km = km;
            registrationYear = ry;
            isNew = n;
            isUsed = u;
            genId();
        }
    }
}
