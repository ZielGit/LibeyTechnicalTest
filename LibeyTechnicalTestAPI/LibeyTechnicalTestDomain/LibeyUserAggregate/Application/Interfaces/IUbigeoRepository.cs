using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface IUbigeoRepository
    {
        IEnumerable<UbigeoResponse> GetAll();
        IEnumerable<UbigeoResponse> GetByProvinceCode(string provinceCode);
        IEnumerable<UbigeoResponse> GetByRegionCode(string regionCode);
    }
}
