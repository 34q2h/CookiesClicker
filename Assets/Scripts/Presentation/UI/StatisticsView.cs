using UnityEngine;
using UnityEngine.UI;

namespace CookiesClicker.Presentation
{
    public class StatisticsView : UIView, IStatisticsView
    {
        [SerializeField]
        Button backBtn;

        [SerializeField]
        Transform contentRoot;

        Button IStatisticsView.BackBtn => backBtn;

        Transform IStatisticsView.ContentRoot => contentRoot;
    }
}
