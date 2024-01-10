using UnityEngine;

namespace CookiesClicker.Presentation
{
    public abstract class UIView : MonoBehaviour, IUIView
    {
        private void Awake() => ((IUIView)this).Hide();

        void IUIView.Show() => gameObject.SetActive(true);

        void IUIView.Hide() => gameObject.SetActive(false);
    }
}