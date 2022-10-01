using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace JuanDavidB.Application
{
    public class TableroProfile : Profile
    {
        public TableroProfile()
        {
            CreateMap<Domain.Tablero, TableroDto>().ReverseMap();
            CreateMap<IQueryable<IEnumerable<Domain.Tablero>>, TableroDto>();
        }
    }
}