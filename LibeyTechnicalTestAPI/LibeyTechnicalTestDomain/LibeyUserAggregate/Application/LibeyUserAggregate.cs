using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly ILibeyUserRepository _repository;
        public LibeyUserAggregate(ILibeyUserRepository repository)
        {
            _repository = repository;
        }
        public void Create(UserUpdateorCreateCommand command)
        {
            var user = new LibeyUser(
            command.DocumentNumber,
            command.DocumentTypeId,
            command.Name,
            command.FathersLastName,
            command.MothersLastName,
            command.Address,
            command.UbigeoCode,
            command.Phone,
            command.Email,
            command.Password);

            _repository.Create(user);
        }
        public LibeyUserResponse FindResponse(string documentNumber)
        {
            return _repository.FindResponse(documentNumber);
        }

        public void Update(UserUpdateorCreateCommand command)
        {
            var existingUser = _repository.FindResponse(command.DocumentNumber);
            if (existingUser == null) throw new Exception("User not found");

            var user = new LibeyUser(
                command.DocumentNumber,
                command.DocumentTypeId,
                command.Name,
                command.FathersLastName,
                command.MothersLastName,
                command.Address,
                command.UbigeoCode,
                command.Phone,
                command.Email,
                command.Password);

            _repository.Update(user);
        }

        public void Delete(string documentNumber)
        {
            _repository.Delete(documentNumber);
        }

        public IEnumerable<LibeyUserResponse> GetAll()
        {
            return _repository.GetAll();
        }
    }
}