using api.App.Dtos;
using api.Interfaces.Services;

namespace api.Infra.Services
{
    public class PostBrowser : IPostBrowser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        private IBrowserAdapter _robotAdapter;

        public PostBrowser(IBrowserAdapter robotAdapter)
        {
            _robotAdapter = robotAdapter;
        }

        public async Task<PostDto[]> GetPosts()
        {
            await _robotAdapter.ConfigureBrowser();
            await OpenLinkedin();
            await Login();
            PostDto[] posts = await SearchPosts();
            await _robotAdapter.CloseBrowser();
            return posts;
        }

        private async Task OpenLinkedin()
        {
            await _robotAdapter.GoToAsync("https://www.linkedin.com/uas/login");
        }

        private async Task Login()
        {
            await _robotAdapter.TypeAsync("#username", Username);
            await _robotAdapter.TypeAsync("#password", Password);

            await _robotAdapter.WaitForTimeout(1000);
            await _robotAdapter.ClickAsync("button[type='submit']");
        }

        private async Task<PostDto[]> SearchPosts()
        {
            await _robotAdapter.ClickAsync(".search-global-typeahead__collapsed-search-button");
            await _robotAdapter.WaitForTimeout(1000);
            await _robotAdapter.TypeAsync(".search-global-typeahead__input", "fim ciclo inicio");
            await _robotAdapter.WaitForTimeout(1000);
            await _robotAdapter.PressKey("Enter");
            await _robotAdapter.WaitForTimeout(1000);
            await _robotAdapter.ClickAsync(".search-reusables__filter-list > li:first-of-type > button");

            await _robotAdapter.WaitForNetworkIdleAsync();
            for (int count = 0; count < 1; count++)
            {
                await _robotAdapter.WaitForNetworkIdleAsync();
                await _robotAdapter.ExecuteJavascript("window.scrollTo(0, document.body.scrollHeight)");
            }

            return await GetPostsInformations();
        }

        private async Task<PostDto[]> GetPostsInformations()
        {
            List<PostDto> posts = new();
            ElementBrowserAdapter[] elements = await _robotAdapter.GetElements(".scaffold-finite-scroll__content .occludable-update");
            foreach (var element in elements)
            {
                var post = new PostDto();

                string id = await element.GetProperty("id");
                await _robotAdapter.ExecuteJavascript(@$"
                    window.scroll({{
                        top: document.querySelector('#{id}').offsetTop,  
                        left: 0,
                    }});
                ");

                await _robotAdapter.WaitForTimeout(2000);
                var content = await element.GetElement(".feed-shared-update-v2__description .feed-shared-text > span.break-words span[dir='ltr']");
                if (content != null)
                {
                    post.Content = await content.GetProperty("innerHTML");
                }

                var reactions = await element.GetElement(".social-details-social-counts__reactions-count");
                if (reactions != null)
                {
                    post.ReactionsQuantity = await reactions.GetProperty("innerText");
                }

                var comments = await element.GetElement(".social-details-social-counts__item.social-details-social-counts__comments");
                if (comments != null)
                {
                    string text = await comments.GetProperty("innerText");
                    post.CommentsQuantity = new String(text.Where(Char.IsDigit).ToArray());
                }
                var username = await element.GetElement(".feed-shared-actor__name");
                if (username != null)
                {
                    post.UserName = await username.GetProperty("innerText");
                }

                // TODO: get url
                // await _robotAdapter.ClickAsync(".feed-shared-control-menu");
                // await _robotAdapter.ClickAsync(".artdeco-dropdown__content-inner.option-share-via");

                // post.Url = await _robotAdapter.ExecuteJavascript("window.scrollTo(0, document.body.scrollHeight)");

                posts.Add(post);
            }

            return posts.ToArray();
        }
    }
}