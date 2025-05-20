﻿using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.EFCore.Configuration
{
    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.ToTable("DocumentType").HasKey(x => x.DocumentTypeId);
            builder.Property(x => x.DocumentTypeId).HasColumnType("int").IsRequired();
            builder.Property(x => x.DocumentTypeDescription).HasColumnType("varchar(200)").IsRequired();
        }
    }
}
