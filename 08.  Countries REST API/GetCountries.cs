using Newtonsoft.Json;

namespace _08.__Countries_REST_API;
public class GetCountries
{
    private const string uri = "https://restcountries.com/";

    public static async Task<IEnumerable<Country>> GetCountriesDataFromService()
    {
        string responseString = "";

        try
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(uri)
            };

            var responseMessage = await httpClient.GetAsync("v3.1/all");
            responseString = await responseMessage.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        return JsonConvert.DeserializeObject<IEnumerable<Country>>(responseString);
    }

    public static void GenerateCountryDataFiles(IEnumerable<Country> countries)
    {
        DirectoryInfo directory = new(@"C:\Countries");

        if (!directory.Exists)
        {
            directory.Create();
        }

        if (countries == null)
        {
            Console.WriteLine($"Can't retrieve data from the {uri}.");
        }
        else
        {
            foreach (var country in countries)
            {
                using (StreamWriter streamWriter = new($@"{directory}\{country.Name.Common}.txt", true))
                {
                    try
                    {
                        streamWriter.WriteLine(
                        $"Region: {country.Region}\n" +
                        $"Subregion: {country.SubRegion}\n" +
                        $"Latng: {country.Coordinates.First()} _ {country.Coordinates.Last()}\n" +
                        $"Area: {country.Area}\n" +
                        $"Population: {country.Population}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            Console.WriteLine($"Files created at: '{directory}'");
        }
    }
}
