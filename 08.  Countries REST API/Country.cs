using Newtonsoft.Json;

namespace _08.__Countries_REST_API;
public class Country
{
    [JsonProperty("name")]
    public CountryName Name { get; set; }
    [JsonProperty("region")]
    public string Region { get; set; }
    [JsonProperty("subregion")]
    public string SubRegion { get; set; }
    [JsonProperty("latlng")]
    public IEnumerable<double> Coordinates { get; set; }
    [JsonProperty("area")]
    public double Area { get; set; }
    [JsonProperty("population")]
    public int Population { get; set; }
}
