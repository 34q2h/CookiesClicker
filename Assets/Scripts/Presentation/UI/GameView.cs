using CookiesClicker.Settings;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CookiesClicker.Presentation
{
    public class GameView : UIView, IGameView
    {
        [Inject]
        AppSettingsScriptableObject appSettings;

        [SerializeField]
        TextMeshProUGUI scoreText;

        [SerializeField]
        Button statisticsBtn;

        [SerializeField]
        Button storeBtn;

        Button IGameView.StatisticsBtn => statisticsBtn;

        Button IGameView.StoreBtn => storeBtn;

        TextMeshProUGUI IGameView.ScoreText => scoreText;


        [Inject]
        public void Construct()
        {
            var scoreTransform =
                scoreText.GetComponent<Transform>();

            this
                .ObserveEveryValueChanged(x => x.scoreText.text)
                .Subscribe(x =>
                {
                    scoreTransform
                        .DOScale(appSettings.scoreScaleSize, appSettings.scoreScaleTime)
                        .OnComplete(() => scoreTransform.DOScale(1f, appSettings.scoreScaleTime));
                });
        }
    }
}
