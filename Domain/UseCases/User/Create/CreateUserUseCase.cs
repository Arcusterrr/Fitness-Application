using System.Threading;
using System.Threading.Tasks;
using Domain.Storage;
using MediatR;

namespace Domain.UseCases.User.Create
{
    public class CreateUserUseCase: IRequestHandler<CreateUserInput, int>
    {
        private readonly IUserStorage _storage;

        public CreateUserUseCase(IUserStorage storage)
        {
            _storage = storage;
        }

        public async Task<int> Handle(CreateUserInput request, CancellationToken cancellationToken)
        {
            var user = new Entities.User(request.Username);

            await _storage.SaveUser(user);
            
            return user.Id;
        }
    }
}