using api.Domain.Entities;

namespace api.Interfaces.UseCases
{
    public interface ICreateManyPostsUseCase
    {
        Task<PostModel[]> Execute();
    }
}