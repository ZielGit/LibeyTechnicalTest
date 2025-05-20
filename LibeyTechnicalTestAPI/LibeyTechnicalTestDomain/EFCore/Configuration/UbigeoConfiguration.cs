using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.EFCore.Configuration
{
    public class UbigeoConfiguration : IEntityTypeConfiguration<Ubigeo>
    {
        public void Configure(EntityTypeBuilder<Ubigeo> builder)
        {
            builder.ToTable("Ubigeo").HasKey(x => x.UbigeoCode);
            builder.Property(x => x.UbigeoCode).HasColumnType("char(6)").IsRequired();
            builder.Property(x => x.ProvinceCode).HasColumnType("char(4)").IsRequired();
            builder.Property(x => x.RegionCode).HasColumnType("char(2)").IsRequired();
            builder.Property(x => x.UbigeoDescription).HasColumnType("varchar(200)").IsRequired();
        }
    }
}
