namespace WebViewCore.Events;

public class WebViewUrlLoadedEventArg : EventArgs
{
    public bool IsSuccess { get; set; }
    public object? RawArgs { get; set; }
}
