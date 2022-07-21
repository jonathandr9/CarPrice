using AutoMapper;
using BrasilApiAdapter.Clients;
using CarPrice.Domain.Models;
using System;

namespace BrasilApiAdapter
{
    public class BrasilApiProfile : Profile
    {
        public BrasilApiProfile()
        {
            CreateMap<SearchPriceGetResult, CarPrices>()
                .ForMember(o => o.Price, 
                           d => d.MapFrom(src => 
                                    Convert.ToDecimal(src.valor.Replace("R$ ", "").Replace(".",""))))
                .ForMember(o => o.Brand, d => d.MapFrom(src => src.marca))
                .ForMember(o => o.Model, d => d.MapFrom(src => src.modelo))
                .ForMember(o => o.ModelYear, d => d.MapFrom(src => src.anoModelo))
                .ForMember(o => o.Fuel, d => d.MapFrom(src => src.combustivel))
                .ForMember(o => o.CodigoFipe, d => d.MapFrom(src => src.codigoFipe))
                .ForMember(o => o.ReferenceMonth, d => d.MapFrom(src => src.mesReferencia))
                .ForMember(o => o.VehicleType, d => d.MapFrom(src => src.tipoVeiculo))
                .ForMember(o => o.AcronymFuel, d => d.MapFrom(src => src.siglaCombustivel))
                .ForMember(o => o.ConsultationDate, d => d.MapFrom(src => src.dataConsulta));

        }
    }
}
