using TMPro;
using UnityEngine.UI;

namespace CookiesClicker.Presentation
{
    public interface IGameView
    {
        TextMeshProUGUI ScoreText { get; }
        Button StatisticsBtn { get; }
        Button StoreBtn { get; }
    }
}