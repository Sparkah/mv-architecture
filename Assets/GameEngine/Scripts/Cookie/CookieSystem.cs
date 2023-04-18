using System;
using GameEngine.Scripts.Base.SaveLoadGame;
using GameEngine.Scripts.Cookie.Upgrades;
using GameEngine.Scripts.Money;
using UnityEngine;
using Zenject;

namespace GameEngine.Scripts.Cookie
{
    public class CookieSystem : MonoBehaviour
    {
        public CookieUpgradeSystem CookieUpgradeSystem;
        public event Action OnUpgrade;

        private IGameDataLoader _gameDataLoader;
        private IGameDataSaver _gameDataSaver;

        [Inject] private MoneySystem _moneySystem;
            
        [Inject(Id = "Cookie")]
        public IGameDataLoader GameDataLoader
        {
            set { _gameDataLoader = value; }
        }

        [Inject(Id = "Cookie")]
        public IGameDataSaver GameDataSaver
        {
            set { _gameDataSaver = value; }
        }

        public void Upgrade()
        {
            var currentLevel = CookieUpgradeSystem.CookieUpgrade.CurrentLevel;
            if (_moneySystem.MoneyStorage.Money >= CookieUpgradeSystem.CookieUpgrade.CostProgression[currentLevel])
            {
                _moneySystem.MoneyStorage.SpendMoney(CookieUpgradeSystem.CookieUpgrade.CostProgression[currentLevel]);
                CookieUpgradeSystem.Upgrade();
                OnUpgrade?.Invoke();
            }
            else
            {
                Debug.Log("Not enough money");
            }
        }

        private void Awake()
        {
            _gameDataLoader.LoadData();
        }

        private void OnDestroy()
        {
            _gameDataSaver.SaveData();
        }
    }
}
