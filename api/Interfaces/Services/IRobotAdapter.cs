using api.Infra.Services;

namespace api.Interfaces.Services
{
    public interface IBrowserAdapter
    {
        Task ConfigureBrowser();
        Task CloseBrowser();
        Task GoToAsync(string url);
        Task TypeAsync(string selector, string text);
        Task ClickAsync(string selector);
        Task PressKey(string key);
        Task ExecuteJavascript(string script);
        Task<ElementBrowserAdapter[]> GetElements(string selector);
        Task WaitForTimeout(int milliseconds);
        Task WaitForNetworkIdleAsync();
        Task SaveScreenshotAsync();
    }
}