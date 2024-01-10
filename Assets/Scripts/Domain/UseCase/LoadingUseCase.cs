using CookiesClicker.Presentation;
using CookiesClicker.Signals;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using UniRx;
using Zenject;

namespace CookiesClicker.UseCase
{
    public class LoadingUseCase : ILoadingUseCase
    {
        const int WAITING = 2000;

        [Inject]
        SignalBus bus;

        [Inject]
        ILoadingPresenter presenter;

        CompositeDisposable disposables = new();

        CancellationTokenSource ctx = new();

        void IUseCase.Begin(params object[] args)
        {
            presenter
                .Subscribe()
                .AddTo(disposables);

            new Task(async () =>
            {
                await Task.Delay(WAITING);
                bus.Fire(new PushAppStateSignal(typeof(IGameUseCase)));

            }, ctx.Token)
                .Start(TaskScheduler.FromCurrentSynchronizationContext());
        }

        void IUseCase.End()
        {
            ctx.Cancel();
            disposables.Dispose();
        }
    }
}
