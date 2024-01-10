using CookiesClicker.Signals;
using CookiesClicker.UseCase;
using System;
using UniRx;
using Zenject;

namespace CookiesClicker.Presentation
{
    public class GamePresenter : UIPresenter, IGamePresenter
    {
        [Inject]
        SignalBus bus;

        [Inject]
        IGameView view;

        public override IUIView View => (IUIView)view;

        public int GameScore { get; set; }

        public override IDisposable Subscribe()
        {
            base.Subscribe();

            view
                .StatisticsBtn
                .OnClickAsObservable()
                .Subscribe(_ => bus.Fire(new PushAppStateSignal(typeof(IStatisticsUseCase), GameScore)))
                .AddTo(disposables);

            this
               .ObserveEveryValueChanged(x => x.GameScore)
               .Subscribe(x => view.ScoreText.text = x.ToString())
               .AddTo(disposables);

            return this;
        }
    }
}
