using System;
using GameEngine.Scripts.Base.SaveLoadGame;
using UnityEngine;
using Zenject;

namespace GameEngine.Scripts.Money
{
    public class MoneySystem : MonoBehaviour
    {
        public event Action<int> OnMoneyChanged;
        public MoneyStorage MoneyStorage => _moneyStorage;
        [SerializeField] private MoneyStorage _moneyStorage;
        
            private IGameDataLoader _gameDataLoader;
            private IGameDataSaver _gameDataSaver;
            
            [Inject(Id = "Money")]
            public IGameDataLoader GameDataLoader
            {
                set { _gameDataLoader = value; }
            }

            [Inject(Id = "Money")]
            public IGameDataSaver GameDataSaver
            {
                set { _gameDataSaver = value; }
            }

        private void Start()
        {
            MoneyStorage.OnMoneyChanged += ChangeMoney;
            _gameDataLoader.LoadData();
        }

        private void ChangeMoney(int amount)
        {
            OnMoneyChanged?.Invoke(amount);
        }

        private void OnDestroy()
        {
            MoneyStorage.OnMoneyChanged -= ChangeMoney;
            _gameDataSaver.SaveData();
        }
    }
}