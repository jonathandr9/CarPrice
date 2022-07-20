using AutoMapper;
using BrasilApiAdapter.Clients;
using CarPrice.Domain.Models;

namespace BrasilApiAdapter
{
    public class BrasilApiProfile : Profile
    {
        public BrasilApiProfile()
        {
            CreateMap<SearchPriceGetResult, CarPrices>()
                .ForMember(o => o.price, d => d.MapFrom(src => src.valor))
                .ForMember(o => o.brand, d => d.MapFrom(src => src.marca))
                .ForMember(o => o.model, d => d.MapFrom(src => src.modelo))
                .ForMember(o => o.modelYear, d => d.MapFrom(src => src.anoModelo))
                .ForMember(o => o.fuel, d => d.MapFrom(src => src.combustivel))
                .ForMember(o => o.codigoFipe, d => d.MapFrom(src => src.codigoFipe))
                .ForMember(o => o.referenceMonth, d => d.MapFrom(src => src.mesReferencia))
                .ForMember(o => o.vehicleType, d => d.MapFrom(src => src.tipoVeiculo))
                .ForMember(o => o.acronymFuel, d => d.MapFrom(src => src.siglaCombustivel))
                .ForMember(o => o.consultationDate, d => d.MapFrom(src => src.dataConsulta));

        }
    }
}
