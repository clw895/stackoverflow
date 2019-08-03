using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopilot.Models
{
    public class Action
    {
        [JsonProperty("actions")]
        public List<Verb> verbs;

        public Action(Verb verb)
        {
            if (verbs != null)
            {
                verbs.Add(verb);
            }
            else
            {
                verbs = new List<Verb> { verb };
            }
        }
    }
}
