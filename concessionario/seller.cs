using System;using System.Collections.Generic;using System.Text;using System.IO;using Newtonsoft.Json;namespace concessionario {    //per salvataggio su file    struct user {        public int id;        public String username;        public String password;        //public int lvlAuth;    }    class seller {        //attributi        private List<car> cars;        private String username;        private String password;        //private int lvlAuth;        private int id;        private List<string> con;        //private methods        private void writeId(int iaaaa) {            string path = @"files\config.json";            con[0] = iaaaa.ToString();            StreamWriter sw = new StreamWriter(path);            string json = JsonConvert.SerializeObject(con, Formatting.Indented);            sw.WriteLine(json);            sw.Close();        }        private int getLastId() {            string path = @"files\config.json";            StreamReader sr = new StreamReader(path);            string json = sr.ReadToEnd();            con = JsonConvert.DeserializeObject<List<string>>(json);            sr.Close();            return int.Parse(con[1]);        }        private void genId() {            id = getLastId() + 1;            writeId(id);        }        /*private bool checkAuth(int i) {            if(lvlAuth >= i) {                return true;            }            return false;        }*/        private void loadCars() {            StreamReader sr = new StreamReader(@"files\cars.json");            string json = sr.ReadToEnd();            cars = JsonConvert.DeserializeObject<List<car>>(json);            sr.Close();        }        private void writeCars() {            StreamWriter sw = new StreamWriter(@"files\cars.json");            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);            sw.WriteLine(json);            sw.Close();        }        private List<user> loadUsers() {            StreamReader sr = new StreamReader(@"files\sellers.json");            string json = sr.ReadToEnd();            var users = JsonConvert.DeserializeObject<List<user>>(json);            sr.Close();            return users;        }        //public methods        public void buyAuto(car a) {
            if(cars == null) {
                List<car> supp = new List<car>();
                supp.Add(a);
                StreamWriter sw = new StreamWriter(@"files\cars.json");
                string json = JsonConvert.SerializeObject(supp, Formatting.Indented);
                sw.WriteLine(json);
                sw.Close();
                loadCars();
            }
            cars.Add(a);
            writeCars();
        }        public bool login(string username, string password) {            List<user> users = loadUsers() ;            foreach (user user in users) {                if(user.username == username && user.password == password) {                    loadCars();                    this.username = username;                    this.password = password;                    this.id = user.id;                    return true;                }            }            return false;        }        public void logout() {
            username = "";
            password = "";
            //lvlAuth = 0;            id = -1;
    }            //metodi di ricerca        public List<car> searchMarca(string marca) {            List<car> found = new List<car>();            foreach (car a in cars) {                if (a.Marca == marca) {
                    found.Add(a);
                }            }            return found;        }        public List<car> searchModello(string modello) {            List<car> found = new List<car>();            foreach(car a in cars) {                if (a.Modello == modello) {
                    found.Add(a);
                }            }            return found;        }
        public List<car> searchColore(string colore) {            List<car> found = new List<car>();            foreach (car a in cars) {                if (a.Colore == colore) {
                    found.Add(a);
                }            }            return found;        }        public List<car> searchPowerSource(string powerSource) {            List<car> found = new List<car>();            foreach (car a in cars) {                if (a.PowerSource == powerSource) {
                    found.Add(a);
                }            }            return found;        }
        public List<car> searchKm(int km) {            List<car> found = new List<car>();            foreach (car a in cars) {                if (a.Km == km) {
                    found.Add(a);
                }            }            return found;        }
        public List<car> searchRegistrationYear(int registrationYear) {            List<car> found = new List<car>();            foreach (car a in cars) {                if (a.RegistrationYear == registrationYear) {
                    found.Add(a);
                }            }            return found;        }
        public List<car> searchBetweenPrices(float min, float max) { 
            
            List<car> found = new List<car>();
            foreach (car a in cars) {
                found.Add(min == -1 ? a.Price <= max ? a : null : max == -1 ? a.Price >= min ? a : null : a.Price >= min && a.Price <= max ? a : null);
            }
                found.RemoveAll(item => item == null);
            return found;
        }
        public List<car> searchIsNew(bool isNew) {
            List<car> found = new List<car>();
            foreach(car a in cars) {
                found.Add(a.IsNew == isNew ? a : null);
            }
            return found;
        }        public List<car> searchIsUsed(bool isUsed) {
            List<car> found = new List<car>();
            foreach (car a in cars) {
                if (a.IsUsed == isUsed) {
                    found.Add(a);
                }
            }
            return found;
        }        public car searchId(int id) {            foreach(car a in cars) {
                if (a.Id == id) {
                    return a;
                }
            }            return null;        }

        /*
        public (List<car>, bool) customSearch(carSearch obj) {
            //0 marca, 1 modello, 2 colore, 3 powerSource
            //4 km, 5 prezzo min, 6 prezzo max, 7 isNew, 8 isUsed
            List<car> found = new List<car>();

            foreach (car a in cars) {     //CONTROLLO MULTIRICERCA 
                if(a.Marca == obj.marca && a.Modello == obj.modello && a.Colore == obj.colore) {

                }
            }

            return (found, false);
        }
        */

        //costruttori
        public seller() {            cars = new List<car>();            username = "";            password = "";            //lvlAuth = 0;            genId();        }    }}