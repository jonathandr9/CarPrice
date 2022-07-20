using CarPrice.Domain.Services;
using CarPrice.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CarPrice.WebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<SearchController> _logger;
        private readonly ISearchService _searchService;

        public SearchController(ILogger<SearchController> logger,
            ISearchService searchService)
        {
            _logger = logger;
            _searchService = searchService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> SearchByFipeCode(string fipeCode, 
            int year)
        {
            try
            {
                var chartData = await _searchService.SearchPricesByFipeCode(
                    "001004-9",
                    year);

                return new JsonResult(new
                {
                    type = "success",
                    data = chartData
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(new 
                { 
                    type = "error",
                    message = ex.Message 
                });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel 
            { 
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
            });
        }
    }
}
