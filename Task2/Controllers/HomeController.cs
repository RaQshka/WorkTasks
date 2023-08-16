using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Task2.Services;

namespace Task2.Controllers
{
    public class HomeController : Controller
    {
        private readonly CountryService countryService;
        public HomeController(CountryService service)
        {
            countryService = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string nameOfCountry)
        {
            if (string.IsNullOrEmpty(nameOfCountry))
            {
                return View(await countryService.GetAllCountriesAsync());
            }
            var list = await countryService.GetCountriesByNameAsync(nameOfCountry);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string nameOfCountry)
        {
            var country = await countryService.GetCountryByFullNameAsync(nameOfCountry);
            return View(country);
        }
    }
}
