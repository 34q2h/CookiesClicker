using System;

namespace CookiesClicker.Presentation
{
    public interface IUIPresenter
    {
        IUIView View { get; }
        IDisposable Subscribe();
    }
}