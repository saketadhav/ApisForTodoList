using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ng5demowebapi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GoalsController : ApiController
    {
        private static List<string> goalList = new List<string>();

        [HttpGet]
        public List<string> Get()
        {
            return goalList;
        }

        [HttpPost]
        public IHttpActionResult Post(Goal goal)
        {
            goalList.Add(goal.GoalText);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(string goaltext)
        {
            goalList.Remove(goaltext);
            return Ok();
        }

        public class Goal
        {
            public int Id { get; set; }
            public string GoalText { get; set; }
        }
    }
}
