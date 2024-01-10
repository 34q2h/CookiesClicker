using TMPro;
using UnityEngine;
using Zenject;

namespace CookiesClicker.Presentation
{
    public class LeaderItemView : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI valueTxt;

        public void SetValue(string result, bool isUser)
        {
            valueTxt.fontStyle = (isUser) ? FontStyles.Underline : FontStyles.Normal;
            valueTxt.text = result;
        }

        public class Pool : MonoMemoryPool<LeaderItemView> { }
    }
}