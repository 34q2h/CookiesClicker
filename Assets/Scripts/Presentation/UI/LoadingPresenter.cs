using System;
using Zenject;

namespace CookiesClicker.Presentation
{
    public class LoadingPresenter : UIPresenter, ILoadingPresenter
    {
        [Inject]
        ILoadingView view;

        public override IUIView View => (IUIView)view;

        public override IDisposable Subscribe()
        {
            base.Subscribe();
            return this;
        }
    }
}