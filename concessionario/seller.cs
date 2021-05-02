using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace concessionario
{
    struct user
    {
        public int id;
        public String username;
        public String password;
        public int lvlAuth;
    }
    class seller
    {
        private List<car> cars;
        private String username;
        private String password;
        private int lvlAuth;
        private int id;
        private List<string> con;

        //private methods

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
            return int.Parse(con[1]);
        }

        private void genId()
        {
            id = getLastId() + 1;
            writeId(id);
        }

        //make this one better cause rn it kinda sucks ;-;
        private bool checkAuth(int i)
        {
            if(lvlAuth >= i)
            {
                return true;
            }
            return false;
        }

        private void loadCars()
        {
            StreamReader sr = new StreamReader(@"files\cars.json");
            string json = sr.ReadToEnd();
            cars = JsonConvert.DeserializeObject<List<car>>(json);
            sr.Close();
        }

        private void writeCars()
        {
            StreamWriter sw = new StreamWriter(@"files\cars.json");
            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            sw.WriteLine(json);
            sw.Close();
        }

        private List<user> loadUsers()
        {
            StreamReader sr = new StreamReader("ListaAuto.json");
            string json = sr.ReadToEnd();
            var users = JsonConvert.DeserializeObject<List<user>>(json);
            sr.Close();
            return users;
        }


        //public methods
        public seller(){
            cars = new List<car>();
            username = "";
            password = "";
            lvlAuth = 0;
            genId();
        }

        public bool login(string username, string password)
        {

            List<user> users = loadUsers() ;
            foreach (user user in users){
                if(user.username == username && user.password == password)
                {
                    loadCars();
                    this.username = username;
                    this.password = password;
                    this.lvlAuth = user.lvlAuth;
                    this.id = user.id;
                    return true;
                }
            }
            return false;
        }

        public List<car> search<t>(int type, t key)
        {
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
                    break;

            }
            
            List<car> found = new List<car>();
            foreach(car a in cars)
            {

            }

            return found;
        }

        public car search(int id)
        {
            car a = new car();
            return a;
        }
    }
}
