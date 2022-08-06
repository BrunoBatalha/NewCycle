using api.Domain.Entities;
using api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api.Infra.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationContext _applicationContext;

        public PostRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<PostModel> Create(PostModel post)
        {
            await _applicationContext.Posts.AddAsync(post);
            await _applicationContext.SaveChangesAsync();

            return post;
        }

        public async Task<PostModel[]> CreateMany(PostModel[] posts)
        {
            await _applicationContext.Posts.AddRangeAsync(posts);
            await _applicationContext.SaveChangesAsync();

            return posts;
        }

        public async Task<PostModel> GetRandom()
        {
            int totalRows = _applicationContext.Posts.Count();
            int skip = new Random().Next(0, totalRows);

            return await _applicationContext.Posts.OrderBy(p => p.Id).Skip(skip).Take(1).FirstOrDefaultAsync();
        }

        public async Task<PostModel> GetByContent(string content)
        {
            return await _applicationContext.Posts.FirstOrDefaultAsync(p => p.Content == content);
        }
    }
}