using MongoDB.Driver;
using Newtonsoft.Json;
using System.Text.Json;

namespace WebApplication3
{
    public class Dal
    {
        /// <summary>
        /// data members
        /// </summary>
        private MongoClient _mc;
        private IMongoCollection<user> _MCUsers;

        /// <summary>
        /// ctors
        /// </summary>
        public Dal(MongoClient mc)
        {
            _mc = mc;
            _MCUsers = _mc.GetDatabase("db_users").GetCollection<user>("col_users");

            var data = LoadData();
            ProcessData(data);
            SaveDataToMongo(data);
        }

        /// <summary>
        /// This methods loads list of users from internet endpoint
        /// </summary>
        private List<user> LoadData()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("http://jsonplaceholder.typicode.com/todos").Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;
            var users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<user>>(responseBody);
            return users;
        }

        /// <summary>
        /// this method saves list of users to mongo
        /// </summary>
        private void SaveDataToMongo(List<user> data)
        {
            _MCUsers.Database.DropCollectionAsync("col_users").Wait();
            _MCUsers.InsertManyAsync(data).Wait();
        }

        private void ProcessData(List<user> data)
        {
            Random rnd = new Random();
            foreach (var user in data)
            {
                user.age = rnd.Next(0, 121);
            }
        }

        public List<user> Search(string term)
        {
            return _MCUsers.Find(user => user.title.ToLower().Contains(term.ToLower())).ToList();
        }

        public user SearchID(int id)
        {
            return _MCUsers.Find(user => user.id == id).FirstOrDefault();
        }

        public List<user> SearchRange(int minRange, double maxRange)
        {
            return _MCUsers.Find(user => user.id >= minRange && user.id <= maxRange).ToList();
        }

        public List<user> SearchCompleted(bool isComplete)
        {
            return _MCUsers.Find(user => user.completed == isComplete).ToList();
        }

        public List<user> SearchAgeRange(int minRange, double maxRange)
        {
            return _MCUsers.Find(user => user.age >= minRange && user.age <= maxRange).ToList();
        }

    }

    public class user
    {

        public user()
        {

        }

        public int userId { get; set; }
        public string title { get; set; }
        public int id { get; set; }
        public bool completed { get; set; }
        public int age { get; set; }

    }
}

#region Bla Bla

//public List<user> _users { get; set; }

#endregion
