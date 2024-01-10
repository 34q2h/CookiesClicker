using UniRx;

namespace CookiesClicker.Infrastructure
{
    public interface IInputController
    {
        ReactiveCommand OnClick { get; }
    }
}