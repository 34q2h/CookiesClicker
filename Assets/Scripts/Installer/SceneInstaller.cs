using CookiesClicker.Infrastructure;
using CookiesClicker.Presentation;
using CookiesClicker.Settings;
using CookiesClicker.Signals;
using CookiesClicker.UseCase;
using Zenject;

namespace CookiesClicker.Installer
{
    public class SceneInstaller : MonoInstaller<SceneInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<AppSettingsScriptableObject>()
                .FromScriptableObjectResource(Constants.SETTINGS)
                .AsSingle();


            // Infrastructure signals
            SignalBusInstaller.Install(Container);

            Container
                .DeclareSignal<PushAppStateSignal>();

            Container
                .DeclareSignal<PopAppStateSignal>();


            // Infrastructure
            Container
                .BindInterfacesAndSelfTo<AppController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<InputController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<FirebaseStatisticsRepository>()
                .AsSingle()
                .NonLazy();


            // App UseCases
            Container
                .Bind<ILoadingUseCase>()
                .FromSubContainerResolve()
                .ByMethod(InstallAuth)
                .AsTransient();

            Container
                .Bind<IGameUseCase>()
                .FromSubContainerResolve()
                .ByMethod(InstallGame)
                .AsTransient();

            Container
                .Bind<IStatisticsUseCase>()
                .FromSubContainerResolve()
                .ByMethod(InstallStatistics)
                .AsCached();


            // Content
            Container
                .BindInterfacesAndSelfTo<GameCookie>()
                .FromComponentInHierarchy()
                .AsCached();
        }

        #region UseCases SubContainers
        void InstallAuth(DiContainer subContainer)
        {
            subContainer
                .BindInterfacesAndSelfTo<LoadingUseCase>()
                .AsTransient();

            subContainer
                .BindInterfacesAndSelfTo<LoadingView>()
                .FromComponentInHierarchy()
                .AsCached();

            subContainer
                .BindInterfacesAndSelfTo<LoadingPresenter>()
                .AsTransient();
        }

        void InstallGame(DiContainer subContainer)
        {
            subContainer
                .BindInterfacesAndSelfTo<GameUseCase>()
                .AsTransient();

            subContainer
                .BindInterfacesAndSelfTo<GameView>()
                .FromComponentInHierarchy()
                .AsCached();

            subContainer
                .BindInterfacesAndSelfTo<GamePresenter>()
                .AsTransient();
        }

        void InstallStatistics(DiContainer subContainer)
        {
            subContainer
                .BindInterfacesAndSelfTo<StatisticsUseCase>()
                .AsTransient();

            subContainer
                .BindInterfacesAndSelfTo<StatisticsView>()
                .FromComponentInHierarchy()
                .AsCached();

            subContainer
                .BindInterfacesAndSelfTo<StatisticsPresenter>()
                .AsTransient();

            Container.BindMemoryPool<LeaderItemView, LeaderItemView.Pool>()
                .WithInitialSize(10)
                .FromComponentInNewPrefabResource(Constants.LEADER_PREFAB)
                .AsCached();
        }
        #endregion
    }
}