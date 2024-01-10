using CookiesClicker.Infrastructure;
using CookiesClicker.Presentation;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using UniRx;
using Zenject;

namespace CookiesClicker.UseCase
{
    public class StatisticsUseCase : IStatisticsUseCase
    {
        [Inject]
        IStatisticsPresenter presenter;

        [Inject]
        IStatisticsRepository statistics;

        CompositeDisposable disposables = new();

        CancellationTokenSource ctx = new();

        void IUseCase.Begin(params object[] args)
        {
            presenter
                .Subscribe()
                .AddTo(disposables);

            new Task(async () =>
                {
                    var leaders = await statistics.PullLeaders();
                    presenter.ShowLeaders(leaders, (int)args[0]);
                },
                ctx.Token)
               .Start(TaskScheduler.FromCurrentSynchronizationContext());
        }

        void IUseCase.End()
        {
            ctx.Cancel();
            disposables.Dispose();
        }
    }
}
