using AutoMapper;
using CarPrice.Domain.Services;
using CarPrice.WebApp.Models;
using CarPrice.WebApp.Models.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarPrice.WebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<SearchController> _logger;
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;

        public SearchController(ILogger<SearchController> logger,
            ISearchService searchService,
            IMapper mapper)
        {
            _logger = logger;
            _searchService = searchService;
            _mapper = mapper;
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
                var prices = await _searchService.SearchPricesByFipeCode(fipeCode, year);
                var photo = await _searchService.SearchPhotoByFipeCode(fipeCode, year);


                var chartData = _mapper.Map<SearchPriceGetViewModel>(prices.LastOrDefault());
                chartData.PriceVariationChart = _mapper.Map<IEnumerable<PriceVariationChartDto>>(prices);
                chartData.AveragePrice = string.Format("{0:C}", prices.Average(x => x.Price));
                chartData.Photo = photo != null ? photo.PhotoBase64 : "";


                return new JsonResult(new { type = "success", data = chartData });
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
