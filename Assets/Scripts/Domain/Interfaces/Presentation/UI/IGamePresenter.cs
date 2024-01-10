namespace CookiesClicker.Presentation
{
    public interface IGamePresenter : IUIPresenter
    {
        int GameScore { get; set; }
    }
}