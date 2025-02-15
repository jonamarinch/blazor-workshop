using Microsoft.JSInterop;

namespace BlazingPizza.ComponentsLibrary;

public static class LocalStorage
{
    public static ValueTask<T> GetAsync<T>(IJSRuntime jsRuntime, string key)
    {
        return jsRuntime.InvokeAsync<T>("blazorLocalStorage.get", key);
    }

    public static ValueTask SetAsync(IJSRuntime jsRuntime, string key, object value)
    {
        return jsRuntime.InvokeVoidAsync("blazorLocalStorage.set", key, value);
    }

    public static ValueTask DeleteAsync(IJSRuntime jsRuntime, string key)
    {
        return jsRuntime.InvokeVoidAsync("blazorLocalStorage.delete", key);
    }
}