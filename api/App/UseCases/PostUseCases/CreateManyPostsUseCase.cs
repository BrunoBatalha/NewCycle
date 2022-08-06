using api.App.Dtos;
using api.Domain.Entities;
using api.Interfaces.Repositories;
using api.Interfaces.Services;
using api.Interfaces.UseCases;

namespace api.App.UseCases.PostUseCases
{
    public class CreateManyPostsUseCase : ICreateManyPostsUseCase
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostBrowser _postRobot;
        private readonly IConfiguration _configuration;

        public CreateManyPostsUseCase(IPostRepository postRepository, IPostBrowser postRobot, IConfiguration configuration)
        {
            _postRepository = postRepository;
            _postRobot = postRobot;
            _configuration = configuration;
        }

        public async Task<PostModel[]> Execute()
        {
            _postRobot.Username = _configuration.GetValue<string>("Browser:Linkedin:Username");
            _postRobot.Password = _configuration.GetValue<string>("Browser:Linkedin:Password");

            PostDto[] post = await _postRobot.GetPosts();

            return await _postRepository.CreateMany(post.Select(p => new PostModel
            {
                Id = Guid.NewGuid(),
                Content = p.Content,
                Url = "-",
                UserName = p.UserName,
                ReactionsQuantity = Convert.ToInt32(p.ReactionsQuantity.Replace(",", "")),
                CommentsQuantity = Convert.ToInt32(p.CommentsQuantity.Replace(",", "")),
            }).ToArray());
        }
    }
}