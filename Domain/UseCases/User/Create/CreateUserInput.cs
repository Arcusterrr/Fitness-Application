using MediatR;

namespace Domain.UseCases.User.Create
{
    public class CreateUserInput: IRequest<int>
    {
        public string Username { get; set; }
    }
}