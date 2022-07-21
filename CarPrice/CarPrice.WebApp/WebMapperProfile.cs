using AutoMapper;
using CarPrice.Domain.Models;
using CarPrice.WebApp.Models.Search;

namespace CarPrice.WebApp
{
    public class WebMapperProfile : Profile
    {
        public WebMapperProfile()
        {
            CreateMap<CarPrices, PriceVariationChartDto>()
                .ForMember(d => d.MonthYear,
                    m => m.MapFrom(s => s.ReferenceMonth));

            CreateMap<CarPrices, SearchPriceGetViewModel>()
                .ForMember(d => d.CurrentPrice,
                    m => m.MapFrom(s => string.Format("{0:C}", s.Price)));
        }
    }
}
