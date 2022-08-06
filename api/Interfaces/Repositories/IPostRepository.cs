using api.Domain.Entities;

namespace api.Interfaces.Repositories
{
    public interface IPostRepository
    {
        Task<PostModel> Create(PostModel post);
        Task<PostModel> GetRandom();
        Task<PostModel[]> CreateMany(PostModel[] posts);
        Task<PostModel> GetByContent(string content);
    }
}