namespace CookiesClicker.UseCase
{
    public interface IAppUseCase : IUseCase { }
    public interface ILoadingUseCase : IAppUseCase { }
    public interface IGameUseCase : IAppUseCase { }
    public interface IStatisticsUseCase : IAppUseCase { }
}
