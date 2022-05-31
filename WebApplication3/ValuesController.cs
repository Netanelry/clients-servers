using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace WebApplication3
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// Data Members
        /// </summary>
        private Dal _dal;
        private Dal2 _dal2;

        /// <summary>
        /// Ctor
        /// </summary>
        public ValuesController(Dal dal, Dal2 dal2)
        {
            _dal = dal;
            _dal2 = dal2;

        }

        /// <summary>
        /// controlers
        /// </summary>
        [Route("search")]
        [HttpGet]
        public IActionResult Search(string term)
        {
            var results = _dal.Search(term);
            return Ok(results);
        }

        [Route("id")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _dal.SearchID(id);
            return result == null ? NotFound("החיפוש שלך לא הניב תוצאות") : Ok(result);

        }

        [Route("searchRange")]
        [HttpGet]
        public IActionResult SearchPriceRange(int minRange, double maxRange)
        {
            var results = _dal.SearchRange(minRange, maxRange);
            return Ok(results);
        }

        [Route("searchCompleted")]
        [HttpGet]
        public IActionResult GetCompleted(bool isComplete)
        {
            var results = _dal.SearchCompleted(isComplete);
            return Ok(results);

        }

        [Route("searchAgeRange")]
        [HttpGet]
        public IActionResult SearchAgeRange(int minRange, double maxRange)
        {
            var results = _dal.SearchAgeRange(minRange, maxRange);
            return Ok(results);
        }

        [Route("kongFOO")]
        [HttpGet]
        public IActionResult giveMeFoo()
        {
            return Ok(_dal2.Foo());
        }
    }
}

#region Bla Bla

/* search
           List<user> results = new List<user>();
           foreach (user user in Dal.users)
           {
               if ((user.title.ToLower().Contains(term.ToLower()) || (user.title.ToLower().Contains(term.ToLower()))))
               {
                   results.Add(user);
               }
           }
*/

/* id
  user result = null;
            foreach (user user in Dal.users)
            {
                if (user.id == id)
                {
                    return Ok(user);
                }
            }
            return NotFound("החיפוש שלך לא הניב תוצאות");
*/

/* range
List<user> results = new List<user>();
            foreach (user user in Dal.users)
            {
                if ((user.id >= minRange) && (user.id <= maxRange))
                {
                    results.Add(user);
                }
            }
            return Ok(results);
*/



#endregion
