using UnityEngine;

namespace CookiesClicker.Settings
{
    [CreateAssetMenu(
        fileName = "AppSettings",
        menuName = "ScriptableObjects/AppSettingsScriptableObject",
        order = 1)]
    public class AppSettingsScriptableObject : ScriptableObject
    {
        public float loaderTweenTime = 3f;
        public Vector3 loaderRotation = new Vector3(0f, 0f, -90f);

        public float scoreScaleTime = .05f;
        public float scoreScaleSize = 1.25f;

        public float cookieScaleTime = .1f;
        public float cookieScaleSize = 1.1f;
    }
}