using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class UbigeoRepository : IUbigeoRepository
    {
        private readonly Context _context;

        public UbigeoRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<UbigeoResponse> GetAll()
        {
            return _context.Ubigeos
                .Select(x => new UbigeoResponse
                {
                    UbigeoCode = x.UbigeoCode,
                    ProvinceCode = x.ProvinceCode,
                    RegionCode = x.RegionCode,
                    UbigeoDescription = x.UbigeoDescription
                })
                .ToList();
        }

        public IEnumerable<UbigeoResponse> GetByProvinceCode(string provinceCode)
        {
            return _context.Ubigeos
                .Where(x => x.ProvinceCode == provinceCode)
                .Select(x => new UbigeoResponse
                {
                    UbigeoCode = x.UbigeoCode,
                    ProvinceCode = x.ProvinceCode,
                    RegionCode = x.RegionCode,
                    UbigeoDescription = x.UbigeoDescription
                })
                .ToList();
        }

        public IEnumerable<UbigeoResponse> GetByRegionCode(string regionCode)
        {
            return _context.Ubigeos
                .Where(x => x.RegionCode == regionCode)
                .Select(x => new UbigeoResponse
                {
                    UbigeoCode = x.UbigeoCode,
                    ProvinceCode = x.ProvinceCode,
                    RegionCode = x.RegionCode,
                    UbigeoDescription = x.UbigeoDescription
                })
                .ToList();
        }
    }
}
