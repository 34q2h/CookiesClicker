using CookiesClicker.Settings;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace CookiesClicker.Presentation
{
    public class LoadingView : UIView, ILoadingView, IUIView
    {
        [Inject]
        AppSettingsScriptableObject appSettings;

        [SerializeField]
        RectTransform loader;

        Tween tween;

        void IUIView.Show()
        {
            gameObject.SetActive(true);

            tween = loader
                .DORotate(
                    appSettings.loaderRotation,
                    appSettings.loaderTweenTime,
                    RotateMode.Fast)
                .SetLoops(-1, LoopType.Incremental);
        }

        void IUIView.Hide()
        {
            tween.Kill();
            gameObject.SetActive(false);
        }
    }
}