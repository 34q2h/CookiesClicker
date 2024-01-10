using CookiesClicker.Signals;
using CookiesClicker.UseCase;
using System;
using System.Collections.Generic;
using Zenject;

namespace CookiesClicker.Infrastructure
{
    public class AppController : IAppController
    {
        [Inject]
        DiContainer container;

        Stack<KeyValuePair<Type, object[]>> history = new();

        private IAppUseCase currentUseCase;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            signalBus.Subscribe<PushAppStateSignal>(x =>
            {
                if (currentUseCase != null)
                    currentUseCase.End();

                history.Push(x.ToPair());
                currentUseCase = (IAppUseCase)container.Resolve(x.Target);
                currentUseCase.Begin(x.Args);
            });

            signalBus.Subscribe<PopAppStateSignal>(x =>
            {
                if (currentUseCase != null)
                {
                    currentUseCase.End();
                    history.Pop();
                }

                var pair = history.Peek();
                currentUseCase = (IAppUseCase)container.Resolve(pair.Key);
                currentUseCase.Begin(pair.Value);
            });
        }
    }
}
