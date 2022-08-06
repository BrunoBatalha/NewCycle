using api.Domain.Entities;
using api.Interfaces.Repositories;
using api.Interfaces.UseCases;

namespace api.App.UseCases.PostUseCases
{
    public class GetRandomPostUseCase : IGetRandomPostUseCase
    {
        private readonly IPostRepository _postRepository;

        public GetRandomPostUseCase(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<PostModel> Execute()
        {
            return await _postRepository.GetRandom();
        }
    }
}