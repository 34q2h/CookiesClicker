using CookiesClicker.DTO;
using Cysharp.Threading.Tasks;

namespace CookiesClicker.Infrastructure
{
    public interface IStatisticsRepository
    {
        UniTask<LeadrsDTO> PullLeaders();
    }
}