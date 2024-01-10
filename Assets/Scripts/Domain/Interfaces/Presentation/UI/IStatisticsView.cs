using UnityEngine;
using UnityEngine.UI;

namespace CookiesClicker.Presentation
{
    public interface IStatisticsView
    {
        Button BackBtn { get; }

        Transform ContentRoot { get; }
    }
}