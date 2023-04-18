using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using Zenject;

namespace GameEngine.Scripts.Cookie.UpgradeCookieUI
{
    public class UpgradeCookieUI : MonoBehaviour
    {
        [Inject] private CookieSystem _cookieSystem;

        [SerializeField] private TextMeshProUGUI _upgradeText;

        public event Action OnPurchaseButtonClicked;

        private void Awake()
        {
            OnPurchaseButtonClicked += SetUpCookieUI;
            _cookieSystem.OnUpgrade += SetUpCookieUI;
            SetUpCookieUI();
        }

        [Button]
        public void SetUpCookieUI()
        {
            var currentLevel = _cookieSystem.CookieUpgradeSystem.CookieUpgrade.CurrentLevel;
            _upgradeText.text = "Cookie level is " + currentLevel + ". Cost of next upgrade is " +
                                _cookieSystem.CookieUpgradeSystem.CookieUpgrade.CostProgression[currentLevel];
        }

        public void TryPurchase()
        {
            OnPurchaseButtonClicked?.Invoke();
        }

        private void OnDestroy()
        {
            OnPurchaseButtonClicked -= SetUpCookieUI;
            _cookieSystem.OnUpgrade -= SetUpCookieUI;
        }
    }
}