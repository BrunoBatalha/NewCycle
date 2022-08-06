using api.Domain.Entities;
using api.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/v1/post")]
public class PostController : ControllerBase
{
   
    private readonly ILogger<PostController> _logger;
    private readonly ICreateManyPostsUseCase _createManyPostsUseCase;
    private readonly IGetRandomPostUseCase _getRandomPostUseCase;

    public PostController(ILogger<PostController> logger, 
        IGetRandomPostUseCase getRandomPostUseCase,
        ICreateManyPostsUseCase createManyPostsUseCase)
    {
        _logger = logger;
        _getRandomPostUseCase = getRandomPostUseCase;
        _createManyPostsUseCase = createManyPostsUseCase;
    }

    [HttpGet]
    [Route("random")]
    public async Task<PostModel> GetRandomPost()
    {
       return await _getRandomPostUseCase.Execute();
    }

    [HttpPost]
    [Route("generate")]
    public async Task<PostModel[]> generatePosts()
    {
       return await _createManyPostsUseCase.Execute();
    }
}
