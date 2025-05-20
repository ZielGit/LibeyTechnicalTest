using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly Context _context;

        public DocumentTypeRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<DocumentTypeResponse> GetAll()
        {
            return _context.DocumentTypes
                .Select(x => new DocumentTypeResponse
                {
                    DocumentTypeId = x.DocumentTypeId,
                    DocumentTypeDescription = x.DocumentTypeDescription
                })
                .ToList();
        }
    }
}
