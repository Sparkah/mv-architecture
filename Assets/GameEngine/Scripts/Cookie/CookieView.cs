using UnityEngine;
using Zenject;

namespace GameEngine.Scripts.Cookie
{
    public class CookieView : MonoBehaviour
    {
        [Inject] private CookieSystem _cookieSystem;
        [SerializeField] private GameObject[] _cookies;

        private void Awake()
        {
            _cookieSystem.OnUpgrade += UpgradeView;
            UpgradeView();
        }

        private void UpgradeView()
        {
            foreach (var cookie in _cookies)
            {
                cookie.SetActive(false);
            }
            _cookies[_cookieSystem.CookieUpgradeSystem.CookieUpgrade.CurrentLevel].SetActive(true);
        }

        private void OnDestroy()
        {
            _cookieSystem.OnUpgrade -= UpgradeView;
        }
    }
}