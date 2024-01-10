namespace CookiesClicker.UseCase
{
    public interface IUseCase
    {
        void Begin(params object[] args);
        void End();
    }
}
