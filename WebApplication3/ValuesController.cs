using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController()
        { 
        
        }

        [Route("search")]
        [HttpGet]
        public IActionResult Search(string term)
        {
            // lazy loading
            Dal Dal = Dal.GetInstance();
            List<user> results = new List<user>();
            foreach (user user in Dal.users)
            {
                if ((user.title.ToLower().Contains(term.ToLower()) || (user.title.ToLower().Contains(term.ToLower()))))
                {
                    results.Add(user);
                }
            }
            return Ok(results);
        }

        [Route("id")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            Dal Dal = Dal.GetInstance();
            user result = null;
            foreach (user user in Dal.users)
            {
                if (user.id == id)
                {
                    return Ok(user);
                }
            }
            return NotFound("החיפוש שלך לא הניב תוצאות");
        }

        [Route("searchRange")]
        [HttpGet]
        public IActionResult SearchPriceRange(int minRange, double maxRange)
        {
            Dal Dal = Dal.GetInstance();
            List<user> results = new List<user>();
            foreach (user user in Dal.users)
            {
                if ((user.id >= minRange) && (user.id <= maxRange))
                {
                    results.Add(user);
                }
            }
            return Ok(results);
        }

        //עמוד swagger?
    }
}
