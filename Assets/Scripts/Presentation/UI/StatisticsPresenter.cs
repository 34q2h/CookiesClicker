using CookiesClicker.DTO;
using CookiesClicker.Signals;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

namespace CookiesClicker.Presentation
{
    public class StatisticsPresenter : UIPresenter, IStatisticsPresenter
    {
        [Inject]
        SignalBus bus;

        [Inject]
        LeaderItemView.Pool pool;

        [Inject]
        IStatisticsView view;

        public override IUIView View => (IUIView)view;

        List<LeaderItemView> leadersViews = new();

        public void ShowLeaders(LeadrsDTO value, int gameScore)
        {
            try
            {
                var data = value.Leadrs.ToList();
                var userResult = new KeyValuePair<string, int>("You", gameScore);
                data.Add(userResult);

                var sorted = 
                    (from pair in data
                     orderby pair.Value ascending
                     select pair)
                     .Reverse()
                     .ToList();

                sorted.ForEach(x =>
                {
                    var item = pool.Spawn();
                    item.transform.SetParent(view.ContentRoot, false);
                    var isUser = x.Equals(userResult);
                    item.SetValue($"{x.Key}: {x.Value}", isUser);
                    leadersViews.Add(item);
                });
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }
        }

        public override IDisposable Subscribe()
        {
            base.Subscribe();

            view
                .BackBtn
                .OnClickAsObservable()
                .Subscribe(_ => bus.Fire(new PopAppStateSignal()))
                .AddTo(disposables);

            return this;
        }

        protected override void UnSubscribe()
        {
            leadersViews.ForEach(x => pool.Despawn(x));
            leadersViews.Clear();

            View.Hide();
            disposables.Clear();
        }
    }
}
