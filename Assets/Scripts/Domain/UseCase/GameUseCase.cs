using CookiesClicker.Infrastructure;
using CookiesClicker.Presentation;
using Cysharp.Threading.Tasks;
using UniRx;
using Zenject;

namespace CookiesClicker.UseCase
{
    public class GameUseCase : IGameUseCase
    {
        [Inject]
        IGameCookie cookie;

        [Inject]
        IGamePresenter presenter;

        [Inject]
        IInputController inputController;

        CompositeDisposable disposables = new();

        void IUseCase.Begin(params object[] args)
        {
            presenter
                .Subscribe()
                .AddTo(disposables);

            inputController
                .OnClick
                .Subscribe(x =>
                {
                    cookie.React();
                    presenter.GameScore++;
                })
                .AddTo(disposables);
        }

        void IUseCase.End() =>
            disposables.Dispose();
    }
}
