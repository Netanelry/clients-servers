using Newtonsoft.Json;
using System.Text.Json;

namespace WebApplication3
{
    public class Dal
    {
        //טעינה

        //הנגשה
        public List<user> users { get; set; }

        // Singleton

        private static Dal dal;

        public static Dal GetInstance()
        {
            if (dal == null) dal = new Dal();
            return dal;
        }


        private Dal()
        {
            //ctor, data members, 

            HttpClient client = new HttpClient();
            var response = client.GetAsync("http://jsonplaceholder.typicode.com/todos").Result;

            string responseBody = response.Content.ReadAsStringAsync().Result;

            users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<user>>(responseBody);

        }
    }

    public class user
    {

        public user()
        {

        }

        public int userId {get; set;}
        public string title { get; set; }
        public int id { get; set; }
        public bool completed { get; set; }

    }
}
