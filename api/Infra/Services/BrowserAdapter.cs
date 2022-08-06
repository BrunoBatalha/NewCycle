using api.Interfaces.Services;
using PuppeteerSharp;

namespace api.Infra.Services
{
    public class BrowserAdapter : IBrowserAdapter
    {
        private Browser _browser;
        private Page _currentPage;

        public BrowserAdapter()
        {
        }

        public async Task ConfigureBrowser()
        {
            using var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision);
            _browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                DefaultViewport = null,
                Args = new string[]{
                    "--start-maximized"
                }
            });
        }

        public async Task CloseBrowser()
        {
            await _browser.CloseAsync();
            await _currentPage.DisposeAsync();
            await _browser.DisposeAsync();
        }

        public async Task GoToAsync(string url)
        {
            _currentPage = await _browser.NewPageAsync();
            await _currentPage.GoToAsync(url);
        }

        public async Task TypeAsync(string selector, string text)
        {
            await WaitForSelectorAsync(selector);
            await _currentPage.TypeAsync(selector, text);
        }

        private async Task WaitForSelectorAsync(string selector)
        {
            await _currentPage.WaitForSelectorAsync(selector);
        }

        public async Task ClickAsync(string selector)
        {
            await WaitForSelectorAsync(selector);
            await _currentPage.ClickAsync(selector);
        }

        public async Task PressKey(string key)
        {
            await _currentPage.Keyboard.PressAsync(key);
        }

        public async Task ExecuteJavascript(string script)
        {
            await _currentPage.EvaluateExpressionAsync(script);
        }

        public async Task<ElementBrowserAdapter[]> GetElements(string selector)
        {
            ElementHandle[] elementsHandle = await _currentPage.QuerySelectorAllAsync(selector);
            return elementsHandle.Select(e =>
            {
                return e != null ? new ElementBrowserAdapter(e) : null;
            }).ToArray();
        }

        public async Task WaitForTimeout(int milliseconds)
        {
            await _currentPage.WaitForTimeoutAsync(milliseconds);
        }

        public async Task WaitForNetworkIdleAsync()
        {
            await _currentPage.WaitForNetworkIdleAsync();
        }

        public async Task SaveScreenshotAsync()
        {
            await _currentPage.ScreenshotAsync("page.jpg");
        }
    }
}