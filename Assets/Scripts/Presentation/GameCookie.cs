using CookiesClicker.Settings;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace CookiesClicker.Presentation
{
    public class GameCookie : MonoBehaviour, IGameCookie
    {
        [Inject]
        AppSettingsScriptableObject appSettings;

        Transform targetTransform;

        private void Awake() =>
            targetTransform = transform;

        void IGameCookie.React() =>
            targetTransform
                .DOScale(
                    appSettings.cookieScaleSize,
                    appSettings.cookieScaleTime)
                .OnComplete(() =>
                    targetTransform
                    .DOScale(1f, appSettings.cookieScaleTime));
    }
}