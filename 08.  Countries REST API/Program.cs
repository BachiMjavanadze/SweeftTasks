using _08.__Countries_REST_API;

Console.WriteLine("Process started...");
var countries = await GetCountries.GetCountriesDataFromService();
GetCountries.GenerateCountryDataFiles(countries);