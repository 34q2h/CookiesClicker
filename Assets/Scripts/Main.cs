using CookiesClicker.Signals;
using CookiesClicker.UseCase;
using UnityEngine;
using Zenject;

namespace CookiesClicker
{
    public class Main : MonoBehaviour
    {
        [Inject]
        SignalBus bus;

        void Start() =>
            bus.Fire(new PushAppStateSignal(typeof(ILoadingUseCase)));
    }
}
