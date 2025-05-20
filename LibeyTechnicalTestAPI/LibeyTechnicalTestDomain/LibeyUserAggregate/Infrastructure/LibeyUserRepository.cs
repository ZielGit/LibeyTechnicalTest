using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        public LibeyUserRepository(Context context)
        {
            _context = context;
        }
        public void Create(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Add(libeyUser);
            _context.SaveChanges();
        }
        public LibeyUserResponse FindResponse(string documentNumber)
        {
            var q = from libeyUser in _context.LibeyUsers.Where(x => x.DocumentNumber.Equals(documentNumber))
                    select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        Active = libeyUser.Active,
                        Address = libeyUser.Address,
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        Email = libeyUser.Email,
                        FathersLastName = libeyUser.FathersLastName,
                        MothersLastName = libeyUser.MothersLastName,
                        Name = libeyUser.Name,
                        Password = libeyUser.Password,
                        Phone = libeyUser.Phone
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new LibeyUserResponse();
        }

        public void Update(LibeyUser user)
        {
            _context.LibeyUsers.Update(user);
            _context.SaveChanges();
        }

        public void Delete(string documentNumber)
        {
            var user = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber == documentNumber);
            if (user != null)
            {
                user.Deactivate(); // Soft delete
                _context.SaveChanges();
            }
        }

        public IEnumerable<LibeyUserResponse> GetAll()
        {
            return _context.LibeyUsers
                .Where(x => x.Active)
                .Select(x => new LibeyUserResponse
                {
                    DocumentNumber = x.DocumentNumber,
                    DocumentTypeId = x.DocumentTypeId,
                    Name = x.Name,
                    FathersLastName = x.FathersLastName,
                    MothersLastName = x.MothersLastName,
                    Address = x.Address,
                    UbigeoCode = x.UbigeoCode,
                    Phone = x.Phone,
                    Email = x.Email,
                    Password = x.Password,
                    Active = x.Active
                })
                .ToList();
        }
    }
}