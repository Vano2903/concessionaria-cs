using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace concessionario
{
    class car
    {
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
