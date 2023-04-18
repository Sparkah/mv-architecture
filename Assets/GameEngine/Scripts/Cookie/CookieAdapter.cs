using UnityEngine;
using Zenject;

namespace GameEngine.Scripts.Cookie
{
    public class CookieAdapter : MonoBehaviour
    {
        [Inject] private CookieSystem _system;
        [SerializeField] private UpgradeCookieUI.UpgradeCookieUI _ui;

        private void Awake()
        {
            _ui.OnPurchaseButtonClicked += TryPurchase;
        }

        private void TryPurchase()
        {
            _system.Upgrade();
        }

        private void OnDestroy()
        {
            _ui.OnPurchaseButtonClicked -= TryPurchase;
        }
    }
}
