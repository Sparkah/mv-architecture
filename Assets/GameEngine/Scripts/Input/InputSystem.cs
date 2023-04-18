using System;
using GameEngine.Scripts.Cookie;
using GameEngine.Scripts.Money;
using UnityEngine;
using Zenject;

namespace GameEngine.Scripts.Input
{
    public class InputSystem : MonoBehaviour
    {
        [Inject] private MoneySystem _moneySystem;
        [Inject] private CookieSystem _cookieSystem;

        public event Action OnClick;
        private void Update()
        {
            if (!UnityEngine.Input.GetMouseButtonDown(0)) return;
            Click();
        }

        private void Click()
        {
            OnClick?.Invoke();
            var cookieLevel = _cookieSystem.CookieUpgradeSystem.CookieUpgrade.CurrentLevel;
            _moneySystem.MoneyStorage.AddMoney(_cookieSystem.CookieUpgradeSystem.CookieUpgrade.AdditionalIncome[cookieLevel]);
        }
    }
}
