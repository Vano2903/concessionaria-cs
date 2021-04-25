using System;
using System.Collections.Generic;
using System.Text;

namespace concessionario
{
    struct user
    {
        public String username;
        public String password;
        public int lvlAuth;
    }
    class seller
    {
        private List<car> cars = new List<car>();
        private String username;
        private String password;

        //private methods
        private bool checkAuth(int i)
        {
            return false;
        }

        private bool loadCars()
        {
            return false;
        }


        //public methods
        public seller(){}
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
