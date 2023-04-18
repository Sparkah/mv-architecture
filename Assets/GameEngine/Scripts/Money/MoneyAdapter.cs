using GameEngine.Money;
using UnityEngine;
using Zenject;

namespace GameEngine.Scripts.Money
{
    public class MoneyAdapter : MonoBehaviour, IMoneyAdapter
    {
        [SerializeField] private MoneyUI _moneyUI;
        [Inject] private MoneySystem _moneySystem;

        private void Awake()
        {
            _moneySystem.OnMoneyChanged += DisplayMoney;
        }

        public void DisplayMoney(int amount)
        {
            _moneyUI.ChangeMoneyText(amount);
        }

        private void OnDestroy()
        {
            _moneySystem.OnMoneyChanged -= DisplayMoney;
        }
    }
}
