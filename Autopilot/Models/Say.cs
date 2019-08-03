using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autopilot.Models
{
    public class Say : Verb
    {
        [JsonProperty("say")]
        public override string Value { get; set; }

        public Say(string value) => Value = value;
    }
}

