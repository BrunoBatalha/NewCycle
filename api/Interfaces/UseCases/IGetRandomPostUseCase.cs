using api.Domain.Entities;

namespace api.Interfaces.UseCases
{
    public interface IGetRandomPostUseCase
    {
        Task<PostModel> Execute();
    }
}