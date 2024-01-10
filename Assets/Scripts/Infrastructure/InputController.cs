using System;
using UniRx;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Zenject;

namespace CookiesClicker.Infrastructure
{
    public class InputController : IInputController, IDisposable
    {
        public ReactiveCommand OnClick { get; private set; } = new();

        readonly CompositeDisposable disposables = new();

        [Inject]
        public void Construct()
        {
            EnhancedTouchSupport.Enable();

            Observable
                .EveryUpdate()
                .Subscribe(_ =>
                {
                    if (Touch.activeTouches.Count != 1)
                        return;

                    if (Touch.activeTouches[0].phase == TouchPhase.Began)
                        OnClick.Execute();
                })
                .AddTo(disposables);
        }

        public void Dispose()
        {
            EnhancedTouchSupport.Disable();
            disposables.Dispose();
        }
    }
}