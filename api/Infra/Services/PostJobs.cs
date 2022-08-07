using api.Interfaces.UseCases;
using Quartz;

namespace api.Infra.Services
{
    public class PostJobs : IJob
    {
        private readonly ICreateManyPostsUseCase _createManyPostsUseCase;
        public PostJobs(ICreateManyPostsUseCase createManyPostsUseCase)
        {
            _createManyPostsUseCase = createManyPostsUseCase;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _createManyPostsUseCase.Execute();
        }
    }
}