using System.Collections.Generic;
using Newtonsoft.Json;

namespace TrainingProject.Api
{
    public class People
    {
        public string Name { get; set; }
        public string Mass { get; set; }
        [JsonProperty("skin_color")]
        public string SkinColor { get; set; }
        public List<string> Films { get; set; }
        
    }
}