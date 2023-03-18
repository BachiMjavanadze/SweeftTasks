using Newtonsoft.Json;

namespace _08.__Countries_REST_API;
public class CountryName
{
    [JsonProperty("common")]
    public string Common { get; set; }
    [JsonProperty("official")]
    public string Official { get; set; }
}
