using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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

        //private methods
        private bool checkAuth(int i)
        {
            if(lvlAuth >= i)
            {
                return true;
            }
            return false;
        }

        private bool loadCars()
        {
            return false;
        }

        private int assignID()
        {
            string text = File.ReadAllText(@"files\config.txt");
            try{
                int lastid = int.Parse(text);
                return lastid++;
            }catch(FormatException){
                Console.WriteLine("errore nella lettura di files/confi.txt");
                return -1;
            }
        }

        //public methods
        public seller(){
            cars = new List<car>();
            username = "";
            password = "";
            lvlAuth = 0;
            id = -1;
        }
        public bool login(string username, string password)
        {
            List<user> users = new List<user>();
            foreach (user user in users){
                if(user.username == username && user.password == password)
                {
                    this.username = username;
                    this.password = password;
                    return true;
                }
            }
            return false;
        }
    }
}
