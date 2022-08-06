using api.App.Dtos;

namespace api.Interfaces.Services
{
    public interface IPostBrowser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public void SetFunctionHasPostInDatabase(Func<PostDto, Task<bool>> hasPostInDatabase);
        public Task<PostDto[]> GetPosts();
    }
}