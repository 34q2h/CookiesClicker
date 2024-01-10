using System;
using UniRx;

namespace CookiesClicker.Presentation
{
    public abstract class UIPresenter : IUIPresenter, IDisposable
    {
        public abstract IUIView View { get; }

        protected CompositeDisposable disposables = new();

        public virtual IDisposable Subscribe()
        {
            View.Show();
            return this;
        }

        protected virtual void UnSubscribe()
        {
            View.Hide();
            disposables.Clear();
        }

        public void Dispose() => UnSubscribe();
    }
}