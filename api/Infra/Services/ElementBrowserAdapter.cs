using PuppeteerSharp;

namespace api.Infra.Services
{
    public class ElementBrowserAdapter
    {
        private ElementHandle _elementHandle;

        public ElementBrowserAdapter(ElementHandle elementHandle)
        {
            _elementHandle = elementHandle;
        }

        public async Task<string> GetProperty(string property)
        {
            JSHandle jsHandle = await _elementHandle.GetPropertyAsync(property);
            return await jsHandle.JsonValueAsync() as string;
        }

        public async Task<ElementBrowserAdapter> GetElement(string selector)
        {
            ElementHandle elementHandle = await _elementHandle.QuerySelectorAsync(selector);

            return elementHandle != null ? new ElementBrowserAdapter(elementHandle) : null;
        }
    }

}