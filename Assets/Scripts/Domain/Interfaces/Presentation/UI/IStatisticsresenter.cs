using CookiesClicker.DTO;

namespace CookiesClicker.Presentation
{
    public interface IStatisticsPresenter : IUIPresenter
    {
        void ShowLeaders(LeadrsDTO value, int gameScore);
    }
}