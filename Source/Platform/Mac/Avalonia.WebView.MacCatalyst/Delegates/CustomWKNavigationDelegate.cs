using ObjCRuntime;
using System.ComponentModel;

namespace Avalonia.WebView.MacCatalyst.Delegates
{
    [Protocol]
    [Register("CustomWKNavigationDelegate", false)]
    [Model]
    public class CustomWKNavigationDelegate : WKNavigationDelegate
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Export("init")]
        public CustomWKNavigationDelegate() { }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected CustomWKNavigationDelegate(NSObjectFlag t) : base(t) { }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal CustomWKNavigationDelegate(NativeHandle handle) : base(handle) { }

        public override void DidFinishNavigation(WKWebView webView, WKNavigation navigation) { }

        public override void DecidePolicy(WKWebView webView, WKNavigationAction navigationAction, Action<WKNavigationActionPolicy> decisionHandler)
        {
            decisionHandler(WKNavigationActionPolicy.Allow);
        }
    }

    [Protocol]
    [Register("CustomWKUIDelegate", false)]
    [Model]
    public class CustomWKUIDelegate : WKUIDelegate
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Export("init")]
        public CustomWKUIDelegate() { }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected CustomWKUIDelegate(NSObjectFlag t) : base(t) { }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal CustomWKUIDelegate(NativeHandle handle) : base(handle) { }

        public override void RunJavaScriptAlertPanel(WKWebView webView, string message, WKFrameInfo frame, Action completionHandler)
        {
            completionHandler?.Invoke();
        }
    }

    [Register("CustomWKPreferences")]
    public class CustomWKPreferences : WKPreferences
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Export("init")]
        public CustomWKPreferences() { }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected CustomWKPreferences(NSObjectFlag t) : base(t) { }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal CustomWKPreferences(NativeHandle handle) : base(handle) { }

        public static CustomWKPreferences CreateDefaults()
        {
            var prefs = new CustomWKPreferences
            {
                JavaScriptEnabled = true
            };

#if __MACCATALYST__ || __MACOS__
            if (prefs.RespondsToSelector(new Selector("setTabFocusesLinks:")))
                prefs.TabFocusesLinks = true;
#endif
            return prefs;
        }
    }

    [Register("CustomWKUserContentController")]
    public class CustomWKUserContentController : WKUserContentController
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Export("init")]
        public CustomWKUserContentController() { }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected CustomWKUserContentController(NSObjectFlag t) : base(t) { }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal CustomWKUserContentController(NativeHandle handle) : base(handle) { }
    }

    [Register("CustomWKNavigationAction")]
    public class CustomWKNavigationAction : WKNavigationAction
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected CustomWKNavigationAction(NSObjectFlag t) : base(t) { }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal CustomWKNavigationAction(NativeHandle handle) : base(handle) { }
    }

    [Register("CustomWKNavigation")]
    public class CustomWKNavigation : WKNavigation
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected CustomWKNavigation(NSObjectFlag t) : base(t) { }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal CustomWKNavigation(NativeHandle handle) : base(handle) { }
    }
}
