using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.Services
{
    public class CountryService
    {
        private HttpClient client;
        private readonly string apiPath = @"https://restcountries.com/v3.1/";
        public CountryService()
        {
            client = new HttpClient();
        }
        //Получить все страны из API
        public async Task<List<Country>> GetAllCountriesAsync(string path = "all?")
        {
            var countryList = new List<Country>();
            var response = await client.GetAsync($"{apiPath}{path}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                countryList = JsonConvert.DeserializeObject<List<Country>>(jsonString);
            }

            return countryList.OrderBy(x => x.Name.Common).ToList();
        }
        //Получить одну страну по полному имени
        public async Task<Country> GetCountryByFullNameAsync(string fullName)
        {
            var country = new Country();
            var response = await client.GetAsync($"{apiPath}name/{fullName}?fullText=true&fields=name,capital,region,languages");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                //Так как полученный десериализованный объект является списком из одного элемента,
                //берём только первый элемент
                country = JsonConvert.DeserializeObject<List<Country>>(jsonString)[0];
            }

            return country;
        }
        //Получить список стран по имени (совпадения по имени)
        public async Task<List<Country>> GetCountriesByNameAsync(string name)
        {
            var countryList = new List<Country>();
            var response = await client.GetAsync($"{apiPath}name/{name}?fields=name,capital,region,languages");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                countryList = JsonConvert.DeserializeObject<List<Country>>(jsonString);
            }

            return countryList.OrderBy(x => x.Name.Common).ToList();
        }
    }
}
