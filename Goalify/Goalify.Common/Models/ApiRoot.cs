

using System.Text.Json.Serialization;

namespace Goalify.Common.Models;

    
    public class Data
    {
        public string color { get; set; }
        public string capacity { get; set; }
        public int? capacityGB { get; set; }
        public double? price { get; set; }
        public string generation { get; set; }
        public int? year { get; set; }
        public string CPUmodel { get; set; }
        public string Harddisksize { get; set; }
        public string StrapColour { get; set; }
        public string CaseSize { get; set; }
        public double? Screensize { get; set; }
        public string Description { get; set; }
    }

    public class Root
    {
        public string id { get; set; }

        public string name { get; set; }

        public Data data { get; set; }
    }


    public class PostData
    {
        [JsonPropertyName("year")]
        public int year { get; set; }

        [JsonPropertyName("price")]
        public double price { get; set; }

        [JsonPropertyName("CPU model")]
        public string CPUmodel { get; set; }

        [JsonPropertyName("Hard disk size")]
        public string Harddisksize { get; set; }
    }

    public class PostAgrs
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("data")]
        public PostData data { get; set; }
    }

public class  ServiceResponse
{

    public Data data { get; set; }

}
