using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MvcProductCore.Models
{
    public class Feedback
    {
        [Key]
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "emailaddress")]
        public string EmailAddress { get; set; }

        [JsonProperty(PropertyName = "comments")]
        public string Comments { get; set; }
    }
}
