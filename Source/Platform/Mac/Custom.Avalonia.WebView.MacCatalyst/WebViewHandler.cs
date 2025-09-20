﻿namespace Avalonia.WebView.MacCatalyst;

public class WebViewHandler : ViewHandler<IVirtualWebView, MacCatalystWebViewCore>
{
    public WebViewHandler(IVirtualWebView virtualWebView, IVirtualWebViewControlCallBack callback, IVirtualBlazorWebViewProvider? provider, WebViewCreationProperties webViewCreationProperties)
    {
        var webView = new MacCatalystWebViewCore(this, callback, provider, webViewCreationProperties);
        _webViewCore = webView;
        PlatformWebView = webView;
        VirtualViewContext = virtualWebView;
        PlatformViewContext = webView;
    }
    readonly MacCatalystWebViewCore _webViewCore;

    protected override HandleRef CreatePlatformHandler(IPlatformHandle parent, Func<IPlatformHandle> createFromSystem)
    {
        //var handler = createFromSystem.Invoke();
        return new HandleRef(this, _webViewCore.NativeHandler);
    }

    protected override void Disposing()
    {
        PlatformWebView.Dispose();
        PlatformWebView = default!;
        VirtualViewContext = default!;
    }
}